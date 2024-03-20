// Decompiled with JetBrains decompiler
// Type: Julios.FortyPercentUpValueModifier
// Assembly: Julios, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3E760DF5-48A7-4D53-B202-D773C9554515
// Assembly location: C:\Users\windows\Downloads\Julios.dll

using System;

#nullable disable
namespace Julios
{
  public class FortyPercentUpValueModifier : IntValueModifier
  {
    public FortyPercentUpValueModifier()
      : base(70)
    {
    }

    public override int Modify(int value)
    {
      float num = 1.4f;
      value = (int) Math.Ceiling((double) ((float) value * num));
      return value;
    }
  }
}
