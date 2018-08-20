using Backend.Managers;
using Backend.Models;
using GUI.Controls;
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
    private Score _score;
    private Stats _playerStats;

    private HUD _hud;

    private UpgradesManager _upgradesManager;

    public GameState(Game game, ContentManager content) : base(game, content)
    {
    }

    public override void LoadContent()
    {
      var font = _content.Load<SpriteFont>("Fonts/Default");

      _score = new Score();

      _playerStats = new Stats();

      _hud = new HUD(_content, _score, _playerStats);

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
      _hud.Draw(gameTime, spriteBatch);
    }
  }
}
