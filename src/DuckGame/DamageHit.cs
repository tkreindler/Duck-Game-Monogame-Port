﻿// Decompiled with JetBrains decompiler
// Type: DuckGame.DamageHit
// Assembly: DuckGame, Version=1.0.7567.18440, Culture=neutral, PublicKeyToken=null
// MVID: 141E8A2E-D79A-4662-B1CF-5A369FF52288
// Assembly location: C:\Users\Tristan Kreindler\Documents\Duck Game\Duck Game\DuckGame.exe

using System.Collections.Generic;

namespace DuckGame
{
  public class DamageHit
  {
    public Thing thing;
    public List<Vec2> points = new List<Vec2>();
    public List<DamageType> types = new List<DamageType>();
  }
}
