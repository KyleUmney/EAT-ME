using Backend.Models;
using GUI.Views;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Controls
{
  public class HUD
  {
    private ScoreView _scoreView;

    private StatsView _statsView;

    public HUD(ContentManager content, Score score, Stats stats)
    {
      var font = content.Load<SpriteFont>("Fonts/Default");

      _scoreView = new ScoreView(score, font)
      {
        Colour = Color.Black,
        Position = new Vector2(Game1.screenWidth / 2, 20),
      };

      _statsView = new StatsView(stats, font)
      {
        Colour = Color.Black,
        Position = new Vector2(Game1.screenWidth / 2, 60),
      };

    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
      spriteBatch.Begin();
      _scoreView.Draw(gameTime, spriteBatch);
      _statsView.Draw(gameTime, spriteBatch);
      spriteBatch.End();
    }
  }
}
