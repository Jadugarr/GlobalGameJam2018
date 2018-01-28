using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamera : MonoBehaviour {


    public float speedH = 2.0f;
    public float speedV = 2.0f;

    public float yaw = 0.0f;
    public float pitch = 0.0f;

    private bool isLocked;

    public int pitchUpperBound, pitchLowerBound, yawLeftBound, yawRightBound;

    // Use this for initialization
    void Start ()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        isLocked = false;
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log("is locked: " + isLocked);
        if(!isLocked){
            yaw += speedH * Input.GetAxis("Mouse X");
            pitch -= speedV * Input.GetAxis("Mouse Y");

            yaw = Mathf.Clamp(yaw, yawLeftBound, yawRightBound);
            pitch = Mathf.Clamp(pitch, pitchUpperBound, pitchLowerBound);

            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }
    }

    public void UnlockMovement(){
        isLocked = false;
    }

    public void LockMovement(){
        isLocked = true;
    }
}
