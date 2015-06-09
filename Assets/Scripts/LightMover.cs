using UnityEngine;
using System.Collections;

public class LightMover : MonoBehaviour {
	public float step;
	private int move = 1;
	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (10, 5, 0);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x + step * move, transform.position.y, transform.position.z);
		if (transform.position.x < -10 || transform.position.x > 10) {
			//Moves a LightSource from left to right and back again to demonstrate normalmap of toonshader
			move *= -1;
		}
	}

}
