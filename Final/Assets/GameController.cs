using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public int lives = 3;
	public bool isInvincible = false;
	public bool hasKey = false;
	public string prevLevel;

	public void Awake(){
		DontDestroyOnLoad (gameObject);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void ItemCollected(string item){
		Debug.Log (item);
		if (item.Equals ("Heart")) {
			AddLife();
		}
		if (item.Equals ("Star")) {
			Invincibility();
		}
		if (item.Equals ("Key")) {
			hasKey = true;	
		}
	}

	public void AddLife(){
		if (lives <= 2) {
			lives++;	
		}
	}
	public void SubtractLife(){
		if (lives > 1) {
			lives--;	
		}
		else {
			lives = 0;
			Application.LoadLevel ("EndScreen");
		}
	}
	public float GetNumLives(){
		return this.lives;
	}

	public bool HasKey(){
		return hasKey;
	}
	public void FinishGame(){
		Application.LoadLevel ("EndScreen");
	}

	void Invincibility(){
		// add glow or some visual effect (brightness/contrast)
		// use timer to determine when to switch back to normal
		// disable reaction to enemies in character controller
	}
}
