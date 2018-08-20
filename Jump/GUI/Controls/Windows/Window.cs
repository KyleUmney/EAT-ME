using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Controls.Windows
{
  public abstract class Window
  {
    // Properties
    //  Position
    public Vector2 Position { get; set; }
    //  Texture
    public Texture2D Texutre { get; set; }
    //  Rectangle (used to know if the mouse is over)
    public Rectangle Rectangle
    {
     get
      {
        return new Rectangle();
      }
    }
    //  IsVisible
    //  List<Buttons> // default of 'x' to close

    // Methods
    //  ctor
    protected Window(Vector2 position, Texture2D texutre)
    {
      Position = position;
      Texutre = texutre;
    }
    //  Update
    protected void Update()
    {

    }
    //  Draw
    protected void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
      spriteBatch.Begin();

      spriteBatch.End();
    }
    //  AnimateOnView
  }
}
