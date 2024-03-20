// Decompiled with JetBrains decompiler
// Type: Julios.ApplyShieldAllPartyMembersCombatStartPassiveAbility
// Assembly: Julios, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3E760DF5-48A7-4D53-B202-D773C9554515
// Assembly location: C:\Users\windows\Downloads\Julios.dll

using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#nullable disable
namespace Julios
{
  public class ApplyShieldAllPartyMembersCombatStartPassiveAbility : BasePassiveAbilitySO
  {
    public override bool IsPassiveImmediate => true;

    public override bool DoesPassiveTrigger => true;

    public override void TriggerPassive(object sender, object args)
    {
    }

    public void ApplyShield(object sender, object args)
    {
      CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 5, new IntentType?(), Slots.SlotTarget(new int[9]
        {
          -4,
          -3,
          -2,
          -1,
          0,
          1,
          2,
          3,
          4
        }, true))
      }), sender as IUnit, 0));
      CombatManager.Instance.RemoveObserver(new Action<object, object>(this.ApplyShield), ((TriggerCalls) 6).ToString(), (object) CombatManager.Instance._stats.CharactersOnField.First<KeyValuePair<int, CharacterCombat>>().Value);
    }

    public override void OnPassiveConnected(IUnit unit)
    {
      CombatManager.Instance.AddObserver(new Action<object, object>(this.ApplyShield), ((TriggerCalls) 6).ToString(), (object) CombatManager.Instance._stats.CharactersOnField.First<KeyValuePair<int, CharacterCombat>>().Value);
    }

    public override void OnPassiveDisconnected(IUnit unit)
    {
    }
  }
}
