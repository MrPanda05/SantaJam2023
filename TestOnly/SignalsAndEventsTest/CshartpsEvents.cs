using Godot;
using System;

public partial class CshartpsEvents : Node2D
{
    //C# EVENTS AND DELEGATES FROM EXTERNAL FILE
    //This is the external file

    //Delegates and events basic hold funcions
    public delegate void delegateSignal(int num);

    public static delegateSignal doExternal;

    //Use Action/Func for the best results
    public static Action externalAction;
}
