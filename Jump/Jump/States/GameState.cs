﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Managers;
using Backend.Models;
using GUI.Views;
using Jump.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Jump.States
{
  class GameState : State
  {
    private ScoreView _scoreView;
    private StatsView _statsView;
    private Stats _stats;
    private Score _score;
    public List<Sprite> _sprites;
    public List<Sprite> _playerSprite;
    public List<Sprite> _enemySprite;
    public SpriteFont font;
    private UpgradesManager _upgradeManager;

    public bool CanSpawn = true;
    public float SpawnTimer = 50f;
    public Texture2D Food;
    public Random rnd;
    public GameState(Game1 game, ContentManager content)
      : base(game, content)
    {
    }

    public override void LoadContent()
    {
      Food = _content.Load<Texture2D>("Sprites/Food");
      var playerTexutre = _content.Load<Texture2D>("Sprites/Player");
      var enemyTexture = _content.Load<Texture2D>("Sprites/Enemy");
      font = _content.Load<SpriteFont>("Fonts/Default");
      _score = new Score();

      _scoreView = new ScoreView(_score, font)
      {
        Colour = Color.Black,
        Position = new Vector2(Game1.screenWidth / 2, 20),
      };

      _stats = new Stats();

      _statsView = new StatsView(_stats, font)
      {
        Colour = Color.Black,
        Position = new Vector2(Game1.screenWidth - 100, 20),
      };

      _upgradeManager = new UpgradesManager();
      _upgradeManager.LoadUpgrades();

      foreach (var up in _upgradeManager.Upgrades)
        Console.WriteLine(up.Name);

      rnd = new Random();

      _sprites = new List<Sprite>();
      _playerSprite = new List<Sprite>();
      _enemySprite = new List<Sprite>();

      _playerSprite.Add(new Player(playerTexutre)
      {
        Colour = Color.Red,
        Position = new Vector2(Game1.screenWidth / 2, Game1.screenHeight - 80),
        Layer = 0.0f,
      });

      _enemySprite.Add(new TestEnemy(enemyTexture)
      {
        Colour = Color.Orange,
        Position = new Vector2(30, Game1.screenHeight / 2),
        Layer = 0.0f,
      });
    }

    private void Spawner(Texture2D foodTexture)
    {
      _sprites.Add(new Cake(foodTexture)
      {
        Position = new Vector2(rnd.Next(Game1.screenWidth), rnd.Next(Game1.screenHeight)),
        Layer = 0.0f,
        Sprites = _sprites,
        IsRemoved = false,
        Score = 10,
      });

      CanSpawn = false;
    }

    private void SpawnerAndTimer()
    {
      if (CanSpawn == true && SpawnTimer >= 50f)
      {
        Spawner(Food);
        CanSpawn = false;
        SpawnTimer = 0f;
      }
      else if (CanSpawn == false && SpawnTimer != 50f)
      {
        SpawnTimer++;

        if (SpawnTimer >= 50f)
          CanSpawn = true;
      }
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
      spriteBatch.Begin(SpriteSortMode.FrontToBack);

      foreach (var sprite in _sprites)
        sprite.Draw(gameTime, spriteBatch);

      foreach (var sprite in _playerSprite)
        sprite.Draw(gameTime, spriteBatch);

      foreach (var sprite in _enemySprite)
        sprite.Draw(gameTime, spriteBatch);

      spriteBatch.End();

      spriteBatch.Begin(SpriteSortMode.FrontToBack);

      _scoreView.Draw(gameTime, spriteBatch);

      _statsView.Draw(gameTime, spriteBatch);

      //_window?.Draw(gameTime, spriteBatch);

      spriteBatch.End();
    }

    public override void PostUpdate(GameTime gameTime)
    {
      int spriteCount = _sprites.Count;
      for (int i = 0; i < spriteCount; i++)
      {
        var sprite = _sprites[i];
        foreach (var child in sprite.Children)
        {
          _sprites.Add(child);
        }
        sprite.Children = new List<Sprite>();
      }
      for (int i = 0; i < _sprites.Count; i++)
      {
        if (_sprites[i].IsRemoved)
        {
          _sprites.RemoveAt(i);
          i--;
        }
      }
    }

    public override void Update(GameTime gameTime)
    {
      _stats.Health = 1;
      _stats.Defence = 1;
      _stats.Speed = 1;

      foreach (var sprite in _sprites)
        sprite.Update(gameTime);

      foreach (var sprite in _playerSprite)
        sprite.Update(gameTime);

      foreach (var sprite in _enemySprite)
        sprite.Update(gameTime);

      SpawnerAndTimer();

      var hasExitedEnemy = _playerSprite[0].OnExit(_enemySprite[0]);

      if (_playerSprite[0].OnEnter(_enemySprite[0]))
      {
        _score.Value -= 10;
      }

      for (int i = 0; i < _sprites.Count; i++)
      {
        if (_playerSprite[0].Rectangle.Intersects(_sprites[i].Rectangle))
        {
          _score.Value += _sprites[i].Score;
          _playerSprite[0].Scale += 0.05f;
          _sprites.RemoveAt(i);
          i--;
        }
      }
    }
  }
}
