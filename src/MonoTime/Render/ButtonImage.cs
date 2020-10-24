﻿// Decompiled with JetBrains decompiler
// Type: DuckGame.ButtonImage
// Assembly: DuckGame, Version=1.0.7567.18440, Culture=neutral, PublicKeyToken=null
// MVID: 141E8A2E-D79A-4662-B1CF-5A369FF52288
// Assembly location: C:\Users\Tristan Kreindler\Documents\Duck Game\Duck Game\DuckGame.exe

namespace DuckGame
{
  public class ButtonImage : Sprite
  {
    private BitmapFont _font;
    private Sprite _keySprite;
    private string _keyString;

    public ButtonImage(char key)
    {
      this._font = new BitmapFont("tinyNumbers", 4, 5);
      this._keySprite = new Sprite("buttons/genericButton");
      this._keyString = ((int) key).ToString() ?? "";
      this._texture = this._keySprite.texture;
    }

    public override void Draw()
    {
      this._keySprite.position = this.position;
      this._keySprite.alpha = this.alpha;
      this._keySprite.color = this.color;
      this._keySprite.depth = this.depth;
      this._keySprite.Draw();
      this._font.Draw(this._keyString, this.position + new Vec2((float) (this._keySprite.width / 2) - this._font.GetWidth(this._keyString) / 2f, 4f), new Color(20, 32, 34), this.depth + 2);
    }
  }
}
