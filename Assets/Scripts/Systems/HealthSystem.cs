using System;
using ECS;
using UnityEngine;

public class HealthSystem : ISystem
{
	public HealthSystem ()
	{
	}

	void ISystem.update(float delta){
		GameObject[] gameObjects = EntityManager.getGameObjectsWithComponents (typeof(AttributeComponent), typeof(MovementState));
		foreach (GameObject g  in gameObjects) {
			AttributeComponent attributes = (AttributeComponent) EntityManager.getComponent(g, typeof(AttributeComponent));
			MovementStateComponent movement = (MovementStateComponent) EntityManager.getComponent (g, typeof(MovementStateComponent));
			if(attributes.health <= 0){
				movement.movementState = MovementState.DIE;
			}
		}
	}
}


