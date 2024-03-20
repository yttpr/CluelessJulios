// Decompiled with JetBrains decompiler
// Type: Julios.TemperedPassiveAbility
// Assembly: Julios, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3E760DF5-48A7-4D53-B202-D773C9554515
// Assembly location: C:\Users\windows\Downloads\Julios.dll

using UnityEngine;

#nullable disable
namespace Julios
{
  public class TemperedPassiveAbility : BasePassiveAbilitySO
  {
    [Header("Multiplier Data")]
    [SerializeField]
    [Min(0.0f)]
    private int _modifyVal = 1;

    public override bool IsPassiveImmediate => true;

    public override bool DoesPassiveTrigger => true;

    public override void TriggerPassive(object sender, object args)
    {
      IUnit iunit = sender as IUnit;
      if (args is DamageReceivedValueChangeException valueChangeException && valueChangeException.amount > 0 && args is DamageReceivedValueChangeException && !(args as DamageReceivedValueChangeException).Equals((object) null))
      {
        (args as DamageReceivedValueChangeException).AddModifier((IntValueModifier) new FragileValueModifier(this._modifyVal));
        CombatManager.Instance.AddUIAction((CombatAction) new ShowPassiveInformationUIAction(((IEffectorChecks) (sender as IPassiveEffector)).ID, ((IEffectorChecks) (sender as IPassiveEffector)).IsUnitCharacter, this.GetPassiveLocData().text, this.passiveIcon));
      }
      if (!(args is CanHealReference canHealReference))
        return;
      CombatManager.Instance.AddUIAction((CombatAction) new ShowPassiveInformationUIAction(iunit.ID, iunit.IsUnitCharacter, this.GetPassiveLocData().text, this.passiveIcon));
      canHealReference.value = false;
    }

    public override void OnPassiveConnected(IUnit unit)
    {
    }

    public override void OnPassiveDisconnected(IUnit unit)
    {
    }
  }
}
