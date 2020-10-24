﻿// Decompiled with JetBrains decompiler
// Type: DuckGame.NetIndex8
// Assembly: DuckGame, Version=1.0.7567.18440, Culture=neutral, PublicKeyToken=null
// MVID: 141E8A2E-D79A-4662-B1CF-5A369FF52288
// Assembly location: C:\Users\Tristan Kreindler\Documents\Duck Game\Duck Game\DuckGame.exe

using System;
using System.Diagnostics;

namespace DuckGame
{
  [DebuggerDisplay("Index = {_index}")]
  public struct NetIndex8 : IComparable
  {
    public int _index;
    public int max;
    private bool _zeroSpecial;

    public override string ToString() => Convert.ToString(this._index);

    public static int MaxForBits(int bits)
    {
      int num = 0;
      for (int index = 0; index < bits; ++index)
        num |= 1 << index;
      return num;
    }

    public NetIndex8(int index = 1, bool zeroSpecial = true)
    {
      this._index = index;
      this._zeroSpecial = false;
      this.max = NetIndex8.MaxForBits(8);
    }

    public void Increment() => this._index = this.Mod(this._index + 1);

    public int Mod(int val) => this._zeroSpecial ? Math.Max(val % this.max, 1) : val % this.max;

    public int CompareTo(object obj)
    {
      if (obj == null)
        return 1;
      if (obj is NetIndex8 netIndex8)
      {
        if (this < netIndex8)
          return -1;
        return this > netIndex8 ? 1 : 0;
      }
      int num = (int) obj;
      if (this < num)
        return -1;
      return this > num ? 1 : 0;
    }

    public static implicit operator NetIndex8(int val) => new NetIndex8(val);

    public static implicit operator int(NetIndex8 val) => val._index;

    public static NetIndex8 operator +(NetIndex8 c1, int c2)
    {
      c1._index = c1.Mod(c1._index + c2);
      return c1;
    }

    public static NetIndex8 operator ++(NetIndex8 c1)
    {
      c1._index = c1.Mod(c1._index + 1);
      return c1;
    }

    public static bool operator <(NetIndex8 c1, NetIndex8 c2)
    {
      int num1 = ((int) c1 - c1.max / 2) % c1.max;
      if (num1 < 0)
        num1 = c1.max + num1;
      int num2 = c1.max - num1;
      return (c1._index + num2) % c1.max < (c2._index + num2) % c1.max;
    }

    public static bool operator >(NetIndex8 c1, NetIndex8 c2) => (int) c1 > (int) c2;

    public static bool operator <(NetIndex8 c1, int c2)
    {
      int num1 = ((int) c1 - c1.max / 2) % c1.max;
      if (num1 < 0)
        num1 = c1.max + num1;
      int num2 = c1.max - num1;
      return (c1._index + num2) % c1.max < (c2 + num2) % c1.max;
    }

    public static int Difference(NetIndex8 c1, NetIndex8 c2)
    {
      int num1 = ((int) c1 - c1.max / 2) % c1.max;
      if (num1 < 0)
        num1 = c1.max + num1;
      int num2 = c1.max - num1;
      return Math.Abs((c1._index + num2) % c1.max - (int) (c2 + num2) % c1.max);
    }

    public static bool operator >(NetIndex8 c1, int c2) => (int) c1 > c2;

    public static bool operator ==(NetIndex8 c1, NetIndex8 c2) => c1._index == c2._index;

    public static bool operator !=(NetIndex8 c1, NetIndex8 c2) => c1._index != c2._index;

    public static bool operator ==(NetIndex8 c1, int c2) => c1._index == c2;

    public static bool operator !=(NetIndex8 c1, int c2) => c1._index != c2;

    public override bool Equals(object obj) => this.CompareTo(obj) == 0;

    public override int GetHashCode() => this._index.GetHashCode();
  }
}
