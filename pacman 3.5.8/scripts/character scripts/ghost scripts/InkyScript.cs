using Godot;
using System;

public class InkyScript : GhostScript
{
    public InkyScript() //inky should move randomly, essentially, constantly be in patrol mode
    {
        ghostColour = Colors.Cyan;
        searchingAlgo = algo.astar; //blue, although it moves randomly, uses astar as thats generally the fastest algorithm

        GetNode<Timer>("PatrolTimer").Paused = true; //not sure why this works but the one below doesnt since its inherited...
        //patrolTimer.Paused = true; //pause the patrol timer so its always on patrol mode which moves randomly
    }
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    // public override void _Ready()
    // {
    //     
    // }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}
