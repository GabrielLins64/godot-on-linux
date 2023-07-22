using Godot;
using System;


namespace MyGame
{
  public partial class Sprite2D : Godot.Sprite2D
  {
    private readonly int _speed = 400;
    private readonly float _angularSpeed = Mathf.Pi;

    public Sprite2D()
    {
      GD.Print("Hello World!");
    }

    public override void _Process(double delta)
    {
      Rotation += _angularSpeed * (float)delta;
      var velocity = Vector2.Up.Rotated(Rotation) * _speed;
      Position += velocity * (float)delta;
    }
  }
}
