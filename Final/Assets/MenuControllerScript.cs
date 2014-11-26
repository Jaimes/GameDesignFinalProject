using UnityEngine;
using System.Collections;

public class MenuControllerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKey){
			if (Application.loadedLevelName == "StartScreen") {
				Application.LoadLevel("Main");	
			}
			if (Application.loadedLevelName == "EndScreen") {
				Application.LoadLevel("StartScreen");	
			}
		}
	}
}
