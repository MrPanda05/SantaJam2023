using Godot;
using System;

//Base State class that all states will inherite!
public partial class State : Node
{
	public FiniteStateMachine FSM;
	/// <summary>
	/// Called Each time the state is enter
	/// </summary>
	public virtual void Enter() {}
	/// <summary>
	/// Called each time the state is exit
	/// </summary>
	public virtual void Exit() {}
	/// <summary>
	/// Called only once to be saved on cache
	/// </summary>
	public virtual void Readys(){}
	/// <summary>
	/// Same as godot process function, called as often as possible
	/// </summary>
	/// <param name="delta"></param>
	public virtual void Update(float delta) {}
	/// <summary>
	/// Same as godot physics_process, called each physics frame
	/// </summary>
	/// <param name="delta"></param>
	public virtual void FixUpdate(float delta) {}
	/// <summary>
	/// Handles the input of the current state
	/// </summary>
	/// <param name="event"></param>
	public virtual void HandleInput(InputEvent @event) {}
}
