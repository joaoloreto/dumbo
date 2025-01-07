using Godot;
using System;

public partial class Worker : Node2D
{
    private int _carryingAmount = 0;

    public void Gather(Resources resource)
    {
        _carryingAmount += resource.GatherResource(10); // Gather 10 units at a time.
    }
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
