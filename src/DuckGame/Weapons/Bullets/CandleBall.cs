﻿// Decompiled with JetBrains decompiler
// Type: DuckGame.CandleBall
// Assembly: DuckGame, Version=1.0.7567.18440, Culture=neutral, PublicKeyToken=null
// MVID: 141E8A2E-D79A-4662-B1CF-5A369FF52288
// Assembly location: C:\Users\Tristan Kreindler\Documents\Duck Game\Duck Game\DuckGame.exe

using System.Collections.Generic;
using System.Linq;

namespace DuckGame
{
  public class CandleBall : PhysicsObject, IPlatform
  {
    private SpriteMap _sprite;
    private FlareGun _owner;
    private int _numFlames;

    public CandleBall(float xpos, float ypos, FlareGun owner, int numFlames = 8)
      : base(xpos, ypos)
    {
      this._sprite = new SpriteMap("candleBall", 16, 16);
      this._sprite.AddAnimation("burn", (float) (0.400000005960464 + (double) Rando.Float(0.2f)), true, 0, 1);
      this._sprite.SetAnimation("burn");
      this._sprite.imageIndex = Rando.Int(4);
      this.graphic = (Sprite) this._sprite;
      this.center = new Vec2(8f, 8f);
      this.collisionOffset = new Vec2(-4f, -2f);
      this.collisionSize = new Vec2(9f, 4f);
      this.depth = new Depth(0.9f);
      this.thickness = 1f;
      this.weight = 1f;
      this.breakForce = 1E+08f;
      this._owner = owner;
      this.weight = 0.5f;
      this.gravMultiplier = 0.7f;
      this._numFlames = numFlames;
      Color[] colorArray = new Color[4]
      {
        Color.Red,
        Color.Green,
        Color.Blue,
        Color.Orange
      };
      this._sprite.color = colorArray[Rando.Int(((IEnumerable<Color>) colorArray).Count<Color>() - 1)];
      this.xscale = this.yscale = Rando.Float(0.4f, 0.8f);
    }

    protected override bool OnDestroy(DestroyType type = null)
    {
      if (this.isServerForObject)
      {
        for (int index = 0; index < this._numFlames; ++index)
          Level.Add((Thing) SmallFire.New(this.x - this.hSpeed, this.y - this.vSpeed, Rando.Float(6f) - 3f, Rando.Float(6f) - 3f, firedFrom: ((Thing) this)));
      }
      SFX.Play("flameExplode", 0.9f, Rando.Float(0.2f) - 0.1f);
      Level.Remove((Thing) this);
      return true;
    }

    public override void Update()
    {
      if ((double) Rando.Float(2f) < 0.300000011920929)
        this.vSpeed += Rando.Float(3.5f) - 2f;
      if ((double) Rando.Float(9f) < 0.100000001490116)
        this.vSpeed += Rando.Float(3.1f) - 3f;
      if ((double) Rando.Float(14f) < 0.100000001490116)
        this.vSpeed += Rando.Float(4f) - 5f;
      if ((double) Rando.Float(25f) < 0.100000001490116)
        this.vSpeed += Rando.Float(6f) - 7f;
      Level.Add((Thing) SmallSmoke.New(this.x, this.y));
      if ((double) this.hSpeed > 0.0)
        this._sprite.angleDegrees = 90f;
      else if ((double) this.hSpeed < 0.0)
        this._sprite.angleDegrees = -90f;
      base.Update();
    }

    public override void OnImpact(MaterialThing with, ImpactedFrom from)
    {
      if (!this.isServerForObject || with == this._owner || (with is Gun || (double) with.weight < 5.0))
        return;
      if (with is PhysicsObject)
      {
        with.hSpeed = this.hSpeed / 4f;
        --with.vSpeed;
      }
      this.Destroy((DestroyType) new DTImpact((Thing) null));
      with.Burn(this.position, (Thing) this);
    }
  }
}
