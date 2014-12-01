using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	GameObject go;
	GameController gc;

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
		animator = this.GetComponent<Animator> ();
		go = GameObject.Find ("GameController");
		gc = go.GetComponent<GameController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.rigidbody2D.velocity.x == 0 && transform.rigidbody2D.velocity.y < 0.01f) {
			Idle();
		}
		if (Input.anyKey == false) {
			Idle ();	
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			//Debug.Log("Pressed Right Arrow");
			MoveRight();	
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			//Debug.Log("Pressed Left Arrow");
			MoveLeft();	
		}
		if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.Space) ) {
			//Debug.Log("Pressed Jump Button");
			Jump();
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Enemy") {
			if (gc.lives > 1){
				gc.SubtractLife();
			}
			else {
				gc.lives = 3;
				Application.LoadLevel("Main");
			}
		}
	}

	void OnTriggerEnter2D (Collider2D col){
		if (col.tag == "Door") {
			gc.prevLevel = Application.loadedLevelName;
			//Application.LoadLevel(Application.loadedLevel);
			if (Application.loadedLevelName.Equals("Grassland")){
				Debug.Log ("Touched door in Grassland");
				Application.LoadLevel("Main");
			}
			if (Application.loadedLevelName.Equals("Cave")){
				Debug.Log("Touched door in Cave");
				Application.LoadLevel("Main");
			}
		}
		if (col.tag == "Finish") {
			Debug.Log ("Touched finish");	
			if (gc.HasKey()){
				Application.LoadLevel ("EndScreen");
			}
		}
		if (col.tag == "Key") {
			Debug.Log("Key");
			Destroy(col.gameObject);
			gc.hasKey = true;
		}
		if (col.tag == "Heart") {
			Debug.Log(gc.GetNumLives());
			gc.AddLife();
			Destroy(col.gameObject);
		}
		if (col.tag == "Star") {
			Debug.Log(gc.GetNumLives().ToString());
			gc.Invincibility();
			Destroy(col.gameObject);
		}
		if (col.tag == "Water" || col.tag == "Lava") {
			if (gc.lives >= 2){
				gc.SubtractLife();
				Application.LoadLevel(Application.loadedLevelName);
			}
			else {
				Application.LoadLevel ("Main");
			}
		}
	}

	void Idle(){
		animator.SetInteger ("AnimationToPlay", IDLE);
	}
	void MoveRight(){
		if (playerDirection == -1){
			playerDirection *= -1;
			scale = transform.localScale;
			scale.x *= -1;
			transform.localScale = scale;
		}

		Vector3 position = transform.position;
		position.x = position.x + horizontalSpeed;
		transform.position = position;
	}
	void MoveLeft(){
		if (playerDirection == 1){
			playerDirection *= -1;
			scale = transform.localScale;
			scale.x *= -1;
			transform.localScale = scale;
		}

		if (transform.rigidbody2D.velocity.y > 0.01f) {
			Vector3 position = transform.position;
			position.x = position.x - horizontalSpeed * 0.5f;
			transform.position = position;
		}
		else {
			Vector3 position = transform.position;
			position.x = position.x - horizontalSpeed;
			transform.position = position;
		}
	}
	void Jump(){
		if (Mathf.Abs(transform.rigidbody2D.velocity.y) < 0.1f) {
			animator.SetInteger("AnimationToPlay", JUMP);
			transform.rigidbody2D.AddForce (Vector3.up * verticalSpeed);
		}
	}
}
