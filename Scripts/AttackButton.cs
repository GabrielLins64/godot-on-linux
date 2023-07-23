using Godot;
using System;


namespace MyGame
{
  public partial class AttackButton : Button
  {
    private void OnSprite2DHealthDepleted()
    {
      GD.Print("[AttackButton] I'm leaving!");
      Visible = false;
    }
  }
}
