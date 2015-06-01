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
	void OnCollisionEnter2D(){
		if (!collision) {
			collision = true;
			Debug.Log ("Hallo");
		}
	}

	void OnCollisionExit2D(){
		OnCollisionExit2D = false;
		Debug.Log ("Exit");
	}

}


