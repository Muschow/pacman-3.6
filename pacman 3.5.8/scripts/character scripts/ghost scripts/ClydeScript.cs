using Godot;
using System;

public class ClydeScript : GhostScript
{
    public ClydeScript()
    {
        ghostColour = Colors.Orange;
        searchingAlgo = algo.astar;
    }

    private void FindMidpointOfRandomGhosts()
    {

        //get ghost1 pos
        //get ghost2 pos
        //target = ghost1pos+ghost2pos /2

        //return target

    }

    public override void UpdateSourceTarget()
    {
        //GD.Print("this is okay");
        source = mazeTm.WorldToMap(Position);
        target = FindClosestNodeTo(mazeTm.WorldToMap(pacman.Position)); //clyde finds closest node at the midpoint between 2 ghosts chosen randomly at ready
    }
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    // public override void _Ready()
    // {

    // }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}
