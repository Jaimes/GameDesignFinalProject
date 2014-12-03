using UnityEngine;
using System.Collections;

public class GhostControllerScript : MonoBehaviour {

	public float horizontalVelocity = 0.1f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 position = transform.position;
		position.x -= horizontalVelocity;
		transform.position = position;
	}
}
