// Decompiled with JetBrains decompiler
// Type: Julios.DirectPlusStoredValue2Effect
// Assembly: Julios, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3E760DF5-48A7-4D53-B202-D773C9554515
// Assembly location: C:\Users\windows\Downloads\Julios.dll

using UnityEngine;

#nullable disable
namespace Julios
{
  public class DirectPlusStoredValue2Effect : EffectSO
  {
    [SerializeField]
    public DeathType _deathType = (DeathType) 1;
    [SerializeField]
    public bool _usePreviousExitValue;
    [SerializeField]
    public bool _ignoreShield;
    [SerializeField]
    public bool _indirect;
    [SerializeField]
    public bool _returnKillAsSuccess;
    [SerializeField]
    public int _multi = 2;
    public UnitStoredValueNames _valueName = (UnitStoredValueNames)(-1);

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      if (this._usePreviousExitValue)
        entryVariable *= this.PreviousExitValue;
      exitAmount = 0;
      foreach (TargetSlotInfo target in targets)
      {
        if (target.HasUnit)
        {
          int num1 = areTargetSlots ? target.SlotID - target.Unit.SlotID : -1;
          int num2 = entryVariable;
          int num3 = caster.GetStoredValue(this._valueName) * this._multi;
          int num4 = caster.WillApplyDamage(num2, target.Unit);
          DamageInfo damageInfo = target.Unit.Damage(num4 + num3, caster, (DeathType) 1, num1, true, true, false, (DamageType) 0);
          exitAmount += damageInfo.damageAmount;
        }
      }
      if (exitAmount > 0)
        caster.DidApplyDamage(exitAmount);
      return exitAmount > 0;
    }
  }
}
