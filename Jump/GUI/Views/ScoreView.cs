using Backend.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Views
{
  public class ScoreView
  {
    private Score score;
    private SpriteFont font;
    public Vector2 Position;
    public Color Colour;

    public ScoreView(Score score, SpriteFont font)
    {
      this.score = score;
      this.font = font;
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
      spriteBatch.DrawString(font, $"Score: {score.Value}", Position, Colour);
    }
  }
}
