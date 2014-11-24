using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Animator animator;
	const int IDLE = 0;
	const int WALK = 1;
	const int JUMP = 2;

	public float horizontalSpeed = 0.01f;
	public float verticalSpeed = 300.0f;
	public int playerDirection = -1;
	Vector3 scale;

	// Use this for initialization
	void Start () {
		Debug.Log ("Started");
		//animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		//if (transform.rigidbody2D.velocity.x == 0 && transform.rigidbody2D.velocity.y < 0.01f) {
		//	Idle();
		//}
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

	void Idle(){
		//animator.SetInteger ("AnimationToPlay", IDLE);
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
	void Jump(){
		// jump
	}
}
