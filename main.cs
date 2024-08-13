using Godot;
using System;

public partial class main : Node2D
{

	private Timer ennemiTimer;
	private PackedScene ennemiScene;

	private PathFollow2D path;

	private static Random ennemiPosRandom;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ennemiTimer = (Timer)GetNode("EnnemiTimer");
		ennemiTimer.Connect("timeout", new Callable(this, nameof(OnEnnemiSpawn)));
		ennemiTimer.Start();

		ennemiScene = (PackedScene)GD.Load("Ennemi.tscn");

		path = (PathFollow2D)GetNode("Path2D/PathFollow2D");

		ennemiPosRandom = new Random();
	}

	void OnEnnemiSpawn()
	{

		ennemi ennemi = (ennemi)ennemiScene.Instantiate();

		// Choose a random location on Path2D.
		var mobSpawnLocation = path;
		mobSpawnLocation.ProgressRatio = GD.Randf();

		// Set the mob's direction perpendicular to the path direction.
		float direction = mobSpawnLocation.Rotation + Mathf.Pi / 2;

		// Set the mob's position to a random location.
		ennemi.Position = mobSpawnLocation.Position;

		// Add some randomness to the direction.
		direction += (float)GD.RandRange(-Mathf.Pi / 4, Mathf.Pi / 4);
		ennemi.Rotation = direction;

			// Choose the velocity.
	var velocity = new Vector2((float)GD.RandRange(150.0, 250.0), 0);
	ennemi.LinearVelocity = velocity.Rotated(direction);


		AddChild(ennemi);
	}
}
