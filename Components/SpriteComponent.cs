using Godot;
using System;

public partial class SpriteComponent : AnimatedSprite2D
{

    public void OnAnimTimeout()
    {
        GetRandomAnim();
    }
    public void GetRandomAnim()
    {
        uint temp = GD.Randi() % 3;
        switch (temp)
        {
            case 0:
            Play("IddleType1");
            break;
            case 1:
            Play("IddleType2");
            break;
            case 2:
            Play("IddleType3");
            break;
        }
    }

}