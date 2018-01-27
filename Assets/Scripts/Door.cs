using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float openingSpeed = 50;
    public DoorState state = DoorState.Closed;

    public Transform rotationHelper;


	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (state == DoorState.Opening)
	    {
	        if (rotationHelper.rotation.y >= -0.65)
	        {
	            rotationHelper.Rotate(-Vector3.up * openingSpeed * Time.deltaTime);
	        }
	        else
	        {
	            state = DoorState.Open;
            }
        }
        else if (state == DoorState.Closing)
	    {
	        if (rotationHelper.rotation.y <= 0.0)
	        {
	            rotationHelper.Rotate(Vector3.up * openingSpeed * Time.deltaTime);
	        }
	        else
	        {
	            state = DoorState.Closed;
            }
        }
	}
}

public enum DoorState
{
    Open,
    Closed,
    Opening,
    Closing
}