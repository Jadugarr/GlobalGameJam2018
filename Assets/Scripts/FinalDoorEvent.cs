using System.Collections;
using System.Collections.Generic;
using Events;
using UnityEngine;

public class FinalDoorEvent : MonoBehaviour {

    private EventManager eventManager = EventManager.Instance;

    // Use this for initialization
    void Start () {
        eventManager.RegisterForEvent(EventTypes.AllTriggersActivated, OnFinalTrigger);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnFinalTrigger(IEvent evtData)
    {
        GameObject.Find("Door").GetComponent<Door>().state = DoorState.Opening;
    }
}
