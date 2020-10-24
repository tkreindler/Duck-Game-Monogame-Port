﻿// Decompiled with JetBrains decompiler
// Type: DuckGame.WaterFallTile
// Assembly: DuckGame, Version=1.0.7567.18440, Culture=neutral, PublicKeyToken=null
// MVID: 141E8A2E-D79A-4662-B1CF-5A369FF52288
// Assembly location: C:\Users\Tristan Kreindler\Documents\Duck Game\Duck Game\DuckGame.exe

namespace DuckGame
{
  [EditorGroup("details")]
  public class WaterFallTile : Thing
  {
    public WaterFallTile(float xpos, float ypos)
      : base(xpos, ypos)
    {
      this.graphic = (Sprite) new SpriteMap("waterFallTile", 16, 16);
      this.center = new Vec2(8f, 8f);
      this._collisionSize = new Vec2(16f, 16f);
      this._collisionOffset = new Vec2(-8f, -8f);
      this.layer = Layer.Foreground;
      this.depth = (Depth) 0.9f;
      this.alpha = 0.8f;
    }

    public override void Draw()
    {
      (this.graphic as SpriteMap).frame = WaterFlow.waterFrame;
      this.graphic.flipH = this.offDir <= (sbyte) 0;
      base.Draw();
    }
  }
}
