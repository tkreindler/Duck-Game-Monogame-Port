﻿// Decompiled with JetBrains decompiler
// Type: DuckGame.WallBoots
// Assembly: DuckGame, Version=1.0.7567.18440, Culture=neutral, PublicKeyToken=null
// MVID: 141E8A2E-D79A-4662-B1CF-5A369FF52288
// Assembly location: C:\Users\Tristan Kreindler\Documents\Duck Game\Duck Game\DuckGame.exe

namespace DuckGame
{
  [BaggedProperty("canSpawn", false)]
  [EditorGroup("equipment")]
  public class WallBoots : Boots
  {
    public WallBoots(float xpos, float ypos)
      : base(xpos, ypos)
    {
      this._pickupSprite = new Sprite("walljumpBootsPickup");
      this._sprite = new SpriteMap("walljumpBoots", 32, 32);
      this.graphic = this._pickupSprite;
      this.center = new Vec2(8f, 8f);
      this.collisionOffset = new Vec2(-6f, -6f);
      this.collisionSize = new Vec2(12f, 13f);
      this._equippedDepth = 1;
    }
  }
}
