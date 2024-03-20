// Decompiled with JetBrains decompiler
// Type: Julios.CluelessFools
// Assembly: Julios, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3E760DF5-48A7-4D53-B202-D773C9554515
// Assembly location: C:\Users\windows\Downloads\Julios.dll

using BepInEx;
using BrutalAPI;
using System;
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
      // ISSUE: unable to decompile the method.
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
