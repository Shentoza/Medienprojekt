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
				movement.changeMovement(MovementState.JUMP);
			}else if(Input.GetKey(input.inputLeft)){
				movement.changeMovement(MovementState.RUN_LEFT);
			}else if(Input.GetKey(input.inputRight)){
				movement.changeMovement(MovementState.RUN_RIGHT);
			}else if(Input.GetKey(input.inputAttack)){
				movement.changeMovement(MovementState.ATTACK);
			}else if(Input.GetKey(input.inputAction1)){
				movement.changeMovement(MovementState.ACTION1);
			}else if(Input.GetKey(input.inputAction2)){
				movement.changeMovement(MovementState.ACTION2);
			}else{
				movement.changeMovement(MovementState.IDLE);
			}
		}
	}

}


