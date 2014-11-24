using UnityEngine;
using System.Collections;

public class PlayerOnMapController : MonoBehaviour {

	private Animator animator;
	const int IDLE = 0;
	const int WALK = 1;
	const int JUMP = 2;

	public float horizontalSpeed = 0.1f;
	public float verticalSpeed = 0.1f;
	public int playerDirection = -1;
	Vector3 scale;

	// Use this for initialization
	void Start () {
		Debug.Log ("Started");
		animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.RightArrow)) {
			MoveRight();	
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			MoveLeft();	
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			MoveUp();
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			MoveDown();
		}
	}

	void OnTriggerEnter2D (Collider2D col){
		Debug.Log ("Trigger detected");
		if (col.tag == "GrasslandDoor") {
			Debug.Log("Enter grassland");
			Application.LoadLevel("Grassland");
		}
		if (col.tag == "CaveDoor") {
			Debug.Log("Enter cave");
			Application.LoadLevel("Cave");
		}
	}

	void MoveRight(){
		animator.SetInteger ("AnimationToPlay", WALK);

		Vector3 position = transform.position;
		position.x = position.x + horizontalSpeed;
		transform.position = position;
	}
	void MoveLeft(){
		animator.SetInteger ("AnimationToPlay", WALK);

		Vector3 position = transform.position;
		position.x = position.x - horizontalSpeed;
		transform.position = position;
	}
	void MoveUp(){
		animator.SetInteger ("AnimationToPlay", WALK);

		Vector3 position = transform.position;
		position.y = position.y + verticalSpeed;
		transform.position = position;
	}
	void MoveDown(){
		animator.SetInteger ("AnimationToPlay", WALK);

		Vector3 position = transform.position;
		position.y = position.y - verticalSpeed;
		transform.position = position;
	}
}
