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
	HealthSystem healthSystem;

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
		ECSEngine.addComponentType (typeof(AttributeComponent));
		ECSEngine.addComponentType (typeof(EnemyComponent));
		ECSEngine.addComponentType (typeof(InputComponent));
		ECSEngine.addComponentType (typeof(MovementStateComponent));
		ECSEngine.addComponentType (typeof(PlayerComponent));

		XMLParser.gameObjectsThroughXML ("Assets/Resources/XML_Files/Level_1.xml");

		inputSystem = new InputSystem ();
		physicsSystem = new PhysicsSystem ();
		healthSystem = new HealthSystem ();

		ECSEngine.addSystem (inputSystem);
		ECSEngine.addSystem (physicsSystem);
		ECSEngine.addSystem (healthSystem);
	}

	void Update(){
		ECSEngine.mainLoop (Time.deltaTime);
	}

	public void generateAllEntities(){
		foreach (GameObject g in EntityManager.getGameObjects()) {
			Instantiate(g);
		}
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
		rigidBody.transform.localPosition = renderer.sprite.bounds.center;
		MovementStateComponent movement = (MovementStateComponent) EntityManager.addComponent (g, typeof(MovementStateComponent));
		AttributeComponent attributes = (AttributeComponent)EntityManager.addComponent (g, typeof(AttributeComponent));
	}

	public void generateEnemy(GameObject g){
		EntityManager.generateEntity (g);
		EntityManager.addComponent(g, typeof(EnemyComponent));
	}

	public void generatePlatform(GameObject g){
		BoxCollider2D collider = (BoxCollider2D) EntityManager.addComponent (g, typeof(BoxCollider2D));
		collider.size = new Vector2 (100, 1);
		Sprite platform = Resources.Load ("Sprites/Environment/Block", typeof(Sprite)) as Sprite;
		Bounds bounds = platform.bounds;
		bounds.max = new Vector3 (50, 1, 0);
		bounds.min = new Vector3 (-50, -1, 0);
		SpriteRenderer renderer = (SpriteRenderer)EntityManager.addComponent (g, typeof(SpriteRenderer));
		renderer.sprite = platform;
	}


}


