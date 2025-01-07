using Godot;
using System;

public partial class Main : Node2D
{
    private Vector2 _selectionStart;
    private Rect2 _selectionRect;

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("mouse_left"))
        {
            _selectionStart = GetGlobalMousePosition();
        }

        if (Input.IsActionPressed("mouse_left"))
        {
            var mousePosition = GetGlobalMousePosition();
            _selectionRect = new Rect2(_selectionStart, mousePosition - _selectionStart);
            // Draw selection box using a debug line or UI element.
        }

        if (Input.IsActionJustReleased("mouse_left"))
        {
            SelectUnits();
        }
        if (Input.IsActionJustPressed("mouse_right"))
        {
            var targetPosition = GetGlobalMousePosition();
            foreach (Node child in GetTree().GetNodesInGroup("Units"))
            {
                if (child is Unit unit /* && unit.IsSelected*/)
                {
                    unit.SetTarget(targetPosition);
                }
            }
        }
    }

    private void SelectUnits()
    {
        foreach (Node child in GetTree().GetNodesInGroup("Units"))
        {
            if (child is Unit unit)
            {
                var unitPosition = unit.GlobalPosition;
                bool isInSelection = _selectionRect.HasPoint(unitPosition);
                unit.SetSelected(isInSelection);
            }
        }
    }
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
	}
}
