using Godot;
using System;

public partial class RocksSpawner : Node2D
{

    [Export] public PackedScene Rock, Gold, Iron;

    public int maxEntity = 40;
    public int entityCount = 0;
    public Timer timer;

    public int rockCount, goldCount, ironCount;
    public Action OnUpdate;

    private uint temp;

    

    public void OnSpawnTimerTimeout()
    {
        //Spawn area
         //x: -10 -> 1142

        //y: -10 -> 494
        if(entityCount >= maxEntity) return;
        temp = GD.Randi() % 101;
        if(temp >=  50)
        {
            Node2D rock = Rock.Instantiate() as Node2D;
            AddChild(rock);
            rock.GlobalPosition = Vector2.Zero;
            rock.GlobalPosition = new Vector2(GD.Randi() % 1130, (GD.Randi() + 15) % 480);
            entityCount++;
            return;
        }
        if(temp > 10 && temp < 50)
        {
            Node2D iron = Iron.Instantiate() as Node2D;
            AddChild(iron);
            iron.GlobalPosition = Vector2.Zero;
            iron.GlobalPosition = new Vector2(GD.Randi() % 1130, (GD.Randi() + 15) % 480);
            entityCount++;
            return;
        }
        if(temp <= 10)
        {
            Node2D gold = Gold.Instantiate() as Node2D;
            AddChild(gold);
            gold.GlobalPosition = Vector2.Zero;
            gold.GlobalPosition = new Vector2(GD.Randi() % 1130, (GD.Randi() + 15) % 480);
            entityCount++;
            return;
        }
        
    }


    public override void _Ready()
    {
        timer = GetParent().GetNode<Timer>("SpawnTimer");
    }
}
