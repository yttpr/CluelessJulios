// Decompiled with JetBrains decompiler
// Type: Julios.ShareStatusEffectEffect
// Assembly: Julios, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3E760DF5-48A7-4D53-B202-D773C9554515
// Assembly location: C:\Users\windows\Downloads\Julios.dll

using System;
using System.Reflection;
using UnityEngine;

#nullable disable
namespace Julios
{
  public class ShareStatusEffectEffect : EffectSO
  {
    [SerializeField]
    public IStatusEffect statusToApply;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      if (entryVariable <= 0)
        return false;
      StatusEffectInfoSO statusEffectInfoSo;
      stats.statusEffectDataBase.TryGetValue(this.statusToApply.EffectType, out statusEffectInfoSo);
      for (int index = 0; index < targets.Length; ++index)
      {
        if (targets[index].HasUnit)
        {
          bool flag = false;
          if (targets[index].Unit is CharacterCombat unit1)
          {
            foreach (BasePassiveAbilitySO passiveAbility in unit1._passiveAbilities)
            {
              if (passiveAbility is StatusSharePassiveAbility)
                flag = true;
            }
          }
          if (targets[index].Unit is EnemyCombat unit2)
          {
            foreach (BasePassiveAbilitySO passiveAbility in unit2._passiveAbilities)
            {
              if (passiveAbility is StatusSharePassiveAbility)
                flag = true;
            }
          }
          if (flag)
          {
            IStatusEffect istatusEffect = this.statusToApply;
            foreach (ConstructorInfo constructor in this.statusToApply.GetType().GetConstructors())
            {
              if (constructor.GetParameters().Length == 2)
              {
                istatusEffect = (IStatusEffect) Activator.CreateInstance(this.statusToApply.GetType(), (object) this.statusToApply.StatusContent, (object) this.statusToApply.Restrictor);
                break;
              }
              if (constructor.GetParameters().Length == 1)
              {
                istatusEffect = (IStatusEffect) Activator.CreateInstance(this.statusToApply.GetType(), (object) this.statusToApply.Restrictor);
                break;
              }
              if (constructor.GetParameters().Length == 0)
              {
                istatusEffect = (IStatusEffect) Activator.CreateInstance(this.statusToApply.GetType());
                break;
              }
            }
            istatusEffect.SetEffectInformation(statusEffectInfoSo);
            if (targets[index].Unit.ApplyStatusEffect(istatusEffect, entryVariable))
              exitAmount += istatusEffect.StatusContent;
          }
        }
      }
      return exitAmount > 0;
    }
  }
}
