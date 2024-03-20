// Decompiled with JetBrains decompiler
// Type: Julios.SetRandomCasterExtraSpritesEffect
// Assembly: Julios, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3E760DF5-48A7-4D53-B202-D773C9554515
// Assembly location: C:\Users\windows\Downloads\Julios.dll

using UnityEngine;

#nullable disable
namespace Julios
{
  public class SetRandomCasterExtraSpritesEffect : EffectSO
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
      exitAmount = 0;
      if (!caster.IsUnitCharacter)
        return false;
      for (int index = 0; index < Random.Range(0, 21); ++index)
        CombatManager.Instance.AddUIAction((CombatAction) new CharacterSetExtraSpriteUIAction(caster.ID, this._spriteType));
      return true;
    }
  }
}
