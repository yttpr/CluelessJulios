// Decompiled with JetBrains decompiler
// Type: Julios.StatusSharePassiveAbility
// Assembly: Julios, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3E760DF5-48A7-4D53-B202-D773C9554515
// Assembly location: C:\Users\windows\Downloads\Julios.dll

#nullable disable
namespace Julios
{
  public class StatusSharePassiveAbility : BasePassiveAbilitySO
  {
    public override bool IsPassiveImmediate => true;

    public override bool DoesPassiveTrigger => true;

    public override void TriggerPassive(object sender, object args)
    {
    }

    public override void OnPassiveConnected(IUnit unit) => ++StatusApplyShareHook.inCombat;

    public override void OnPassiveDisconnected(IUnit unit) => --StatusApplyShareHook.inCombat;
  }
}
