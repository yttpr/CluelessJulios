// Decompiled with JetBrains decompiler
// Type: Julios.CasterCheckStoredValueCondition
// Assembly: Julios, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3E760DF5-48A7-4D53-B202-D773C9554515
// Assembly location: C:\Users\windows\Downloads\Julios.dll

#nullable disable
namespace Julios
{
  public class CasterCheckStoredValueCondition : EffectConditionSO
  {
    public UnitStoredValueNames _valueName = (UnitStoredValueNames)(-1);
    public int minimumAmount = 1;

    public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
    {
      return caster.GetStoredValue(this._valueName) > 3;
    }
  }
}
