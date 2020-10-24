﻿// Decompiled with JetBrains decompiler
// Type: DuckGame.DCSwordAdventure
// Assembly: DuckGame, Version=1.0.7567.18440, Culture=neutral, PublicKeyToken=null
// MVID: 141E8A2E-D79A-4662-B1CF-5A369FF52288
// Assembly location: C:\Users\Tristan Kreindler\Documents\Duck Game\Duck Game\DuckGame.exe

using System;

namespace DuckGame
{
  public class DCSwordAdventure : DeathCrateSetting
  {
    public override void Activate(DeathCrate c, bool server = true)
    {
      float x = c.x;
      float ypos = c.y - 2f;
      Level.Add((Thing) new ExplosionPart(x, ypos));
      int num1 = 6;
      if (Graphics.effectsLevel < 2)
        num1 = 3;
      for (int index = 0; index < num1; ++index)
      {
        float deg = (float) index * 60f + Rando.Float(-10f, 10f);
        float num2 = Rando.Float(12f, 20f);
        Level.Add((Thing) new ExplosionPart(x + (float) Math.Cos((double) Maths.DegToRad(deg)) * num2, ypos - (float) Math.Sin((double) Maths.DegToRad(deg)) * num2));
      }
      if (server)
      {
        for (int index = 0; index < 8; ++index)
        {
          Sword sword = new Sword(c.x, c.y);
          float num2 = (float) index / 7f;
          sword.hSpeed = (float) ((double) num2 * 30.0 - 15.0) * Rando.Float(0.5f, 1f);
          sword.vSpeed = Rando.Float(-10f, 10f);
          sword._wasLifted = true;
          sword._framesExisting = 16;
          Level.Add((Thing) sword);
        }
        Level.Remove((Thing) c);
      }
      Graphics.FlashScreen();
      SFX.Play("explode");
    }
  }
}
