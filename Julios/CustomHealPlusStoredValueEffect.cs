// Decompiled with JetBrains decompiler
// Type: Julios.CustomHealPlusStoredValueEffect
// Assembly: Julios, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3E760DF5-48A7-4D53-B202-D773C9554515
// Assembly location: C:\Users\windows\Downloads\Julios.dll

using UnityEngine;

#nullable disable
namespace Julios
{
  public class CustomHealPlusStoredValueEffect : EffectSO
  {
    [SerializeField]
    public DeathType _deathType = (DeathType) 1;
    [SerializeField]
    public bool _usePreviousExitValue;
    [SerializeField]
    public bool _onlyIfHasHealthOver0;
    public UnitStoredValueNames _valueName = (UnitStoredValueNames)(-1);
    [SerializeField]
    public bool _directHeal = true;
    [SerializeField]
    public int _multi = 1;

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
        if (target.HasUnit && (!this._onlyIfHasHealthOver0 || target.Unit.CurrentHealth > 0))
        {
          int num1 = caster.GetStoredValue(this._valueName) * this._multi;
          int num2 = entryVariable;
          exitAmount += target.Unit.Heal(num2 + num1, (HealType) 1, this._directHeal);
        }
      }
      return exitAmount > 0;
    }
  }
}
