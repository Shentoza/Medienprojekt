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

	private Animator anim;

	private GameObject playerSprite;

	void Awake()
	{
		playerRigidBody2D = (Rigidbody2D)GetComponent (typeof(Rigidbody2D));
		playerSprite = transform.Find ("PlayerSprite").gameObject;
		anim = (Animator)playerSprite.GetComponent (typeof(Animator));
	}
	// Update is called once per frame
	void Update () {
		movePlayerVector = Input.GetAxis ("Horizontal");
		playerRigidBody2D.velocity = new Vector2 (movePlayerVector * speed, playerRigidBody2D.velocity.y);
		if (movePlayerVector > 0 && !facingRight)
			Flip();
		else if (movePlayerVector < 0 && facingRight)
			Flip();

		anim.SetFloat ("speed", Mathf.Abs (movePlayerVector));
	}
	void Flip()
	{
		facingRight = !facingRight;
		//Multiply players x local scale by -1
		Vector3 theScale = playerSprite.transform.localScale;
		theScale.x *= -1;
		playerSprite.transform.localScale = theScale;
	}
}