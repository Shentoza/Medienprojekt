using System;
using ECS;

public class AttributeComponent : IComponent
{

	public int health = 100;
	public int attack = 100;
	public int armor = 100;
	public float velocity = 4;

	void Start(){

	}

	override public void reset(){
		health = 100;
		attack = 100;
		armor = 100;
		velocity = 4;
	}
}


