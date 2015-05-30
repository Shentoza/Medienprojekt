using System;
using UnityEngine;
using ECS;

public class InputSystem : ISystem
{


	public InputSystem ()
	{

	}

	void ISystem.update(float delta){
		GameObject[] gameObjects = EntityManager.getGameObjectsWithComponents (typeof(InputComponent), typeof(Rigidbody2D));
		foreach (GameObject g in gameObjects) {
			InputComponent input = (InputComponent)g.GetComponent(typeof(InputComponent));
			Rigidbody2D rigidBody = (Rigidbody2D)g.GetComponent (typeof(Rigidbody2D));
			if(Input.GetKey(input.inputUp)){
				rigidBody.velocity = new Vector2(0,2);
			}else if(Input.GetKey(input.inputLeft)){
				rigidBody.velocity = new Vector2(-2,0);
			}else if(Input.GetKey(input.inputRight)){
				rigidBody.velocity = new Vector2(2,0);
			}else if(Input.GetKey(input.inputAttack)){
				rigidBody.velocity = new Vector2(0,0);
			}else if(Input.GetKey(input.inputAction1)){
				rigidBody.velocity = new Vector2(0,0);
			}else if(Input.GetKey(input.inputAction2)){
				rigidBody.velocity = new Vector2(0,0);
			}else{
				rigidBody.velocity = new Vector2(0,0);
			}

		}
	}

}


