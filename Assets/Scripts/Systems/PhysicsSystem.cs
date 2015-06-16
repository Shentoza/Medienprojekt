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
			g.transform.position = new Vector3((g.transform.position.x + attributes.velocity.x * delta),g.transform.position.y + attributes.velocity.y* delta,0);
			float movePlayerVector = Input.GetAxis("Horizontal");
			rigidBody.velocity = new Vector2(movePlayerVector * attributes.speed, 0 );
			Debug.Log (movePlayerVector);
		}
	}
}


