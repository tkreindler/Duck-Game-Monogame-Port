﻿// Decompiled with JetBrains decompiler
// Type: DuckGame.ATMag
// Assembly: DuckGame, Version=1.0.7567.18440, Culture=neutral, PublicKeyToken=null
// MVID: 141E8A2E-D79A-4662-B1CF-5A369FF52288
// Assembly location: C:\Users\Tristan Kreindler\Documents\Duck Game\Duck Game\DuckGame.exe

namespace DuckGame
{
  public class ATMag : AmmoType
  {
    public bool angleShot = true;

    public ATMag()
    {
      this.accuracy = 0.95f;
      this.range = 250f;
      this.penetration = 1f;
      this.bulletSpeed = 40f;
      this.bulletThickness = 0.3f;
      this.bulletType = typeof (MagBullet);
      this.combustable = true;
    }
  }
}
