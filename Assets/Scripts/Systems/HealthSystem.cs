using System;
using ECS;
using UnityEngine;

public class HealthSystem : ISystem
{
	public HealthSystem ()
	{

	}

	void ISystem.update(float delta){
		GameObject[] gameObjects = EntityManager.getGameObjectsWithComponents (typeof(AttributeComponent), typeof(MovementStateComponent));
		foreach (GameObject g  in gameObjects) {
			AttributeComponent attributes = (AttributeComponent) EntityManager.getComponent(g, typeof(AttributeComponent));
			MovementStateComponent movement = (MovementStateComponent) EntityManager.getComponent (g, typeof(MovementStateComponent));
			if(attributes.health <= 0){
				movement.movementState = MovementState.DIE;
				if(g.tag == "Player"){
					//Nach Todesanimation: GUI anzeigen, nach Input Spiel beenden/neu laden
				}else{
					g.SetActive(false);
				}
			}
		}
	}
}


