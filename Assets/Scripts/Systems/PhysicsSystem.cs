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

			MovementStateComponent movement = (MovementStateComponent) EntityManager.getComponent (g, typeof(MovementStateComponent));
			Collider2D collider = (Collider2D) EntityManager.getComponent (g, typeof(Collider2D));
			Rigidbody2D rigidBody = (Rigidbody2D) EntityManager.getComponent (g, typeof(Rigidbody2D));
			AttributeComponent attributes = (AttributeComponent) EntityManager.getComponent (g, typeof(AttributeComponent));

			if(attributes.velocity > attributes.MAX_VELOCITY){
				attributes.velocity = attributes.MAX_VELOCITY;
			}else if(movement.movementState != MovementState.IDLE){
				attributes.velocity += attributes.velocity * attributes.ACCELERATION * delta;
				Debug.Log ("Not IDLE");
			}else if (attributes.velocity > 0){
				attributes.velocity -= attributes.velocity * attributes.DAMPING * delta;
				if(attributes.velocity < 0)
					attributes.velocity = 0;
			}
			//rigidBody.velocity = new Vector2(2,0);
			switch(movement.movementState){
				case MovementState.IDLE:
				case MovementState.WALK_RIGHT:
				case MovementState.RUN_RIGHT: 
					rigidBody.velocity = new Vector2(attributes.velocity, 0.0f);
					break;
				case MovementState.WALK_LEFT:
				case MovementState.RUN_LEFT: 
					rigidBody.velocity = new Vector2(-attributes.velocity, 0.0f);
					break;
				case MovementState.ACTION1:
				rigidBody.velocity = new Vector2(0.1f, 0.0f);
					break;
				case MovementState.JUMP: 
					rigidBody.velocity = new Vector2(0.0f, attributes.velocity);
					break;
				default:
					break;
			}
		}
	}
}


