// Decompiled with JetBrains decompiler
// Type: Julios.SetLuckyPigColorRemoveBlueEffect
// Assembly: Julios, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3E760DF5-48A7-4D53-B202-D773C9554515
// Assembly location: C:\Users\windows\Downloads\Julios.dll

using UnityEngine;

#nullable disable
namespace Julios
{
  public class SetLuckyPigColorRemoveBlueEffect : EffectSO
  {
    [SerializeField]
    public ManaColorSO _luckyColor;

    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 1;
      stats.LuckyManaColorOptions.Clear();
      stats.LuckyManaColorOptions.Add(this._luckyColor);
      CombatManager.Instance.AddUIAction((CombatAction) new UpdateLuckyManaColorUIAction(stats.LuckyManaColorOptions.Count - 1));
      return true;
    }
  }
}
