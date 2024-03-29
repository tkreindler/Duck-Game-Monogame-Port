﻿// Decompiled with JetBrains decompiler
// Type: DuckGame.GreyBlock
// Assembly: DuckGame, Version=1.0.7567.18440, Culture=neutral, PublicKeyToken=null
// MVID: 141E8A2E-D79A-4662-B1CF-5A369FF52288
// Assembly location: C:\Users\Tristan Kreindler\Documents\Duck Game\Duck Game\DuckGame.exe

namespace DuckGame
{
  [EditorGroup("stuff")]
  public class GreyBlock : Block
  {
    public GreyBlock(float xpos, float ypos)
      : base(xpos, ypos)
    {
      this.graphic = new Sprite("greyBlock");
      this.center = new Vec2(8f, 8f);
      this.collisionOffset = new Vec2(-8f, -8f);
      this.collisionSize = new Vec2(16f, 16f);
      this.depth = new Depth(-0.5f);
      this._editorName = "Grey Block";
      this.thickness = 4f;
      this.physicsMaterial = PhysicsMaterial.Metal;
    }
  }
}
