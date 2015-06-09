using UnityEngine;
using System.Collections;

public class LightRotator : MonoBehaviour {

	public float angle = 0.01f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.RotateAround (new Vector3 (0, 0, 0), new Vector3 (0, 1, 0), angle);
	}
}
