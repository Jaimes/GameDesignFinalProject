using UnityEngine;
using System.Collections;

public class SnailControllerScript : MonoBehaviour {

	public float horizontalVelocity = 0.08f;
	public int direction = -1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 position = transform.position;
		position.x += horizontalVelocity * direction;
		transform.position = position;
	}

	void OnCollisionEnter2D(Collision2D col){
		Debug.Log ("Collision detected");
		if (col.gameObject.tag == "GrassEdge") {
			Debug.Log ("hit grass edge");
			direction *= -1;
			Vector3 scale = transform.localScale;
			scale.x *= -1;
			transform.localScale = scale;
		}
	}
}
