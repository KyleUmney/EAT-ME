using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Jump.Sprites
{
  class TestEnemy : Sprite
  {
    private Vector2 _currentWaypoint;
    private int _wayPointIndex;

    public TestEnemy(Texture2D texture) : base(texture)
    {
    }

    public override void Update(GameTime gameTime)
    {
      if (_wayPoints.Count > 0)
        _currentWaypoint = _wayPoints[_wayPointIndex];

      MoveToWayPoint();

      base.Update(gameTime);
    }

    private void MoveToWayPoint()
    {
      Vector2 currentPosition = Position;
      Vector2 targetPosition = _currentWaypoint;
      Vector2 direction = targetPosition - currentPosition;

      Position += direction / 20f;

      if (Vector2.Distance(currentPosition, targetPosition) < 10f)
      {
        _wayPointIndex++;
        if (_wayPointIndex >= _wayPoints.Count)
          _wayPointIndex = 0;
      }
    }
  }
}
