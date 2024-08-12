using Godot;
using System;

public partial class Joueur : Area2D
{

[Export]
private int SPEED = 400;

private AnimatedSprite2D animatedSprite2D;
private CollisionShape2D collisionShape2D;

private Vector2 Velocity;
private Vector2 screenSize;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		screenSize = GetViewportRect().Size;
		animatedSprite2D = (AnimatedSprite2D)GetNode("AnimatedSprite2D");
		collisionShape2D = (CollisionShape2D)GetNode("CollisionShape2D");


	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Velocity = new Vector2();
		if(Input.IsActionJustPressed("ui_right"))
		{
			Velocity.X += 1;
		}
		if(Input.IsActionJustPressed("ui_left"))
		{
			Velocity.X -= 1;
		}
		if(Input.IsActionJustPressed("ui_down"))
		{
			Velocity.Y += 1;
		}
		if(Input.IsActionJustPressed("ui_up"))
		{
			Velocity.Y -= 1;
		}
		
	}
}