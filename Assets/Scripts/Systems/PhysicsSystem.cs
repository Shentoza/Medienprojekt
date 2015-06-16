using System;
using ECS;
using UnityEngine;

public class PhysicsSystem : ISystem
{

	float timer = Time.time;

	public PhysicsSystem ()
	{

	}



	void ISystem.update(float delta){
		GameObject[] gameObjects = EntityManager.getGameObjectsWithComponents (typeof(Collider2D), typeof(Rigidbody2D),
		                                                                      typeof(MovementStateComponent));
		foreach (GameObject g in gameObjects) {
			MovementStateComponent movement = (MovementStateComponent) EntityManager.getComponent (g, typeof(MovementStateComponent));
			BoxCollider2D collider = (BoxCollider2D) EntityManager.getComponent (g, typeof(Collider2D));
			Rigidbody2D rigidBody = (Rigidbody2D) EntityManager.getComponent (g, typeof(Rigidbody2D));
			AttributeComponent attributes = (AttributeComponent) EntityManager.getComponent (g, typeof(AttributeComponent));
			g.transform.position = new Vector3((g.transform.position.x + attributes.velocity.x * delta),g.transform.position.y + attributes.velocity.y* delta,0);
			float movePlayerVector = Input.GetAxis("Horizontal");
			rigidBody.velocity = new Vector2(movePlayerVector * attributes.speed, 0 );
			if(Input.GetAxis("Vertical") > 0 && attributes.isGrounded)
			{
				attributes.isGrounded = false;
				rigidBody.AddForce(new Vector2(0, attributes.jumpHeight), ForceMode2D.Force);
			}


			if(Physics2D.Raycast(g.transform.position, -Vector2.up, 0.01f));
			{
				Debug.Log ("Hit!!!!!");
				attributes.isGrounded = true;
			}

			if(Input.GetKey ("q") && timer <= Time.time)
			{
				collider.size = new Vector2(2.5f, 2.5f);
				rigidBody.velocity = new Vector2(3 * movePlayerVector * attributes.speed, 0);
				collider.size = new Vector2(5.12f, 5.12f);
				timer = Time.time + 5;
			}
		
		}
	}


}


