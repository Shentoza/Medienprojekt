using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {


	//RigidBody component
	private Rigidbody2D playerRigidBody2D;
	//variable to trak how  much movement is needed from input
	private float movePlayerVector;

	//determining which wa the player is currently facing
	private bool facingRight;

	//Speed modifier
	public float speed = 4.0f;

	//private Animator anim;

	private GameObject playerSprite;

	void Awake()
	{
		playerRigidBody2D = (Rigidbody2D)GetComponent (typeof(Rigidbody2D));

	}
	// Update is called once per frame
	void Update () {
		movePlayerVector = Input.GetAxis ("Horizontal");
		playerRigidBody2D.velocity = new Vector2 (movePlayerVector * speed, playerRigidBody2D.velocity.y);


		//anim.SetFloat ("speed", Mathf.Abs (movePlayerVector));
	}

}