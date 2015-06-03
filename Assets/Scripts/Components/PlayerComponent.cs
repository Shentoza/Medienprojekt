using System;
using ECS;
using UnityEngine;
public class PlayerComponent : IComponent
{

	bool collision = false;

	public PlayerComponent ()
	{

	}

	override public void reset(){

	}

	//Wird 2 Mal aufgerufen
	void OnCollisionEnter2D(Collision2D coll){
		if (!collision) {
			collision = true;
			if(coll.gameObject.tag == "Platform"){
				AttributeComponent attributes = (AttributeComponent) this.gameObject.GetComponent (typeof(AttributeComponent));
				attributes.health -= 100;
			}
		}
	}

	void OnCollisionExit2D(Collision2D coll){
		collision = false;
	}

}


