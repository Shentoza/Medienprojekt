using System;
using ECS;

public class MovementStateComponent : IComponent
{

	private MovementState lastMovementState;
	public MovementState movementState;

	void Awake(){
		lastMovementState = MovementState.IDLE;
		movementState = MovementState.IDLE;
	}

	public void changeMovement(MovementState movementState){
		if (movementState != this.movementState) {
			lastMovementState = this.movementState;
			this.movementState = movementState;
		}
	}

	public MovementState getLastMovementState(){
		return lastMovementState;
	}

	override public void reset(){
		lastMovementState = MovementState.IDLE;
		movementState = MovementState.IDLE;
	}
}


