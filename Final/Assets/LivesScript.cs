using UnityEngine;
using System.Collections;

public class LivesScript : MonoBehaviour {

	public SpriteRenderer heartHolder;
	GameObject go;
	GameController gc;
	
	/*Drag your heart sprites here in the Inspector
   You will need a sprite for 1 heart, two hearts, three hearts, etc.
   Place them in order from one heart - highest number of hearts. */
	public Sprite[] hearts;
	
	void start(){
		//Grab the SpriteRenderer of this component
		heartHolder = this.GetComponent <SpriteRenderer>; //Something like that
		go = GameObject.Find ("GameController");
		gc = go.GetComponent<GameController> ();
	}
	
	void Update(){
		/*Maybe make a bool here to 
       check if the lives have changed */
		
		switch(gc.lives){
			case 1: {
				heartHolder.sprite = hearts[0];
				break;
			}
			case 2:{
				heartHolder.sprite = hearts[1];
				break;
			}
			case 3:{
				heartHolder.sprite = hearts[2];
				break;
			}
			default: {
				heartHolder.sprite = null;
				break;
			}
		}
	}
}
