using Godot;
using System;

public partial class TestEmiter : Node2D
{
    //Godot signlas from external file
    //I don't have a clue of how to do signals from the same file
    [Export] private SignalsTest Health;//Gets the signal from another file

    public override void _Ready()
    {
        //Godot signal
        Health.HealthDepleted += SignalFuncion;//subscribe, note that this should unsubscribe in a case of node deletion
        Health?.EmitSignal(nameof(Health.HealthDepleted));//Emit signal, must be this way or SignalsTest.HealthDepleted (SignalClass.SignalNameWithoutEvent)
    }
    public void SignalFuncion()
    {
        GD.Print("I am the result of the signal from godot");
    }
}
