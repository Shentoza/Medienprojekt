using System;
using UnityEngine;
using ECS;

public class InputSystem : ISystem
{


	public InputSystem ()
	{

	}

	void ISystem.update(float delta){
		GameObject[] gameObjects = EntityManager.getGameObjectsWithComponents (typeof(Rigidbody2D), typeof(AttributeComponent), typeof(MovementStateComponent), typeof(InputComponent));
		foreach (GameObject g in gameObjects) {

			InputComponent input = (InputComponent)g.GetComponent(typeof(InputComponent));
			MovementStateComponent movement = (MovementStateComponent) g.GetComponent (typeof(MovementStateComponent));
			AttributeComponent attribute = (AttributeComponent) g.GetComponent(typeof(AttributeComponent));
			Rigidbody2D rbody = (Rigidbody2D) g.GetComponent(typeof(Rigidbody2D));
			float movePlayerVector = 0;
			if(Input.GetKey(input.inputUp)){
				movement.changeMovement(MovementState.JUMP);
			}
			else if(Input.GetKey(input.inputAttack)){
				movement.changeMovement(MovementState.ATTACK);
			}else if(Input.GetKey(input.inputAction1)){
				movement.changeMovement(MovementState.ACTION1);
			}else if(Input.GetKey(input.inputAction2)){
				movement.changeMovement(MovementState.ACTION2);
			}else{
				movement.changeMovement(MovementState.IDLE);
				movePlayerVector = 0;
				Debug.Log(movePlayerVector);
				//rbody.velocity = new Vector2(movePlayerVector * attribute.speed, rbody.velocity.x);
				rbody.velocity = new Vector2(movePlayerVector * attribute.speed, 0);
				//attribute.changeVelocityX(0);
				//attribute.changeVelocityY(0);
			}
		}
	}

}


