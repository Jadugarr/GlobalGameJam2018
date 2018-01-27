using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ducking : MonoBehaviour {

	//public GameObject player;

	private bool duckSwitch;

	void Start(){
		duckSwitch = true;
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)){
			if(duckSwitch){
				Vector3 currentPosition = transform.position;
				currentPosition.y -= 0.25f;
				transform.position = currentPosition;
				duckSwitch = false;
			} else{
				Vector3 currentPosition = transform.position;
				currentPosition.y += 0.25f;
				transform.position = currentPosition;
				duckSwitch = true;
			}
		}
	}
}
