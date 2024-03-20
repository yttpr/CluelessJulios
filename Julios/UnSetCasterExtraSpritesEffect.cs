// Decompiled with JetBrains decompiler
// Type: Julios.UnSetCasterExtraSpritesEffect
// Assembly: Julios, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3E760DF5-48A7-4D53-B202-D773C9554515
// Assembly location: C:\Users\windows\Downloads\Julios.dll

using UnityEngine;

#nullable disable
namespace Julios
{
  public class UnSetCasterExtraSpritesEffect : EffectSO
  {
    [SerializeField]
    public ExtraSpriteType _spriteType;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      int num = 3 - caster.GetStoredValue((UnitStoredValueNames) 2233445);
      exitAmount = 0;
      for (; num > 0; --num)
      {
        if (caster.IsUnitCharacter)
          CombatManager.Instance.AddUIAction((CombatAction) new CharacterSetExtraSpriteUIAction(caster.ID, this._spriteType));
      }
      return true;
    }
  }
}
