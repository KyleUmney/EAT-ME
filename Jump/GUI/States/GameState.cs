using Backend.Managers;
using Backend.Models;
using GUI.Views;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.States
{
  internal class GameState : State
  {
    private ScoreView _scoreView;
    private Score _score;

    private Stats _playerStats;
    private StatsView _statsView;

    private UpgradesManager _upgradesManager;

    public GameState(Game game, ContentManager content) : base(game, content)
    {
    }

    public override void LoadContent()
    {
      var font = _content.Load<SpriteFont>("Fonts/Default");

      _score = new Score();
      _scoreView = new ScoreView(_score, font)
      {
        Colour = Color.Black,
        Position = new Vector2(Game1.screenWidth / 2, 20),
      };

      _playerStats = new Stats();
      _statsView = new StatsView(_playerStats, font)
      {
        Colour = Color.Black,
        Position = new Vector2(Game1.screenWidth / 2, 60),
      };

      _upgradesManager = new UpgradesManager();
      _upgradesManager.LoadUpgrades();
    }



    public override void Update(GameTime gameTime)
    {
      if (Keyboard.GetState().IsKeyDown(Keys.Left))
        _score.Value--;

      if (Keyboard.GetState().IsKeyDown(Keys.Right))
        _score.Value++;
    }
    public override void PostUpdate(GameTime gameTime)
    {

    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
      spriteBatch.Begin();
      _scoreView.Draw(gameTime, spriteBatch);
      spriteBatch.End();
    }
  }
}
