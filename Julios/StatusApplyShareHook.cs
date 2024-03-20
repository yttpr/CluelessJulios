// Decompiled with JetBrains decompiler
// Type: Julios.StatusApplyShareHook
// Assembly: Julios, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3E760DF5-48A7-4D53-B202-D773C9554515
// Assembly location: C:\Users\windows\Downloads\Julios.dll

using BrutalAPI;
using MonoMod.RuntimeDetour;
using System;
using System.Reflection;
using UnityEngine;

#nullable disable
namespace Julios
{
  public static class StatusApplyShareHook
  {
    public static int inCombat;

    public static bool ApplyStatusEffectCH(
      Func<CharacterCombat, IStatusEffect, int, bool> orig,
      CharacterCombat self,
      IStatusEffect statusEffect,
      int amount)
    {
      if (StatusApplyShareHook.inCombat > 0)
      {
        foreach (BasePassiveAbilitySO passiveAbility in self._passiveAbilities)
        {
          if (passiveAbility is StatusSharePassiveAbility)
            return orig(self, statusEffect, amount);
        }
        Targetting_ByUnit_Side instance1 = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
        instance1.getAllies = true;
        instance1.getAllUnitSlots = false;
        Targetting_ByUnit_Side instance2 = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
        instance2.getAllies = false;
        instance2.getAllUnitSlots = false;
        ShareStatusEffectEffect instance3 = ScriptableObject.CreateInstance<ShareStatusEffectEffect>();
        instance3.statusToApply = statusEffect;
        CombatManager.Instance.AddPrioritySubAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[2]
        {
          new Effect((EffectSO) instance3, amount, new IntentType?(), (BaseCombatTargettingSO) instance1),
          new Effect((EffectSO) instance3, amount, new IntentType?(), (BaseCombatTargettingSO) instance2)
        }), (IUnit) self, 0));
      }
      return orig(self, statusEffect, amount);
    }

    public static bool ApplyStatusEffectEN(
      Func<EnemyCombat, IStatusEffect, int, bool> orig,
      EnemyCombat self,
      IStatusEffect statusEffect,
      int amount)
    {
      if (StatusApplyShareHook.inCombat > 0)
      {
        foreach (BasePassiveAbilitySO passiveAbility in self._passiveAbilities)
        {
          if (passiveAbility is StatusSharePassiveAbility)
            return orig(self, statusEffect, amount);
        }
        Targetting_ByUnit_Side instance1 = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
        instance1.getAllies = true;
        instance1.getAllUnitSlots = false;
        Targetting_ByUnit_Side instance2 = ScriptableObject.CreateInstance<Targetting_ByUnit_Side>();
        instance2.getAllies = false;
        instance2.getAllUnitSlots = false;
        ShareStatusEffectEffect instance3 = ScriptableObject.CreateInstance<ShareStatusEffectEffect>();
        instance3.statusToApply = statusEffect;
        CombatManager.Instance.AddPrioritySubAction((CombatAction) new EffectAction(ExtensionMethods.ToEffectInfoArray(new Effect[2]
        {
          new Effect((EffectSO) instance3, amount, new IntentType?(), (BaseCombatTargettingSO) instance1),
          new Effect((EffectSO) instance3, amount, new IntentType?(), (BaseCombatTargettingSO) instance2)
        }), (IUnit) self, 0));
      }
      return orig(self, statusEffect, amount);
    }

    public static void Add()
    {
      IDetour idetour1 = (IDetour) new Hook((MethodBase) typeof (CharacterCombat).GetMethod("ApplyStatusEffect", ~BindingFlags.Default), typeof (StatusApplyShareHook).GetMethod("ApplyStatusEffectCH", ~BindingFlags.Default));
      IDetour idetour2 = (IDetour) new Hook((MethodBase) typeof (EnemyCombat).GetMethod("ApplyStatusEffect", ~BindingFlags.Default), typeof (StatusApplyShareHook).GetMethod("ApplyStatusEffectEN", ~BindingFlags.Default));
    }
  }
}
