using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Jump.Sprites
{
  class Player : Sprite
  {
    public Player(Texture2D texture) : base(texture)
    {
    }

    public override void Update(GameTime gameTime)
    {
      Speed = 5f;

      var direction = new Vector2((float)Math.Cos(_rotation - MathHelper.ToRadians(+90)), (float)Math.Sin(_rotation - MathHelper.ToRadians(+90)));

      _rotation = (float)Math.Atan2(direction.X, direction.Y);

      if (Keyboard.GetState().IsKeyDown(Keys.Up))
        Position.Y += _rotation * Speed;

      if (Keyboard.GetState().IsKeyDown(Keys.Down))
        Position.Y -= _rotation * Speed;

      if (Keyboard.GetState().IsKeyDown(Keys.Right))
        Position.X -= _rotation * Speed;

      if (Keyboard.GetState().IsKeyDown(Keys.Left))
        Position.X += _rotation * Speed;

      Position = Vector2.Clamp(Position, new Vector2(0 + _texture.Width, 0 + _texture.Height), new Vector2(1280 - _texture.Width, 720 - _texture.Height));

      base.Update(gameTime);
    }

    private List<Sprite> _enteredSprites = new List<Sprite>();

    public override bool OnEnter(Sprite sprite)
    {
      if (_enteredSprites.Contains(sprite))
        return false;

      if (!this.Rectangle.Intersects(sprite.Rectangle))
        return false;

      _enteredSprites.Add(sprite);

      if (sprite is TestEnemy)
      {
        Scale -= 0.50f;
      }

      return true;
    }

    public override bool OnExit(Sprite sprite)
    {
      if (this.Rectangle.Intersects(sprite.Rectangle))
        return false;

      _enteredSprites.Remove(sprite);

      return true;
    }
  }
}
