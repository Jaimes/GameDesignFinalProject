using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GhostControllerScript enemy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevelName == "Main"){
			if (Random.Range (0, 100) == 2) {
				Debug.Log("Enemy spawned");
				float randomY = Random.Range (-90.0f,20.5f);
				randomY /= 10.0f;
				GhostControllerScript g = (GhostControllerScript)Instantiate(enemy, new Vector3(13.0f,randomY,0f), Quaternion.identity);
			}
		}
	}
}
