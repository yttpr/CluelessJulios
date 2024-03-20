// Decompiled with JetBrains decompiler
// Type: Julios.FragilePassiveAbility
// Assembly: Julios, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3E760DF5-48A7-4D53-B202-D773C9554515
// Assembly location: C:\Users\windows\Downloads\Julios.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace Julios
{
  public class FragilePassiveAbility : BasePassiveAbilitySO
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
      int storedValue1 = iunit.GetStoredValue((UnitStoredValueNames) 887788);
      if (storedValue1 < 1)
      {
        int num1 = 4 - iunit.CurrentHealth;
        int num2 = 0;
        SetCasterExtraSpritesEffect instance = ScriptableObject.CreateInstance<SetCasterExtraSpritesEffect>();
        instance._spriteType = (ExtraSpriteType) 22332;
        for (; num1 > 0; --num1)
        {
          if (iunit.IsUnitCharacter)
          {
            CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1]
            {
              new Effect((EffectSO) instance, 1, new IntentType?(), Slots.Self)
            }), iunit, 0));
            ++num2;
          }
        }
        iunit.SetStoredValue((UnitStoredValueNames) 2233445, num2);
        ++storedValue1;
        iunit.SetStoredValue((UnitStoredValueNames) 887788, storedValue1);
      }
      if (storedValue1 > 0 && !(args is DamageReceivedValueChangeException) && !(args is CanHealReference))
      {
        int num = 4 - iunit.GetStoredValue((UnitStoredValueNames) 2233445);
        int storedValue2 = iunit.GetStoredValue((UnitStoredValueNames) 2233445);
        if (iunit.CurrentHealth < 4)
        {
          SetCasterExtraSpritesEffect instance = ScriptableObject.CreateInstance<SetCasterExtraSpritesEffect>();
          instance._spriteType = (ExtraSpriteType) 22332;
          for (; num > iunit.CurrentHealth; --num)
          {
            if (iunit.IsUnitCharacter)
            {
              CombatManager.Instance.AddSubAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[1]
              {
                new Effect((EffectSO) instance, 1, new IntentType?(), Slots.Self)
              }), iunit, 0));
              ++storedValue2;
            }
          }
          iunit.SetStoredValue((UnitStoredValueNames) 2233445, storedValue2);
        }
      }
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
