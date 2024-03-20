// Decompiled with JetBrains decompiler
// Type: Julios.Backrooms
// Assembly: Julios, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3E760DF5-48A7-4D53-B202-D773C9554515
// Assembly location: C:\Users\windows\Downloads\Julios.dll

using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

#nullable disable
namespace Julios
{
  public static class Backrooms
  {
    public static AssetBundle Assets;
    public static YarnProgram Yarn;
    public static Material Mat;
    public const string Path = "Assets/";
    public static string[] Hard = new string[3]
    {
      "ZoneDB_Hard_01",
      "ZoneDB_Hard_02",
      "ZoneDB_Hard_03"
    };
    public static string[] Easy = new string[3]
    {
      "ZoneDB_01",
      "ZoneDB_02",
      "ZoneDB_03"
    };

    public static void Setup()
    {
      IDetour idetour1 = (IDetour) new Hook((MethodBase) typeof (MainMenuController).GetMethod("LoadOldRun", ~BindingFlags.Default), typeof (Backrooms).GetMethod("LoadOldRun", ~BindingFlags.Default));
      IDetour idetour2 = (IDetour) new Hook((MethodBase) typeof (MainMenuController).GetMethod("OnEmbarkPressed", ~BindingFlags.Default), typeof (Backrooms).GetMethod("LoadOldRun", ~BindingFlags.Default));
      Backrooms.Assets = AssetBundle.LoadFromMemory(ResourceLoader.ResourceBinary("assetbundle"));
      Backrooms.Yarn = Backrooms.Assets.LoadAsset<YarnProgram>("Assets/julios.yarn");
      Backrooms.Mat = ((Renderer) ((BaseRoomItem) ((LoadedAssetsHandler.GetRoomPrefab((CardType) 300, LoadedAssetsHandler.GetBasicEncounter("PervertMessiah_Flavour").encounterRoom) as NPCRoomHandler)._npcSelectable as BasicRoomItem))._renderers[0]).material;
      Backrooms.Calibrate();
      Backrooms.Add();
    }

    public static void LoadOldRun(Action<MainMenuController> orig, MainMenuController self)
    {
      orig(self);
      Backrooms.Add();
    }

    public static void Calibrate() => JuliosRoom.Setup();

    public static void Add() => JuliosRoom.Add();

    public static void AddPool(string name, int zone)
    {
      ZoneBGDataBaseSO zoneDb1 = LoadedAssetsHandler.GetZoneDB(Backrooms.Easy[zone]) as ZoneBGDataBaseSO;
      ZoneBGDataBaseSO zoneDb2 = LoadedAssetsHandler.GetZoneDB(Backrooms.Hard[zone]) as ZoneBGDataBaseSO;
      if (!((IEnumerable<string>) zoneDb2._FreeFoolsPool).Contains<string>(name))
        zoneDb2._FreeFoolsPool = new List<string>((IEnumerable<string>) zoneDb2._FreeFoolsPool)
        {
          name
        }.ToArray();
      if (((IEnumerable<string>) zoneDb1._FreeFoolsPool).Contains<string>(name))
        return;
      zoneDb1._FreeFoolsPool = new List<string>((IEnumerable<string>) zoneDb1._FreeFoolsPool)
      {
        name
      }.ToArray();
    }

    public static void MoreFool(string zone)
    {
      CardTypeInfo cardTypeInfo = new CardTypeInfo();
      cardTypeInfo._cardInfo = new CardInfo()
      {
        cardType = (CardType) 204,
        pilePosition = (PilePositionType) 2
      };
      cardTypeInfo._minimumAmount = 40;
      cardTypeInfo._maximumAmount = 40;
      ZoneBGDataBaseSO zoneDb = LoadedAssetsHandler.GetZoneDB(zone) as ZoneBGDataBaseSO;
      zoneDb._deckInfo._possibleCards = new List<CardTypeInfo>((IEnumerable<CardTypeInfo>) zoneDb._deckInfo._possibleCards)
      {
        cardTypeInfo
      }.ToArray();
    }
  }
}
