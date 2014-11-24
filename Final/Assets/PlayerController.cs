using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Animator animator;
	const int IDLE = 0;
	const int WALK = 1;
	const int JUMP = 2;

	public float horizontalSpeed = 0.1f;
	public float verticalSpeed = 200.0f;
	public int playerDirection = -1;
	Vector3 scale;

	// Use this for initialization
	void Start () {
		Debug.Log ("Started");
		animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.rigidbody2D.velocity.x == 0 && transform.rigidbody2D.velocity.y < 0.01f) {
			Idle();
		}
		if (Input.anyKey == false) {
			Debug.Log("Idle");
			Idle ();	
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			Debug.Log("Pressed Right Arrow");
			MoveRight();	
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			Debug.Log("Pressed Left Arrow");
			MoveLeft();	
		}
		if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.Space) ) {
			Debug.Log("Pressed Jump Button");
			Jump();
		}
	}

	void OnTriggerEnter2D (Collider2D col){
		Debug.Log ("Collision detected");
		if (col.tag == "Door") {
			//Application.LoadLevel(Application.loadedLevel);
			if (Application.loadedLevelName.Equals("Grassland")){
				Debug.Log ("Touched door in Grassland");
			}
			if (Application.loadedLevelName.Equals("Cave")){
				Debug.Log("Touched door in Cave");
			}
		}
		if (col.tag == "Finish") {
			//Application.LoadLevel(Application.loadedLevel);
			Debug.Log ("Touched finish");	
			//Application.LoadLevel(Application.loadedLevel + 1);
		}
		if (col.tag == "Key") {
			Destroy(col.gameObject);
			// tell GameController player has collected key
		}
	}

	void Idle(){
		animator.SetInteger ("AnimationToPlay", IDLE);
	}
	void MoveRight(){
		Debug.Log ("Moving Right");

		if (playerDirection == -1){
			Debug.Log("Changed direction");
			playerDirection *= -1;
			scale = transform.localScale;
			scale.x *= -1;
			transform.localScale = scale;
		}

		Vector3 position = transform.position;
		position.x = position.x + horizontalSpeed;
		transform.position = position;
		Debug.Log ("Moved Right");
	}
	void MoveLeft(){
		Debug.Log ("Moving Left");

		if (playerDirection == 1){
			Debug.Log("Changed direction");
			playerDirection *= -1;
			scale = transform.localScale;
			scale.x *= -1;
			transform.localScale = scale;
		}

		if (transform.rigidbody2D.velocity.y > 0.01f) {
			Vector3 position = transform.position;
			position.x = position.x - horizontalSpeed * 0.5f;
			transform.position = position;
			Debug.Log ("Moved Left");
		}
		else {
			Vector3 position = transform.position;
			position.x = position.x - horizontalSpeed;
			transform.position = position;
			Debug.Log ("Moved Left");
		}
	}
	void Jump(){
		if (Mathf.Abs(transform.rigidbody2D.velocity.y) < 0.1f) {
			animator.SetInteger("AnimationToPlay", JUMP);
			transform.rigidbody2D.AddForce (Vector3.up * verticalSpeed);
			Debug.Log ("Jumped");
		}
	}
}
