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
  public class StatsView
  {
    private Stats playerStats;
    private SpriteFont font;
    public Vector2 Position;
    public Color Colour;

    public StatsView(Stats stats, SpriteFont font)
    {
      this.playerStats = stats;
      this.font = font;
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
      spriteBatch.DrawString(font, $"Health: {playerStats.Health}", Position, Colour);
    }
  }
}
