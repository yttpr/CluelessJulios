// Decompiled with JetBrains decompiler
// Type: Julios.IfRupturedDamageUpCondition
// Assembly: Julios, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3E760DF5-48A7-4D53-B202-D773C9554515
// Assembly location: C:\Users\windows\Downloads\Julios.dll

#nullable disable
namespace Julios
{
  public class IfRupturedDamageUpCondition : EffectorConditionSO
  {
    public override bool MeetCondition(IEffectorChecks effector, object args)
    {
      if (args is DamageDealtValueChangeException valueChangeException && effector is IUnit iunit && iunit.ContainsStatusEffect((StatusEffectType) 2, 0))
      {
        CombatManager.Instance.AddUIAction((CombatAction) new ShowItemInformationUIAction(effector.ID, "Stained Glass Shard", false, ResourceLoader.LoadSprite("Glass", 32)));
        valueChangeException.AddModifier((IntValueModifier) new FortyPercentUpValueModifier());
      }
      return true;
    }
  }
}
