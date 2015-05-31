using System;
using ECS;
using UnityEngine;

public class PhysicsSystem : ISystem
{

	public PhysicsSystem ()
	{

	}

	void ISystem.update(float delta){
		GameObject[] gameObjects = EntityManager.getGameObjectsWithComponents (typeof(Collider2D), typeof(Rigidbody2D),
		                                                                      typeof(MovementStateComponent));

		foreach (GameObject g in gameObjects) {

			MovementStateComponent movement = (MovementStateComponent)g.GetComponent(typeof(MovementStateComponent));
			Collider2D collider = (Collider2D)g.GetComponent(typeof(Collider2D));
			Rigidbody2D rigidBody = (Rigidbody2D)g.GetComponent(typeof(Rigidbody2D));

			switch(movement.movementState){
			case MovementState.IDLE:
				break;
			case MovementState.WALK:
				rigidBody.MovePosition(new Vector2(rigidBody.transform.position.x + 4 * delta, rigidBody.transform.position.y));
				break;
			case MovementState.RUN: 
				rigidBody.MovePosition(new Vector2(rigidBody.transform.position.x + 8 * delta, rigidBody.transform.position.y));
				break;
			case MovementState.JUMP: 
				rigidBody.MovePosition(new Vector2(rigidBody.transform.position.x, rigidBody.transform.position.y + 4 * delta));
				break;
			case MovementState.ACTION1: 
				rigidBody.MovePosition(new Vector2(rigidBody.transform.position.x + 4 * delta, rigidBody.transform.position.y));
				break;
			default:
				break;
			}

		}
	}
}


