using Godot;
using System;

public partial class Resources : Node2D
{
    [Export]
    public int ResourceAmount = 100;

    public int GatherResource(int amount)
    {
        int gathered = Math.Min(ResourceAmount, amount);
        ResourceAmount -= gathered;
        if (ResourceAmount <= 0)
        {
            QueueFree(); // Remove the node when depleted.
        }
        return gathered;
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
