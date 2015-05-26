using UnityEngine;

public class FollowCamera : MonoBehaviour {

	//distance in the x axis the player can move before the camera  follows
	public float xMargin = 1.5f;

	//same for y
	public float yMargin = 1.5f;

	//how smooth camera catches up
	public float xSmooth = 1.5f;

	public float ySmooth = 1.5f;

	private Vector2 maxXandY;

	private Vector2 minXandY;

	//Reference to the player's transform
	public Transform player;

	void Awake()
	{
		player = GameObject.Find ("roundy").transform;
		if(player == null)
		{
			Debug.LogError("Player object not found");
		}

		minXandY.x = -100;
		maxXandY.x = 100;

	}

	bool CheckXMargin()
	{
		//Returns true if distance between camera and player X AXIS is greater than x margin
		return Mathf.Abs (transform.position.x - player.position.x) > xMargin;
	}

	bool CheckYMargin()
	{
		return Mathf.Abs (transform.position.y - player.position.y) > yMargin;
	}

	void FixedUpdate()
	{
		// By default the target x and y coordinates of the camera
		// are it's current x and y coordinates.
		float targetX = transform.position.x;
		float targetY = transform.position.y;
		if (CheckXMargin ())
			targetX = Mathf.Lerp (transform.position.x, player.position.x, xSmooth * Time.fixedDeltaTime);
		if (CheckYMargin ())
			targetY = Mathf.Lerp (transform.position.y, player.position.y, ySmooth * Time.fixedDeltaTime);

		targetX = Mathf.Clamp (targetX, minXandY.x, maxXandY.x);
		targetY = Mathf.Clamp(targetX, minXandY.y, maxXandY.y);

		transform.position = new Vector3 (targetX, targetY, transform.position.z);
	}

}
