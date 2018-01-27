using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamera : MonoBehaviour {


    public float speedH = 2.0f;
    public float speedV = 2.0f;

    public float yaw = 0.0f;
    public float pitch = 0.0f;

    // Use this for initialization
    void Start ()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
	
	// Update is called once per frame
	void Update () {
	    yaw += speedH * Input.GetAxis("Mouse X");
	    pitch -= speedV * Input.GetAxis("Mouse Y");

        yaw = Mathf.Clamp(yaw, -60, 60);
	    pitch = Mathf.Clamp(pitch, -25, 75);

	    transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}
