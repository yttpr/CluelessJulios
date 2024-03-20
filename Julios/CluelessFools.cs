// Decompiled with JetBrains decompiler
// Type: Julios.CluelessFools
// Assembly: Julios, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3E760DF5-48A7-4D53-B202-D773C9554515
// Assembly location: C:\Users\windows\Downloads\Julios.dll

using BepInEx;
using BrutalAPI;
using MonoMod.RuntimeDetour;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

#nullable disable
namespace Julios
{
  [BepInPlugin("Clueless.Julios", "Clueless' Julios", "1.1.1")]
    [BepInDependency("Bones404.BrutalAPI", (BepInDependency.DependencyFlags)1)]
    public class CluelessFools : BaseUnityPlugin
  {
    public static Character Julios;
    public static IntentInfo guttedIntent = (IntentInfo) new IntentInfoBasic();

    public void Awake()
    {
      FoolBossUnlockSystem.Setup();
      CluelessFools.Add();
      Backrooms.Setup();
      this.Logger.LogInfo((object) "Clueless.Julios loaded successfully!");
    }

        public static void Add()
        {
            IDetour detour = new Hook(typeof(TooltipTextHandlerSO).GetMethod("ProcessStoredValue", (BindingFlags)(-1)), typeof(CluelessFools).GetMethod("AddStoredValueName", (BindingFlags)(-1)));
            IDetour detour2 = new Hook(typeof(IntentHandlerSO).GetMethod("Initialize", (BindingFlags)(-1)), typeof(CluelessFools).GetMethod("GuttedIntent", (BindingFlags)(-1)));
            SetCasterExtraSpritesEffect setCasterExtraSpritesEffect = ScriptableObject.CreateInstance<SetCasterExtraSpritesEffect>();
            setCasterExtraSpritesEffect._spriteType = (ExtraSpriteType)22332;
            UnSetCasterExtraSpritesEffect unSetCasterExtraSpritesEffect = ScriptableObject.CreateInstance<UnSetCasterExtraSpritesEffect>();
            unSetCasterExtraSpritesEffect._spriteType = (ExtraSpriteType)22332;
            SetCasterExtraSpritesEffect setCasterExtraSpritesEffect2 = ScriptableObject.CreateInstance<SetCasterExtraSpritesEffect>();
            setCasterExtraSpritesEffect2._spriteType = (ExtraSpriteType)22334;
            CasterStoredValueChangeEffect casterStoredValueChangeEffect = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
            casterStoredValueChangeEffect._minimumValue = 0;
            casterStoredValueChangeEffect._valueName = (UnitStoredValueNames)2233445;
            casterStoredValueChangeEffect._increase = true;
            CasterStoredValueSetEffect casterStoredValueSetEffect = ScriptableObject.CreateInstance<CasterStoredValueSetEffect>();
            casterStoredValueSetEffect._minimumValue = 0;
            casterStoredValueSetEffect._valueName = (UnitStoredValueNames)2233445;
            CasterCheckStoredValueCondition casterCheckStoredValueCondition = ScriptableObject.CreateInstance<CasterCheckStoredValueCondition>();
            casterCheckStoredValueCondition._valueName = (UnitStoredValueNames)2233445;
            CasterCheckStoredValueCondition2 casterCheckStoredValueCondition2 = ScriptableObject.CreateInstance<CasterCheckStoredValueCondition2>();
            casterCheckStoredValueCondition2._valueName = (UnitStoredValueNames)2233445;
            DirectPlusStoredValue2Effect directPlusStoredValue2Effect = ScriptableObject.CreateInstance<DirectPlusStoredValue2Effect>();
            directPlusStoredValue2Effect._valueName = (UnitStoredValueNames)2233445;
            DirectPlusStoredValue2Effect directPlusStoredValue2Effect2 = ScriptableObject.CreateInstance<DirectPlusStoredValue2Effect>();
            directPlusStoredValue2Effect2._valueName = (UnitStoredValueNames)2233445;
            directPlusStoredValue2Effect2._multi = 3;
            CustomHealPlusStoredValueEffect customHealPlusStoredValueEffect = ScriptableObject.CreateInstance<CustomHealPlusStoredValueEffect>();
            customHealPlusStoredValueEffect._valueName = (UnitStoredValueNames)2233445;
            CustomHealPlusStoredValueEffect customHealPlusStoredValueEffect2 = ScriptableObject.CreateInstance<CustomHealPlusStoredValueEffect>();
            customHealPlusStoredValueEffect2._valueName = (UnitStoredValueNames)2233445;
            customHealPlusStoredValueEffect2._multi = 2;
            CustomHealPlusStoredValueEffect customHealPlusStoredValueEffect3 = ScriptableObject.CreateInstance<CustomHealPlusStoredValueEffect>();
            customHealPlusStoredValueEffect3._valueName = (UnitStoredValueNames)2233445;
            customHealPlusStoredValueEffect3._multi = 3;
            ApplyScarsPercentValueEffect applyScarsPercentValueEffect = ScriptableObject.CreateInstance<ApplyScarsPercentValueEffect>();
            applyScarsPercentValueEffect._valueName = (UnitStoredValueNames)2233445;
            PerformEffectPassiveAbility performEffectPassiveAbility = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            performEffectPassiveAbility._passiveName = "Picky";
            performEffectPassiveAbility.passiveIcon = ResourceLoader.LoadSprite("PickyIcon", 32, null);
            performEffectPassiveAbility.type = (PassiveAbilityTypes)80003;
            performEffectPassiveAbility._enemyDescription = "This shouldnT be on an enemy.";
            performEffectPassiveAbility._characterDescription = "On using the wrong pigment, instantly kill this party member.";
            performEffectPassiveAbility.doesPassiveTriggerInformationPanel = true;
            DirectDeathEffect effect = ScriptableObject.CreateInstance<DirectDeathEffect>();
            performEffectPassiveAbility.effects = ExtensionMethods.ToEffectInfoArray(new Effect[]
            {
                new Effect(effect, 1, null, Slots.Self, null)
            });
            performEffectPassiveAbility._triggerOn = new TriggerCalls[]
            {
                (TriggerCalls)38
            };
            FragilePassiveAbility fragilePassiveAbility = ScriptableObject.CreateInstance<FragilePassiveAbility>();
            fragilePassiveAbility._passiveName = "Tempered";
            fragilePassiveAbility.passiveIcon = ResourceLoader.LoadSprite("FragileIcon", 32, null);
            fragilePassiveAbility.type = (PassiveAbilityTypes)22323;
            fragilePassiveAbility._enemyDescription = "all damage is reduced to 1, NO HEALING??";
            fragilePassiveAbility._characterDescription = "All damage is reduced to 1. All healing is negated.";
            fragilePassiveAbility.doesPassiveTriggerInformationPanel = false;
            fragilePassiveAbility._triggerOn = new TriggerCalls[]
            {
                TriggerCalls.OnCombatStart,
                TriggerCalls.OnBeingDamaged,
                TriggerCalls.CanHeal,
                TriggerCalls.OnMaxHealthChanged
            };
            PerformEffectPassiveAbility performEffectPassiveAbility2 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            performEffectPassiveAbility2._passiveName = "Fragile";
            performEffectPassiveAbility2.passiveIcon = ResourceLoader.LoadSprite("TemperedIcon", 32, null);
            performEffectPassiveAbility2.type = (PassiveAbilityTypes)22324;
            performEffectPassiveAbility2._enemyDescription = "AAAAAAAAAAAAAJ (i should yell fire in a crowded movie theatre thinking emoji)";
            performEffectPassiveAbility2._characterDescription = "Upon gaining 4 or more cracks, Julios instantly dies. \nJulios gains a point of Fragile every time they are hit.";
            performEffectPassiveAbility2.specialStoredValue = (UnitStoredValueNames)2233445;
            performEffectPassiveAbility2.effects = ExtensionMethods.ToEffectInfoArray(new Effect[]
            {
                new Effect(casterStoredValueChangeEffect, 1, null, Slots.Self, null),
                new Effect(setCasterExtraSpritesEffect, 1, null, Slots.Self, casterCheckStoredValueCondition2),
                new Effect(effect, 1, null, Slots.Self, casterCheckStoredValueCondition)
            });
            performEffectPassiveAbility2._triggerOn = new TriggerCalls[]
            {
                (TriggerCalls)5
            };
            ExtraCCSprites_ArraySO extraCCSprites_ArraySO = ScriptableObject.CreateInstance<ExtraCCSprites_ArraySO>();
            extraCCSprites_ArraySO._doesLoop = true;
            extraCCSprites_ArraySO._useDefault = (ExtraSpriteType)22334;
            extraCCSprites_ArraySO._useSpecial = (ExtraSpriteType)22332;
            extraCCSprites_ArraySO._frontSprite = new Sprite[]
            {
                ResourceLoader.LoadSprite("hit1front", 32, null),
                ResourceLoader.LoadSprite("hit2front", 32, null),
                ResourceLoader.LoadSprite("hit3front", 32, null)
            };
            extraCCSprites_ArraySO._backSprite = new Sprite[]
            {
                ResourceLoader.LoadSprite("hit1back", 32, null),
                ResourceLoader.LoadSprite("hit2back", 32, null),
                ResourceLoader.LoadSprite("hit3back", 32, null)
            };
            Character character = new Character();
            character.name = "Julios";
            character.healthColor = Pigments.Blue;
            character.entityID = (EntityIDs)2233543;
            character.overworldSprite = ResourceLoader.LoadSprite("sammlerjulios", 32, new Vector2?(new Vector2(0.5f, 0f)));
            character.frontSprite = ResourceLoader.LoadSprite("juliosfront", 32, null);
            character.backSprite = ResourceLoader.LoadSprite("juliosback", 32, null);
            character.lockedSprite = ResourceLoader.LoadSprite("JuliosLocked", 32, null);
            character.unlockedSprite = ResourceLoader.LoadSprite("JuliosMenu", 32, null);
            character.extraSprites = extraCCSprites_ArraySO;
            character.menuChar = true;
            character.isSupport = false;
            character.walksInOverworld = true;
            character.hurtSound = LoadedAssetsHandler.GetEnemy("JumbleGuts_Hollowing_EN").damageSound;
            character.deathSound = LoadedAssetsHandler.GetEnemy("JumbleGuts_Hollowing_EN").deathSound;
            character.dialogueSound = LoadedAssetsHandler.GetEnemy("JumbleGuts_Hollowing_EN").damageSound;
            character.passives = new BasePassiveAbilitySO[]
            {
                Passives.Delicate,
                Passives.Withering,
                fragilePassiveAbility,
                performEffectPassiveAbility2
            };
            Ability ability = new Ability();
            ability.name = "Mend the Cracks";
            ability.description = "Set this character's health to 4 and set Fragile to 0.";
            ability.cost = new ManaColorSO[]
            {
                Pigments.Gray
            };
            ability.sprite = ResourceLoader.LoadSprite("MendCracks", 1, null);
            ability.effects = new Effect[4];
            ability.effects[0] = new Effect(ScriptableObject.CreateInstance<SetHealthEffect>(), 4, new IntentType?((IntentType)81), Slots.Self, null);
            ability.effects[1] = new Effect(unSetCasterExtraSpritesEffect, 0, new IntentType?((IntentType)100), Slots.Self, null);
            ability.effects[2] = new Effect(casterStoredValueSetEffect, 0, new IntentType?((IntentType)100), Slots.Self, null);
            ability.effects[3] = new Effect(setCasterExtraSpritesEffect2, 1, null, Slots.Self, null);
            ability.visuals = LoadedAssetsHandler.GetEnemyAbility("Blush_A").visuals;
            ability.animationTarget = Slots.Self;
            character.baseAbility = ability;
            Ability ability2 = new Ability();
            ability2.name = "teest";
            ability2.description = "2 scar 2 ffrail";
            ability2.cost = new ManaColorSO[0];
            ability2.sprite = ResourceLoader.LoadSprite("CombatIconPlaceholder", 1, null);
            ability2.effects = new Effect[3];
            ability2.effects[0] = new Effect(ScriptableObject.CreateInstance<ApplyFrailEffect>(), 2, null, Slots.Self, null);
            ability2.effects[1] = new Effect(ScriptableObject.CreateInstance<ApplyScarsEffect>(), 2, null, Slots.Self, null);
            ability2.effects[2] = new Effect(ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, null, Slots.Self, null);
            ability2.visuals = LoadedAssetsHandler.GetEnemyAbility("Blush_A").visuals;
            ability2.animationTarget = Slots.Self;
            Ability ability3 = new Ability();
            ability3.name = "Weak Shards";
            ability3.description = "Deal 5 damage to the opposing enemy, increasing by 2 for each point of Fragile.";
            ability3.cost = new ManaColorSO[]
            {
                Pigments.Red,
                Pigments.Red,
                Pigments.Blue
            };
            ability3.sprite = ResourceLoader.LoadSprite("Shards", 1, null);
            ability3.effects = new Effect[1];
            ability3.effects[0] = new Effect(directPlusStoredValue2Effect, 5, new IntentType?((IntentType)1), Slots.Front, null);
            ability3.visuals = LoadedAssetsHandler.GetEnemyAbility("MarrowToucher_A").visuals;
            ability3.animationTarget = Slots.Front;
            Ability ability4 = ability3.Duplicate();
            ability4.name = "Dainty Shards";
            ability4.description = "Deal 7 damage to the opposing enemy, increasing by 2 for each point of Fragile.";
            ability4.effects[0]._entryVariable = 7;
            ability4.effects[0]._intent = new IntentType?((IntentType)2);
            Ability ability5 = ability4.Duplicate();
            ability5.name = "Delicate Shards";
            ability5.description = "Deal 9 damage to the opposing enemy, increasing by 2 for each point of Fragile.";
            ability5.effects[0]._entryVariable = 9;
            Ability ability6 = ability5.Duplicate();
            ability6.name = "Fragile Shards";
            ability6.description = "Deal 9 damage to the opposing enemy, increasing by 3 for each point of Fragile.";
            ability6.effects[0]._effect = directPlusStoredValue2Effect2;
            Ability ability7 = new Ability();
            ability7.name = "Smooth over the Scratches";
            ability7.description = "Apply 1 Gutted to the left and right allies and heal them for 2 + 1 for each point of Fragile.";
            ability7.cost = new ManaColorSO[]
            {
                Pigments.Blue,
                Pigments.Blue,
                Pigments.Blue
            };
            ability7.sprite = ResourceLoader.LoadSprite("scratches", 1, null);
            ability7.effects = new Effect[2];
            ability7.effects[0] = new Effect(ScriptableObject.CreateInstance<ApplyGuttedEffect>(), 1, new IntentType?((IntentType)987893), Slots.Sides, null);
            ability7.effects[1] = new Effect(customHealPlusStoredValueEffect, 2, new IntentType?((IntentType)20), Slots.Sides, null);
            ability7.visuals = LoadedAssetsHandler.GetCharacterAbility("Weave_1_A").visuals;
            ability7.animationTarget = Slots.Sides;
            Ability ability8 = ability7.Duplicate();
            ability8.name = "Smooth over the Cuts";
            ability8.description = "Apply 1 Gutted to the left and right allies and heal them for 3 + 1 for each point of Fragile.";
            ability8.cost = new ManaColorSO[]
            {
                Pigments.SplitPigment(Pigments.Yellow, Pigments.Blue),
                Pigments.Blue,
                Pigments.Blue
            };
            ability8.effects[1]._entryVariable = 3;
            Ability ability9 = ability8.Duplicate();
            ability9.name = "Smooth over the Lesions";
            ability9.description = "Apply 1 Gutted to the left and right allies and heal them for 4 + 1 for each point of Fragile.";
            ability9.effects[1]._entryVariable = 4;
            Ability ability10 = ability9.Duplicate();
            ability10.name = "Smooth over the Lacerations";
            ability10.description = "Apply 1 Gutted to the left and right allies and heal them for 6 + 1 for each point of Fragile.";
            ability10.effects[1]._entryVariable = 6;
            ability10.effects[1]._intent = new IntentType?((IntentType)21);
            Ability ability11 = new Ability();
            ability11.name = "Strange Reflections";
            ability11.description = "Apply 1 scar to the opposing enemy. 10% multiplied by all points of Fragile chance to apply a second scar. 5% multiplied by all points of Fragile chance to apply a third. \nDeal 5 damage to the opposing enemy.";
            ability11.cost = new ManaColorSO[]
            {
                Pigments.Red,
                Pigments.Yellow,
                Pigments.Blue
            };
            ability11.sprite = ResourceLoader.LoadSprite("ReflectionScars", 1, null);
            ability11.effects = new Effect[4];
            ability11.effects[0] = new Effect(ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, new IntentType?((IntentType)159), Slots.Front, null);
            ability11.effects[1] = new Effect(applyScarsPercentValueEffect, 10, new IntentType?((IntentType)159), Slots.Front, null);
            ability11.effects[2] = new Effect(applyScarsPercentValueEffect, 5, new IntentType?((IntentType)159), Slots.Front, null);
            ability11.effects[3] = new Effect(ScriptableObject.CreateInstance<DamageEffect>(), 5, new IntentType?((IntentType)1), Slots.Front, null);
            ability11.visuals = LoadedAssetsHandler.GetEnemyAbility("UglyOnTheInside_A").visuals;
            ability11.animationTarget = Slots.Front;
            Ability ability12 = ability11.Duplicate();
            ability12.name = "Gross Reflections";
            ability12.description = "Apply 1 scar to the opposing enemy. 15% multiplied by all points of Fragile chance to apply a second scar. 8% multiplied by all points of Fragile chance to apply a third.  \nDeal 7 damage to the opposing enemy.";
            ability12.effects[1]._entryVariable = 15;
            ability12.effects[2]._entryVariable = 8;
            ability12.effects[3]._entryVariable = 7;
            ability12.effects[3]._intent = new IntentType?((IntentType)2);
            Ability ability13 = ability12.Duplicate();
            ability13.name = "Distrorted Reflections";
            ability13.description = "Apply 1 scar to the opposing enemy. 20% multiplied by all points of Fragile chance to apply a second scar. 10% multiplied by all points of Fragile chance to apply a third. \nDeal 9 damage to the opposing enemy.";
            ability13.cost = new ManaColorSO[]
            {
                Pigments.Red,
                Pigments.SplitPigment(Pigments.Red, Pigments.Yellow),
                Pigments.Blue
            };
            ability13.effects[1]._entryVariable = 20;
            ability13.effects[2]._entryVariable = 10;
            ability13.effects[3]._entryVariable = 9;
            Ability ability14 = ability13.Duplicate();
            ability14.name = "Incomprehensible Reflections";
            ability14.description = "Apply 1 scar to the opposing enemy. 25% multiplied by all points of Fragile chance to apply a second scar. 13% multiplied by all points of Fragile chance to apply a third. \nDeal 11 damage to the opposing enemy.";
            ability14.effects[1]._entryVariable = 25;
            ability14.effects[2]._entryVariable = 13;
            ability14.effects[3]._entryVariable = 11;
            ability14.effects[3]._intent = new IntentType?((IntentType)3);
            character.AddLevel(4, new Ability[]
            {
                ability3,
                ability7,
                ability11
            }, 0);
            character.AddLevel(4, new Ability[]
            {
                ability4,
                ability8,
                ability12
            }, 1);
            character.AddLevel(4, new Ability[]
            {
                ability5,
                ability9,
                ability13
            }, 2);
            character.AddLevel(4, new Ability[]
            {
                ability6,
                ability10,
                ability14
            }, 3);
            character.usesAllAbilities = false;
            CluelessFools.Julios = character;
            character.AddCharacter();
            EffectItem effectItem = new EffectItem();
            effectItem.name = "Stained Glass Shard";
            effectItem.flavorText = "\"Shines with the colors of your kin\"";
            effectItem.description = "Deal 40% more damage when Ruptured.";
            effectItem.sprite = ResourceLoader.LoadSprite("Glass", 32, null);
            effectItem.trigger = (TriggerCalls)16;
            effectItem.triggerConditions = new EffectorConditionSO[]
            {
                ScriptableObject.CreateInstance<IfRupturedDamageUpCondition>()
            };
            effectItem.consumeTrigger = (TriggerCalls)1000;
            effectItem.unlockableID = (UnlockableID)2333543;
            effectItem.namePopup = false;
            effectItem.consumedOnUse = false;
            effectItem.itemPools = ItemPools.Treasure;
            effectItem.shopPrice = 7;
            effectItem.immediate = true;
            new FoolBossUnlockSystem.FoolItemPairs(character, new EffectItem
            {
                name = "Sevo's Scarf",
                flavorText = "\"Dearest Sevo, mourn not for me...\"",
                description = "All damage received by this party member is reduced to 1. 70% chance to destroy this item upon taking damage.",
                sprite = ResourceLoader.LoadSprite("Scarf", 32, null),
                trigger = (TriggerCalls)6,
                triggerConditions = new EffectorConditionSO[]
                {
                    ScriptableObject.CreateInstance<TemperedEffectorCondition>()
                },
                consumeTrigger = (TriggerCalls)5,
                consumeConditions = new EffectorConditionSO[]
                {
                    ChanceCondition.Chance(70)
                },
                unlockableID = (UnlockableID)3233543,
                namePopup = true,
                consumedOnUse = false,
                itemPools = ItemPools.Treasure,
                shopPrice = 8,
                immediate = true
            }, effectItem, 0, 0).Add();
            new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement)3233543, (AchievementUnlockType)5, "Sevo's Scarf", "Unlocked a new item.", ResourceLoader.LoadSprite("AchHeaven.png", 32, null), false, "").Prepare(character.entityID, (BossType)10);
            new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement)2333543, (AchievementUnlockType)4, "Stained Glass Shard", "Unlocked a new item.", ResourceLoader.LoadSprite("AchOsman.png", 32, null), false, "").Prepare(character.entityID, (BossType)9);
        }

        public static string AddStoredValueName(
      Func<TooltipTextHandlerSO, UnitStoredValueNames, int, string> orig,
      TooltipTextHandlerSO self,
      UnitStoredValueNames storedValue,
      int value)
    {
      Color red = Color.red;
      string str1;
      if (storedValue == (UnitStoredValueNames)2233445)
      {
        if (value <= 0)
        {
          str1 = "";
        }
        else
        {
          string str2 = "Fragile" + string.Format(" +{0}", (object) value);
          string str3 = "<color=#" + ColorUtility.ToHtmlStringRGB(Color.green) + ">";
          string str4 = "</color>";
          str1 = str3 + str2 + str4;
        }
      }
      else
        str1 = orig(self, storedValue, value);
      return str1;
    }

    private static void GuttedIntent(Action<IntentHandlerSO> orig, IntentHandlerSO self)
    {
      orig(self);
      CluelessFools.guttedIntent._type = (IntentType) 987893;
      CluelessFools.guttedIntent._sprite = ResourceLoader.LoadSprite("GuttedIcon", 32);
      CluelessFools.guttedIntent._color = Color.white;
      CluelessFools.guttedIntent._sound = self._intentDB[(IntentType) 159]._sound;
      IntentInfo intentInfo;
      self._intentDB.TryGetValue((IntentType) 987893, out intentInfo);
      if (intentInfo != null)
        return;
      self._intentDB.Add((IntentType) 987893, CluelessFools.guttedIntent);
    }
  }
}
