
using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public bool isInvincible = false;
	public bool hasKey = false;
	public string prevLevel;
	public GUIText helpText;

	public void Awake(){
		DontDestroyOnLoad (gameObject);
	}

	// Use this for initialization
	void Start () {
		helpText.gameObject.SetActive (false);
	}

	void OnLevelWasLoaded(){
		string currentLevelName = Application.loadedLevelName;
		if (currentLevelName == "Main") {
			StartCoroutine(ShowMessage("Find the key and unlock the door"));
		}
		else if (currentLevelName != "StartScreen" && currentLevelName != "EndScreen") {
			StartCoroutine(ShowMessage(currentLevelName));
		}

	}

	IEnumerator ShowMessage(string message){
		helpText.text = message;
		helpText.gameObject.SetActive(true);
		yield return new WaitForSeconds (2.0f);
		helpText.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

	}

	public bool HasKey(){
		return hasKey;
	}
	public void FinishGame(){
		Application.LoadLevel ("EndScreen");
	}

	public void Invincibility(){
		// add glow or some visual effect (brightness/contrast)
		// use timer to determine when to switch back to normal
		// disable reaction to enemies in character controller
	}
}
