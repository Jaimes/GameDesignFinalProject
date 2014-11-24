using UnityEngine;
using System.Collections;

public class PlayerOnMapController : MonoBehaviour {

	public float horizontalSpeed = 0.1f;
	public float verticalSpeed = 0.1f;
	public int playerDirection = -1;
	Vector3 scale;

	// Use this for initialization
	void Start () {
		Debug.Log ("Started");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.RightArrow)) {
			Debug.Log("Pressed Right Arrow");
			MoveRight();	
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			Debug.Log("Pressed Left Arrow");
			MoveLeft();	
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			Debug.Log ("Pressed Up Arrow");
			MoveUp();
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			Debug.Log("Pressed Down Arrow");
			MoveDown();
		}
	}

	void MoveRight(){
		Debug.Log ("Moving Right");
		Vector3 position = transform.position;
		position.x = position.x + horizontalSpeed;
		transform.position = position;
		Debug.Log ("Moved Right");
	}
	void MoveLeft(){
		Debug.Log ("Moving Left");
		Vector3 position = transform.position;
		position.x = position.x - horizontalSpeed;
		transform.position = position;
		Debug.Log ("Moved Left");
	}
	void MoveUp(){
		Debug.Log ("Moving Up");
		Vector3 position = transform.position;
		position.y = position.y + verticalSpeed;
		transform.position = position;
		Debug.Log ("Moved Up");
	}
	void MoveDown(){
		Debug.Log ("Moving Down");
		Vector3 position = transform.position;
		position.y = position.y - verticalSpeed;
		transform.position = position;
		Debug.Log ("Moved Down");
	}
}
