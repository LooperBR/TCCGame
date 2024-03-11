using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Signal]
	public delegate void MadeMoveEventHandler(int[] previousPos, int[] newPos);

	public int[] currentPos = { 0, 0 };
	public int[] previousPos = { 0, 0 };
	public Sprite2D sprite;

	public override void _Ready()
	{
		sprite = GetNode<Sprite2D>("Sprite2D");
	}

	public override void _Input(InputEvent @event)
	{
		if(@event.IsActionPressed("move_up"))
		{
			MoveUp();
		}
		if (@event.IsActionPressed("move_down"))
		{
			MoveDown();
		}

		if (@event.IsActionPressed("move_right"))
		{
			MoveRight();
		}

		if (@event.IsActionPressed("move_left"))
		{
			MoveLeft();
		}
		
	}
	
	public void MoveUp()
	{
		previousPos[0] = currentPos[0];
		previousPos[1] = currentPos[1];
		currentPos[1]--;
		UpdateGame(previousPos);
	}
	public void MoveDown()
	{
		previousPos[0] = currentPos[0];
		previousPos[1] = currentPos[1];
		currentPos[1]++;
		UpdateGame(previousPos);
	}


	public void MoveRight()
	{
		previousPos[0] = currentPos[0];
		previousPos[1] = currentPos[1];
		currentPos[0]++;
		UpdateGame(previousPos);
	}

	public void MoveLeft()
	{
		previousPos[0] = currentPos[0];
		previousPos[1] = currentPos[1];
		currentPos[0]--;
		UpdateGame(previousPos);
	}
	public void UpdateGame(int[] previousPos)
	{
		UpdatePos();
		EmitSignal(SignalName.MadeMove,previousPos,currentPos);
		GD.Print(currentPos[0]," ", currentPos[1]);

	}
	public void UpdatePos()
	{
		Position = new Vector2(currentPos[0] * 32, currentPos[1] * 32);
	}

	public override void _PhysicsProcess(double delta)
	{

	}
}
