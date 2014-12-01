using UnityEngine;
using System.Collections;

public class LivesScript : MonoBehaviour {

	GameObject go;
	GameController gc;
	//public GUIText livesText;
	
	void start(){
		go = GameObject.Find ("GameController");
		gc = go.GetComponent<GameController> ();
		gc.livesText = this.guiText;
	}
	
	void Update(){	
		//livesText.text = gc.lives.ToString ();
	}
}
