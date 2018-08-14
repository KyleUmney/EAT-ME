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

    public float Scale { get; set; }

    public bool IsRemoved { get; set; }

    public int Score { get; set; }

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
        return new Rectangle((int)Position.X - (int)(Origin.X * Scale), (int)Position.Y - (int)(Origin.Y * Scale), (int)(_texture.Width * Scale), (int)(_texture.Height * Scale));
      }
    }

    public Sprite(Texture2D texture)
    {
      _texture = texture;

      Children = new List<Sprite>();

      Colour = Color.White;

      Scale = 1f;
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
      spriteBatch.Draw(_texture, Position, null, Colour, _rotation, Origin, Scale, SpriteEffects.None, Layer);
    }

    public override void Update(GameTime gameTime)
    {

    }

    public virtual bool OnEnter(Sprite sprite)
    {
      return false;
    }

    public virtual bool OnExit(Sprite sprite)
    {
      return false;
    }

    public object Clone()
    {
      return this.MemberwiseClone();
    }
  }
}
