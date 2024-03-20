// Decompiled with JetBrains decompiler
// Type: Julios.ChanceCondition
// Assembly: Julios, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3E760DF5-48A7-4D53-B202-D773C9554515
// Assembly location: C:\Users\windows\Downloads\Julios.dll

using UnityEngine;

#nullable disable
namespace Julios
{
  public class ChanceCondition : EffectorConditionSO
  {
    public int chance;

    public static ChanceCondition Chance(int num)
    {
      ChanceCondition instance = ScriptableObject.CreateInstance<ChanceCondition>();
      instance.chance = num;
      return instance;
    }

    public override bool MeetCondition(IEffectorChecks effector, object args)
    {
      return Random.Range(0, 100) < this.chance;
    }
  }
}
