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
			if(Input.GetKey(input.getInputUp ())){
				rigidBody.velocity = new Vector2(0,2);
			}else if(Input.GetKey(input.getInputLeft ())){
				
			}else if(Input.GetKey(input.getInputRight ())){
				
			}else if(Input.GetKey(input.getInputAttack ())){
				
			}else if(Input.GetKey(input.getInputAction_1 ())){
				
			}else if(Input.GetKey(input.getInputAction_2 ())){
				
			}

		}
	}

}


