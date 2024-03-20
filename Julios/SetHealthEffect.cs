// Decompiled with JetBrains decompiler
// Type: Julios.SetHealthEffect
// Assembly: Julios, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3E760DF5-48A7-4D53-B202-D773C9554515
// Assembly location: C:\Users\windows\Downloads\Julios.dll

#nullable disable
namespace Julios
{
  public class SetHealthEffect : EffectSO
  {
    public override bool PerformEffect(
      CombatStats stats,
      IUnit caster,
      TargetSlotInfo[] targets,
      bool areTargetSlots,
      int entryVariable,
      out int exitAmount)
    {
      exitAmount = 0;
      foreach (TargetSlotInfo target in targets)
      {
        if (target.HasUnit && target.Unit.IsAlive)
        {
          int num = entryVariable;
          if (target.Unit.SetHealthTo(num))
            ++exitAmount;
        }
      }
      return exitAmount > 0;
    }
  }
}
