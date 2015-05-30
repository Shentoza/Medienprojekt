using System;
using UnityEngine;
using ECS;
using System.Collections;

public class Game : MonoBehaviour
{
	//The title of the game
	public String gameTitle = "Default Title";
	
	//The controls. Please use a fine description.
	public String controls = "WASD";

	//Default value = false. If description should be logged, choose the gameObject 
	//which holds this script and enable printControls in Components Game script
	public bool printControls = false;

	InputSystem inputSystem;

	void Start ()
	{
		Debug.Log ("Game start");
		Debug.Log ("Welcome to " + gameTitle);
		if (printControls) {
			Debug.Log (controls);
		}
		foreach (GameObject g in GameObject.FindObjectsOfType(typeof(GameObject))) {
			switch(g.tag){
				case "Player":
					generatePlayer (g);
					break;
				case "Enemy":
					generateEnemy(g);
					break;
				case "Object":
					
				default:
					break;
			}
		}
		EntityManager.printStatus ();

		initializeGame ();
	}

	void initializeGame(){
		inputSystem = new InputSystem ();
		ECSEngine.addSystem (inputSystem);
	}

	void Update(){
		ECSEngine.mainLoop (Time.deltaTime);
	}

	public void generatePlayer(GameObject g){
		EntityManager.addComponent(g, typeof(PlayerComponent));
		InputComponent inputComponent = (InputComponent) EntityManager.addComponent(g, typeof(InputComponent));
		inputComponent.inputUp 	= "w";
		inputComponent.inputLeft = "a";
		inputComponent.inputRight = "d";
		inputComponent.inputAttack = "j";
		inputComponent.inputAction1 = "o";
		inputComponent.inputAction2 = "p";
	}

	public void generateEnemy(GameObject g){
		EntityManager.generateEntity (g);
		EntityManager.addComponent(g, typeof(EnemyComponent));
	}


}


