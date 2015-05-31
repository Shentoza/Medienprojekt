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
	PhysicsSystem physicsSystem;

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
				case "Platform":
					generatePlatform (g);
					break;
				default:
					break;
			}
		}
		EntityManager.printStatus ();

		initializeGame ();
	}

	void initializeGame(){
		inputSystem = new InputSystem ();
		physicsSystem = new PhysicsSystem ();
		ECSEngine.addSystem (inputSystem);
		ECSEngine.addSystem (physicsSystem);
	}

	void Update(){
		ECSEngine.mainLoop (Time.deltaTime);
	}

	public void generatePlayer(GameObject g){
		EntityManager.addComponent(g, typeof(PlayerComponent));
		InputComponent inputComponent = (InputComponent) EntityManager.addComponent(g, typeof(InputComponent));
		Instantiate(new GameObject("Trottel"));
		inputComponent.inputUp 	= "w";
		inputComponent.inputLeft = "a";
		inputComponent.inputRight = "d";
		inputComponent.inputAttack = "j";
		inputComponent.inputAction1 = "o";
		inputComponent.inputAction2 = "p";
		Sprite ryu = Resources.Load("Sprites/Characters/Ryu_Base", typeof(Sprite)) as Sprite;
		SpriteRenderer renderer = (SpriteRenderer) EntityManager.addComponent (g, typeof(SpriteRenderer));
		renderer.sprite = ryu;
		BoxCollider2D collider = (BoxCollider2D)EntityManager.addComponent (g, typeof(BoxCollider2D));
		collider.size = renderer.bounds.size;
		Rigidbody2D rigidBody = (Rigidbody2D)EntityManager.addComponent (g, typeof(Rigidbody2D));
		rigidBody.gravityScale = 0;
		EntityManager.addComponent (g, typeof(MovementStateComponent));

	}

	public void generateEnemy(GameObject g){
		EntityManager.generateEntity (g);
		EntityManager.addComponent(g, typeof(EnemyComponent));
	}

	public void generatePlatform(GameObject g){
		BoxCollider2D collider = (BoxCollider2D) EntityManager.addComponent (g, typeof(BoxCollider2D));
		collider.size = new Vector2 (10, 1);
	}


}


