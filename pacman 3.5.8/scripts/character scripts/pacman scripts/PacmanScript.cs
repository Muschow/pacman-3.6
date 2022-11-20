using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public class PacmanScript : CharacterScript
{
    private Node2D raycasts;
    private Vector2 nextDir = Vector2.Zero;
    private Vector2 moveDir = Vector2.Zero;

    // Called when the node enters the scene tree for the first time.
    public PacmanScript()
    {
        speed = 100; //originally 100 speed
        speed = speed * Globals.gameSpeed; //need to figure out a way to have this inside of the character class/globals or something
    }

    public void GetInput()
    {
        if (Input.IsActionJustPressed("move_up"))
        {
            nextDir = Vector2.Up;
        }
        else if (Input.IsActionJustPressed("move_down"))
        {
            nextDir = Vector2.Down;
        }
        else if (Input.IsActionJustPressed("move_right"))
        {
            nextDir = Vector2.Right;
        }
        else if (Input.IsActionJustPressed("move_left"))
        {
            nextDir = Vector2.Left;
        }

        if ((bool)raycasts.Call("RaysAreColliding", nextDir) == false)
        {
            moveDir = nextDir;
        }
        //CheckCollision(); //merge checkCollision code with GetInput
        //moveVelocity = moveDir * speed;



    }


    private Vector2 Move(Vector2 moveDir, float speed) //change moveDir and speed
    {
        Vector2 moveVelocity = moveDir * speed;

        Vector2 masVector = MoveAndSlide(moveVelocity, Vector2.Up);

        PlayAndPauseAnim(masVector);

        return masVector;
    }


    public override void _Ready()
    {
        GD.Print("pacman ready");
        mazeTm = GetNode<TileMap>("/root/Game/MazeContainer/Maze/MazeTilemap");
        raycasts = GetNode<Node2D>("RayCasts"); //maybe have a pacmanInit method with all this crap in

        Position = new Vector2(1, (int)mazeTm.Get("mazeOriginY") + (int)mazeTm.Get("height") - 3) * 32 + new Vector2(16, 16);
        GD.Print("pman ps", Position);



        //I feel like setting the spawn of pacman should be done in the main script so that pacman can be ran independantly of other nodes, or even in the character script instead

        //rays = GetTree().GetNodesInGroup("pacmanRays");
        //AddRaystoDict();


    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _PhysicsProcess(float delta)
    {
        GetInput();
        Vector2 masVector = Move(moveDir, speed);
        //var masVector = MoveAndSlide(moveVelocity, Vector2.Up); //potentially could put this in the character class somwehere
        //GD.Print(masVector);
        MoveAnimManager(masVector);
    }
}
