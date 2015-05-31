using System;
using ECS;

public class MovementStateComponent : IComponent
{

	public MovementState movementState;

	void Awake(){
		movementState = MovementState.IDLE;
	}

	override public void reset(){

	}
}


