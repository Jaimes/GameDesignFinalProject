using UnityEngine;
using System.Collections;

public class PlayerOnMapController : MonoBehaviour {

	private Animator animator;
	const int IDLE = 0;
	const int UP = 1;
	const int RIGHT = 2;
	const int DOWN = 3;
	const int LEFT = 4;

	GameObject go;
	GameController gc;

	public float horizontalSpeed = 0.1f;
	public float verticalSpeed = 0.1f;
	public int playerDirection = -1;
	Vector3 scale;

	// Use this for initialization
	void Start () {
		Debug.Log ("Started");
		animator = this.GetComponent<Animator>();

		go = GameObject.Find ("GameController");
		gc = go.GetComponent<GameController> ();

		if (gc.prevLevel == "Grassland") {
			Vector3 position = new Vector3(5.691547f, 2.372675f, 0f);
			transform.position = position;
		}
		else if (gc.prevLevel == "Cave"){
			Vector3 position = new Vector3(-6.376614f, -6.736524f, 0f);
			transform.position = position;
		}
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
		if (!Input.anyKey) {
			animator.SetInteger("AnimationToPlay", IDLE);		
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
		if (col.tag == "Enemy") {
			Application.LoadLevel("Main");
		}
	}

	void MoveRight(){
		animator.SetInteger ("AnimationToPlay", RIGHT);

		Vector3 position = transform.position;
		position.x = position.x + horizontalSpeed;
		transform.position = position;
	}
	void MoveLeft(){
		animator.SetInteger ("AnimationToPlay", LEFT);

		Vector3 position = transform.position;
		position.x = position.x - horizontalSpeed;
		transform.position = position;
	}
	void MoveUp(){
		animator.SetInteger ("AnimationToPlay", UP);

		Vector3 position = transform.position;
		position.y = position.y + verticalSpeed;
		transform.position = position;
	}
	void MoveDown(){
		animator.SetInteger ("AnimationToPlay", DOWN);

		Vector3 position = transform.position;
		position.y = position.y - verticalSpeed;
		transform.position = position;
	}
}
