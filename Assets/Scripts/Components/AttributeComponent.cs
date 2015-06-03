using System;
using ECS;

public class AttributeComponent : IComponent
{


	public int health = 100;
	public int attack = 100;
	public int armor = 100;
	public float velocity = 0;
	public float MAX_VELOCITY = 8;
	public float ACCELERATION = 3f;
	public float DAMPING = 4f;

	override public void reset(){
		health = 100;
		attack = 100;
		armor = 100;
		velocity = 0;
	}
}


