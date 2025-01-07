using Godot;
using System;

public partial class Unit : Node2D
{
    [Export]
    public float Speed = 100.0f;

    private Vector2 _targetPosition;
    private bool _hasTarget = false;
    private bool _isSelected;

    public void SetSelected(bool selected)
    {
        _isSelected = selected;
        // Add visual feedback, like changing the color or adding a highlight.
        Modulate = selected ? Colors.Green : Colors.White;
    }
    private NavigationAgent2D _navigation;

    public override void _Ready()
    {
        _navigation = GetNode<NavigationAgent2D>("NavigationAgent2D");
    }

    public void SetTarget(Vector2 position)
    {
        _navigation.TargetPosition = position;
    }

    public override void _PhysicsProcess(double delta)
    {
        if (_navigation.IsNavigationFinished())
            return;

        var direction = _navigation.GetNextPathPosition() - GlobalPosition;
        Velocity = direction.Normalized() * Speed;
        MoveAndSlide();
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
