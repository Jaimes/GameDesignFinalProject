using UnityEngine;
using System.Collections;

public class KeyIndicatorScript : MonoBehaviour {

	GameObject go;
	GameController gc;

	public Texture2D keyOutline;
	public Texture2D keyFilled;

	// Use this for initialization
	void Start () {
		go = GameObject.Find ("GameController");
		gc = go.GetComponent<GameController> ();

		if (gc.hasKey) {
			this.guiTexture.texture = keyFilled;	
		}
		else {
			this.guiTexture.texture = keyOutline;	
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
