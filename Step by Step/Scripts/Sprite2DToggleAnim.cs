using Godot;
using System;


namespace MyGame
{
  public partial class Sprite2DToggleAnim : Sprite2D
  {
    // In case the Custom Signal won't show on Docks after you add it, see:
    // https://github.com/godotengine/godot/issues/40318#issuecomment-940426982
    [Signal]
    public delegate void HealthDepletedEventHandler();

    private int _health = 6;
    private readonly float _angularSpeed = Mathf.Pi;
    private bool scaled = false;

    public override void _Ready()
    {
      base._Ready();
      var timer = GetNode<Timer>("MyTimer");
      timer.Timeout += OnTimerTimeout;
      timer.WaitTime = 0.4;
    }

    public override void _Process(double delta)
    {
      Rotation += _angularSpeed * (float)delta;
    }

    private void OnButtonPressed()
    {
      SetProcess(!IsProcessing());
    }

    private void OnAttackButtonPressed()
    {
      TakeDamage(2);
    }

    private void OnTimerTimeout()
    {
      if (scaled)
      {
        ApplyScale(new Vector2((float)1.25, (float)1.25));
      }
      else
      {
        ApplyScale(new Vector2((float)0.8, (float)0.8));
      }
      scaled = !scaled;
    }

    public void TakeDamage(int amount)
    {
      _health -= amount;

      GD.Print($"[Sprite2D] Godot has taken {amount} damage! His health is {_health}.");

      if (_health <= 0)
      {
        EmitSignal(SignalName.HealthDepleted);
        GD.Print("[Sprite2D] Godot has died.");
        Visible = false;
      }
    }
  }
}
