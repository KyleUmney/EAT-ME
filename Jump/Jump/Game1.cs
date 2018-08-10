using Jump.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Jump
{
  /// <summary>
  /// This is the main type for your game.
  /// </summary>
  public class Game1 : Game
  {
    GraphicsDeviceManager graphics;
    SpriteBatch spriteBatch;

    public static int screenWidth = 1280;
    public static int screenHeight = 720;

    private State _currentState;
    private State _nextState;

    //private float _rotation = 0f;
    //public Vector2 Position = new Vector2(screenWidth / 2, screenHeight / 2);
    //public Random rnd;
    //private float _speed = 10f;
    //public Texture2D _texture;
    //public Texture2D _foodTexture;
    //public Color Colour = Color.Pink;

    //public Vector2 Origin
    //{
    //  get
    //  {
    //    return new Vector2(_texture.Width / 2, _texture.Height / 2);
    //  }
    //}
    public Game1()
    {
      graphics = new GraphicsDeviceManager(this);
      Content.RootDirectory = "Content";
    }

    /// <summary>
    /// Allows the game to perform any initialization it needs to before starting to run.
    /// This is where it can query for any required services and load any non-graphic
    /// related content.  Calling base.Initialize will enumerate through any components
    /// and initialize them as well.
    /// </summary>
    protected override void Initialize()
    {
      // TODO: Add your initialization logic here

      graphics.PreferredBackBufferWidth = screenWidth;
      graphics.PreferredBackBufferHeight = screenHeight;
      graphics.ApplyChanges();

      base.Initialize();
    }

    /// <summary>
    /// LoadContent will be called once per game and is the place to load
    /// all of your content.
    /// </summary>
    protected override void LoadContent()
    {
      // Create a new SpriteBatch, which can be used to draw textures.
      spriteBatch = new SpriteBatch(GraphicsDevice);
      _currentState = new GameState(this, Content);
      _currentState.LoadContent();
      _nextState = null;

      // TODO: use this.Content to load your game content here
      //_texture = Content.Load<Texture2D>("Sprites/Player");
      //_foodTexture = Content.Load<Texture2D>("Sprites/Food");
    }

    /// <summary>
    /// UnloadContent will be called once per game and is the place to unload
    /// game-specific content.
    /// </summary>
    protected override void UnloadContent()
    {
      // TODO: Unload any non ContentManager content here
    }

    /// <summary>
    /// Allows the game to run logic such as updating the world,
    /// checking for collisions, gathering input, and playing audio.
    /// </summary>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    protected override void Update(GameTime gameTime)
    {
      if(_nextState != null)
      {
        _currentState = _nextState;
        _currentState.LoadContent();
        _nextState = null;
      }
      _currentState.Update(gameTime);
      _currentState.PostUpdate(gameTime);

      base.Update(gameTime);
    }

    public void ChangeState(State state)
    {
      _nextState = state;
    }
    //protected void Spawn()
    //{
    //  Vector2[] _wayPoints = new Vector2[]
    //  {
    //    new Vector2(50,50),
    //    new Vector2(100, 100),
    //    new Vector2(150, 150),
    //  };

    // foreach (var point in _wayPoints)
    //    spriteBatch.Draw(_foodTexture, _wayPoints[0], null, Colour, _rotation, Origin, 1f, SpriteEffects.None, 0.1f);
    //}

    /// <summary>
    /// This is called when the game should draw itself.
    /// </summary>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    protected override void Draw(GameTime gameTime)
    {
      GraphicsDevice.Clear(Color.CornflowerBlue);

      // TODO: Add your drawing code here

      _currentState.Draw(gameTime, spriteBatch);

      base.Draw(gameTime);
    }
  }
}
