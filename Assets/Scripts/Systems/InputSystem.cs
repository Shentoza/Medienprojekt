using System;
using UnityEngine;
using ECS;

public class InputSystem : ISystem
{


	public InputSystem ()
	{

	}

	void ISystem.update(float delta){
		GameObject[] gameObjects = EntityManager.getGameObjectsWithComponents (typeof(MovementStateComponent), typeof(InputComponent));
		foreach (GameObject g in gameObjects) {
			InputComponent input = (InputComponent)g.GetComponent(typeof(InputComponent));
			MovementStateComponent movement = (MovementStateComponent) g.GetComponent (typeof(MovementStateComponent));
			if(Input.GetKey(input.inputUp)){
				movement.movementState = MovementState.JUMP;
			}else if(Input.GetKey(input.inputLeft)){
				movement.movementState = MovementState.WALK;
			}else if(Input.GetKey(input.inputRight)){
				movement.movementState = MovementState.RUN;
			}else if(Input.GetKey(input.inputAttack)){
				movement.movementState = MovementState.ATTACK;
			}else if(Input.GetKey(input.inputAction1)){
				movement.movementState = MovementState.ACTION1;
			}else if(Input.GetKey(input.inputAction2)){
				movement.movementState = MovementState.ACTION2;
			}else{
				movement.movementState = MovementState.IDLE;
			}
		}
	}

}


