using Godot;
using System;

public partial class State : Node
{
    public FiniteStateMachine FSM;

	public Middleware ManInTheMiddle;
    public virtual void Enter() {}
	public virtual void Exit() {}
	public virtual void Readys(){}
	public virtual void Update(float delta) {}
	public virtual void FixUpdate(float delta) {}
	public virtual void HandleInput(InputEvent @event) {}
}
