using Godot;
using System;

public partial class MoveState : State
{
    private Player player;

    public override void Enter()
    {
        player = CommonRefs.Instance.GetPlayer();
        //player.OnInventoryEnter += openIventory;
    }
    public override void HandleInput(InputEvent @event)
    {
        player.direction = Input.GetVector("Left", "Right", "Up", "Down").Normalized();
    }
    public override void FixUpdate(float delta)
    {
        player.PlayerMove(player.direction);
    }
}
