using Godot;
using System;

public partial class CsharpDelChild : Node2D
{
    //Calling C# EXTERNAL EVENTS HERE, AS WELL AS CREATING IN FILE EVENTS HERE AS WELL

    [Export] public CshartpsEvents externalFile;

    //In file events!
    //Create in file delegate
    public delegate void inFile(int num);

    //Create the instance of the infile delegate
    public inFile doSomething;


    //In reality we don't need to use delegates, we use Action! with is the same but faster to do
    //use Action<T> to receive arguments! use Func if you want a return
    public Action myInFileAction;

    public Func<int> myFunc;
    private int myFuncReturn;

    public override void _Ready()
    {
        //doSomething = InFileDelTest; This is direct assigning
        doSomething += InFileDelTest;//This is subscribing, this enable multiple funcions to be activate from the delegate
        doSomething?.Invoke(123);

        //Call to external file delegate
        CshartpsEvents.doExternal += ExternalDelegate;
        CshartpsEvents.doExternal?.Invoke(234);

        myInFileAction += internalAction;
        myInFileAction?.Invoke();

        CshartpsEvents.externalAction += externalAction;
        CshartpsEvents.externalAction?.Invoke();
        
        myFunc += myFuncEvent;
        myFuncReturn = myFunc.Invoke();
        GD.Print("This is the result of the func " + myFuncReturn);

    }


    public int myFuncEvent()
    {
        return 10;
    }
    public void externalAction()
    {
        GD.Print("I am a internal action");
    }
    public void internalAction()
    {
        GD.Print("I am a internal action");
    }
    public void ExternalDelegate(int num)
    {
        GD.Print("I am a external file delegate with value " + num);
        
    }
    public void InFileDelTest(int num)
    {
        GD.Print("I am a in file delegate with value " + num);
    }
}
