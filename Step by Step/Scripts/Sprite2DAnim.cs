using Godot;
using System;


namespace MyGame
{
  public partial class Sprite2DAnim : Godot.Sprite2D
  {
    private readonly int _speed = 400;
    private readonly float _angularSpeed = Mathf.Pi;

    public override void _Process(double delta)
    {
      var direction = 0;
      if (Input.IsActionPressed("ui_left"))
      {
        direction = -1;
      }
      if (Input.IsActionPressed("ui_right"))
      {
        direction = 1;
      }

      Rotation += _angularSpeed * direction * (float)delta;

      var velocity = Vector2.Zero;
      if (Input.IsActionPressed("ui_up"))
      {
        velocity = Vector2.Up.Rotated(Rotation) * _speed;
      }

      Position += velocity * (float)delta;

      if (Input.IsKeyPressed(Key.Escape))
      {
        GetTree().Quit();
      }
    }
  }
}

