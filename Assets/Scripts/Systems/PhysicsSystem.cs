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

			if(!(Input.GetAxis ("Horizontal") == 0 && Input.GetAxis ("Vertical") == 0)){
				if(attributes.velocity < attributes.MAX_VELOCITY){
					if(attributes.velocity <= 0){
						attributes.velocity += 10 * attributes.ACCELERATION * delta;
					}else{
						attributes.velocity += attributes.velocity * attributes.ACCELERATION * delta;
					}
				}
			}else{
				if(attributes.velocity > 0){
					attributes.velocity -= attributes.velocity * attributes.DAMPING * delta;
					if(attributes.velocity < 0.01){
						attributes.velocity = 0;
					}
				}
			}

			Vector2 moveVector = new Vector2(Input.GetAxis ("Horizontal") * attributes.MAX_VELOCITY, Input.GetAxis ("Vertical") * attributes.MAX_VELOCITY);
			rigidBody.velocity = new Vector2(moveVector.x, moveVector.y);
		}
	}
}


