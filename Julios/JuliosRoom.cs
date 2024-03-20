// Decompiled with JetBrains decompiler
// Type: Julios.JuliosRoom
// Assembly: Julios, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3E760DF5-48A7-4D53-B202-D773C9554515
// Assembly location: C:\Users\windows\Downloads\Julios.dll

using BrutalAPI;
using System.Linq;
using Tools;
using UnityEngine;

#nullable disable
namespace Julios
{
  public static class JuliosRoom
  {
    private static GameObject Base;
    private static NPCRoomHandler Room;
    private static DialogueSO Dialogue;
    private static FreeFoolEncounterSO Free;
    private static SpeakerBundle bundle;
    private static SpeakerData speaker;

    private static string Name => "Julios";

    private static string Files => "Julios_CH";

    private static Character chara => CluelessFools.Julios;

    private static int Zone => 0;

    private static bool Left => true;

    private static bool Center => true;

    private static string roomName => JuliosRoom.Name + "Room";

    private static string convoName => JuliosRoom.Name + "Convo";

    private static string encounterName => JuliosRoom.Name + "Encounter";

    private static Sprite Talk => JuliosRoom.chara.frontSprite;

    private static Sprite Portal => JuliosRoom.chara.unlockedSprite;

    private static string Audio => JuliosRoom.chara.dialogueSound;

    private static int ID => (int) JuliosRoom.chara.entityID;

    public static void Setup()
    {
      BrutalAPI.BrutalAPI.AddSignType((SignType) JuliosRoom.ID, JuliosRoom.Portal);
      JuliosRoom.Base = Backrooms.Assets.LoadAsset<GameObject>("Assets/" + JuliosRoom.Name + "Room.prefab");
      JuliosRoom.Room = JuliosRoom.Base.AddComponent<NPCRoomHandler>();
      JuliosRoom.Room._npcSelectable = (BaseRoomItem) ((Component) ((Component) JuliosRoom.Room).transform.GetChild(0)).gameObject.AddComponent<BasicRoomItem>();
      JuliosRoom.Room._npcSelectable._renderers = new SpriteRenderer[1]
      {
        ((Component) ((Component) JuliosRoom.Room._npcSelectable).transform.GetChild(0)).GetComponent<SpriteRenderer>()
      };
      ((Renderer) JuliosRoom.Room._npcSelectable._renderers[0]).material = Backrooms.Mat;
      DialogueSO instance1 = ScriptableObject.CreateInstance<DialogueSO>();
      ((Object) instance1).name = JuliosRoom.convoName;
      instance1.dialog = Backrooms.Yarn;
      instance1.startNode = "Clueless." + JuliosRoom.Name + ".TryHire";
      JuliosRoom.Dialogue = instance1;
      FreeFoolEncounterSO instance2 = ScriptableObject.CreateInstance<FreeFoolEncounterSO>();
      ((Object) instance2).name = JuliosRoom.encounterName;
      ((BasicEncounterSO) instance2)._dialogue = JuliosRoom.convoName;
      ((BasicEncounterSO) instance2).encounterRoom = JuliosRoom.roomName;
      instance2._freeFool = JuliosRoom.Files;
      ((BasicEncounterSO) instance2).signType = (SignType) JuliosRoom.ID;
      ((BasicEncounterSO) instance2).npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) JuliosRoom.ID
      };
      JuliosRoom.Free = instance2;
      JuliosRoom.bundle = new SpeakerBundle()
      {
        dialogueSound = JuliosRoom.Audio,
        portrait = JuliosRoom.Talk
      };
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = JuliosRoom.Name + PathUtils.speakerDataSuffix;
      ((Object) instance3).name = JuliosRoom.Name + PathUtils.speakerDataSuffix;
      instance3._defaultBundle = JuliosRoom.bundle;
      instance3.portraitLooksLeft = JuliosRoom.Left;
      instance3.portraitLooksCenter = JuliosRoom.Center;
      JuliosRoom.speaker = instance3;
    }

    public static void Add()
    {
      if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains<string>(PathUtils.encounterRoomsResPath + JuliosRoom.roomName))
        LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + JuliosRoom.roomName, (BaseRoomHandler) JuliosRoom.Room);
      else
        LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + JuliosRoom.roomName] = (BaseRoomHandler) JuliosRoom.Room;
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(JuliosRoom.convoName))
        LoadedAssetsHandler.LoadedDialogues.Add(JuliosRoom.convoName, JuliosRoom.Dialogue);
      else
        LoadedAssetsHandler.LoadedDialogues[JuliosRoom.convoName] = JuliosRoom.Dialogue;
      if (!LoadedAssetsHandler.LoadedFreeFoolEncounters.Keys.Contains<string>(JuliosRoom.encounterName))
        LoadedAssetsHandler.LoadedFreeFoolEncounters.Add(JuliosRoom.encounterName, JuliosRoom.Free);
      else
        LoadedAssetsHandler.LoadedFreeFoolEncounters[JuliosRoom.encounterName] = JuliosRoom.Free;
      Backrooms.AddPool(JuliosRoom.encounterName, JuliosRoom.Zone);
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(JuliosRoom.speaker.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(JuliosRoom.speaker.speakerName, JuliosRoom.speaker);
      else
        LoadedAssetsHandler.LoadedSpeakers[JuliosRoom.speaker.speakerName] = JuliosRoom.speaker;
    }
  }
}
