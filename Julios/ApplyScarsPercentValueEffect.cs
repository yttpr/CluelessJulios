// Decompiled with JetBrains decompiler
// Type: Julios.ApplyScarsPercentValueEffect
// Assembly: Julios, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3E760DF5-48A7-4D53-B202-D773C9554515
// Assembly location: C:\Users\windows\Downloads\Julios.dll

using UnityEngine;

#nullable disable
namespace Julios
{
  public class ApplyScarsPercentValueEffect : EffectSO
  {
    [SerializeField]
    public bool _justOneTarget;
    [SerializeField]
    public bool _randomBetweenPrevious;
    [SerializeField]
    public UnitStoredValueNames _valueName = (UnitStoredValueNames) (-1);

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
      stats.statusEffectDataBase.TryGetValue((StatusEffectType) 11, out statusEffectInfoSo);
      for (int index = 0; index < targets.Length; ++index)
      {
        int num = Random.Range(0, 100);
        int storedValue = caster.GetStoredValue(this._valueName);
        entryVariable *= storedValue;
        if (num < entryVariable && targets[index].HasUnit)
        {
          Scars_StatusEffect scarsStatusEffect = new Scars_StatusEffect(1, 0);
          scarsStatusEffect.SetEffectInformation(statusEffectInfoSo);
          if (targets[index].Unit.ApplyStatusEffect((IStatusEffect) scarsStatusEffect, 1))
            ++exitAmount;
        }
      }
      return exitAmount > 0;
    }
  }
}
