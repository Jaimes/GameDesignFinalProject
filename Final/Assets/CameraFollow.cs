﻿using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	public Transform character;
	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;
	
	void Start(){
		
	}
	
	// Update is called once per frame
	void Update () {
		if (character) {
			Vector3 point = camera.WorldToViewportPoint(character.position);
			Vector3 delta = character.position - camera.ViewportToWorldPoint (new Vector3(0.5f, 0.5f, point.z));
			Vector3 destination = transform.position + delta;
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		}
	}
}

