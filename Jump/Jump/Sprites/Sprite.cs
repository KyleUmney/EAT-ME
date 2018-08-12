using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jump.Sprites
{
  public class Sprite : Component, ICloneable
  {
    protected Texture2D _texture;

    protected float _rotation;

    public Color Colour { get; set; }

    public float Layer { get; set; }

    public float Speed { get; set; }

    public bool IsRemoved { get; set; }

    public List<Sprite> Children { get; set; }

    public Sprite Parent;
    public List<Sprite> Sprites { get; set; }

    public Random rnd;

    public List<Vector2> _wayPoints = new List<Vector2>
    {
      new Vector2(1250,Game1.screenHeight /2),
      new Vector2(30,Game1.screenHeight /2),
    };

    public Vector2 Origin
    {
      get
      {
        return new Vector2(_texture.Width / 2, _texture.Height / 2);
      }
    }

    public Vector2 Position;

    public Rectangle Rectangle
    {
      get
      {
        return new Rectangle((int)Position.X - (int)Origin.X, (int)Position.Y - (int)Origin.Y, _texture.Width, _texture.Height);
      }
    }

    public Sprite(Texture2D texture)
    {
      _texture = texture;

      Children = new List<Sprite>();

      Colour = Color.White;
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
      spriteBatch.Draw(_texture, Position, null, Colour, _rotation, Origin, 1f, SpriteEffects.None, Layer);
    }

    public override void Update(GameTime gameTime)
    {

    }

    public object Clone()
    {
      return this.MemberwiseClone();
    }
  }
}
