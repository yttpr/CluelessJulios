// Decompiled with JetBrains decompiler
// Type: Julios.TemperedEffectorCondition
// Assembly: Julios, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3E760DF5-48A7-4D53-B202-D773C9554515
// Assembly location: C:\Users\windows\Downloads\Julios.dll

#nullable disable
namespace Julios
{
  public class TemperedEffectorCondition : EffectorConditionSO
  {
    public override bool MeetCondition(IEffectorChecks effector, object args)
    {
      if (args is DamageReceivedValueChangeException valueChangeException)
        valueChangeException.AddModifier((IntValueModifier) new FragileValueModifier(1));
      return true;
    }
  }
}
