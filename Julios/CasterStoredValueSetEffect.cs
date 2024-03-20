// Decompiled with JetBrains decompiler
// Type: Julios.CasterStoredValueSetEffect
// Assembly: Julios, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3E760DF5-48A7-4D53-B202-D773C9554515
// Assembly location: C:\Users\windows\Downloads\Julios.dll

using UnityEngine;

#nullable disable
namespace Julios
{
  public class CasterStoredValueSetEffect : EffectSO
  {
    [SerializeField]
    public bool _increase = true;
    [SerializeField]
    public int _minimumValue = 1;
    [SerializeField]
    public UnitStoredValueNames _valueName = (UnitStoredValueNames) 2;
    [SerializeField]
    public bool _randomBetweenPrevious;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = caster.GetStoredValue(this._valueName);
      exitAmount = entryVariable;
      caster.SetStoredValue(this._valueName, entryVariable);
      return true;
    }
  }
}
