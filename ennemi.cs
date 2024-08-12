using Godot;
using System;

public partial class ennemi : RigidBody2D
{

	private static string[] animations = {"marche", "vol", "nage"};
	private AnimatedSprite2D animatedSprite;
	private static Random animationRandom = new Random();
	private VisibleOnScreenNotifier2D visibility;





	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		animatedSprite = (AnimatedSprite2D)GetNode("AnimatedSprite2D");
		visibility = (VisibleOnScreenNotifier2D)GetNode("VisibleOnScreenNotifier2D");
		animatedSprite.Animation = animations[animationRandom.Next(0, animations.Length)];
		animatedSprite.Play();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	
}
