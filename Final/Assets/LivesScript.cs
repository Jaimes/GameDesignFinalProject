using UnityEngine;
using System.Collections;

public class LivesScript : MonoBehaviour {

	GameObject go;
	GameController gc;

	public Texture2D[] hearts;
	
	void start(){
		//Grab the SpriteRenderer of this component
		//heartHolder = this.GetComponent <SpriteRenderer>; //Something like that
		go = GameObject.Find ("GameController");
		gc = go.GetComponent<GameController> ();

		switch(gc.lives){
			case 1: {
				this.guiTexture.texture = hearts[0];
				break;
			}
			case 2:{
				this.guiTexture.texture = hearts[1];
				break;
			}
			case 3:{
				this.guiTexture.texture = hearts[2];
				break;
			}
			default: {
				this.guiTexture.texture = null;
				break;
			}
		}
	}
	
	void OnGUI(){	
		Debug.Log ("Player has " + gc.lives + " lives.");
		switch(gc.lives){
			case 1: {
				this.guiTexture.texture = hearts[0];
				break;
			}
			case 2:{
			this.guiTexture.texture = hearts[1];
				break;
			}
			case 3:{
			this.guiTexture.texture = hearts[2];
				break;
			}
			default: {
				this.guiTexture.texture = null;
				break;
			}
		}
	}

	void Update(){

	}
}
