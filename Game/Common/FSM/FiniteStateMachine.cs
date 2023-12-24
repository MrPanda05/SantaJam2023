using Godot;
using System;
using System.Collections.Generic;

public partial class FiniteStateMachine : Node
{
    [Export] public NodePath InitialState;
    [Export] public Middleware middleware;

    private Dictionary<string, State> states;
    private State currentState;

    public override void _Ready()
    {
        states = new Dictionary<string, State>();
        foreach(Node node in GetChildren())
        {
            if(node is State s)
            {
                states[node.Name] = s;
                s.FSM = this;
                s.ManInTheMiddle = middleware;
                s.Readys();
                s.Exit();
            }
        }

        currentState = GetNode<State>(InitialState);
        currentState.Enter();
    }

    public override void _Process(double delta)
    {
        currentState.Update((float) delta);
    }
    public override void _PhysicsProcess(double delta)
    {
        currentState.FixUpdate((float) delta);
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        currentState.HandleInput(@event);
    }

    public void TransitioToState(string key)
    {
        if(!states.ContainsKey(key) || currentState == states[key]) return;

        currentState.Exit();
        currentState = states[key];
        currentState.Enter();
        
    }

}
