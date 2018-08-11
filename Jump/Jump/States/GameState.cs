using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jump.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Jump.States
{
  class GameState : State
  {
    public List<Sprite> _sprites;
    public List<Sprite> _playerSprite;
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
      var playerTexture = _content.Load<Texture2D>("Sprites/Player");
      rnd = new Random();

      _sprites = new List<Sprite>();
      _playerSprite = new List<Sprite>();

      _playerSprite.Add(new Player(playerTexture)
      {
        Colour = Color.Red,
        Position = new Vector2(Game1.screenWidth / 2, Game1.screenHeight / 2),
        Layer = 0.0f,

      });

      _sprites.Add(new Cake(Food)
      {
        Position = new Vector2(rnd.Next(Game1.screenWidth), rnd.Next(Game1.screenHeight)),
        Layer = 0.0f,
        Sprites = _sprites,
        IsRemoved = false,
      });
      _sprites.Add(new Cake(Food)
      {
        Position = new Vector2(rnd.Next(Game1.screenWidth), rnd.Next(Game1.screenHeight)),
        Layer = 0.0f,
        Sprites = _sprites,
        IsRemoved = false,
      });
      _sprites.Add(new Cake(Food)
      {
        Position = new Vector2(rnd.Next(Game1.screenWidth), rnd.Next(Game1.screenHeight)),
        Layer = 0.0f,
        Sprites = _sprites,
        IsRemoved = false,
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
      });

      CanSpawn = false;

    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
      spriteBatch.Begin(SpriteSortMode.FrontToBack);

      foreach (var sprite in _sprites)
        sprite.Draw(gameTime, spriteBatch);

      foreach (var sprite in _playerSprite)
        sprite.Draw(gameTime, spriteBatch);

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
      foreach (var sprite in _sprites)
        sprite.Update(gameTime);

      foreach (var sprite in _playerSprite)
        sprite.Update(gameTime);


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


      for (int i = 0; i < _sprites.Count; i++)
      {
        if (_playerSprite[0].Rectangle.Intersects(_sprites[i].Rectangle))
          _sprites.RemoveAt(i);
      }



    }
  }
}
