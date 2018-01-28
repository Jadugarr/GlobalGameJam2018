﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Events;

[RequireComponent(typeof(HighlightObject))]
public class InteractableObject : MonoBehaviour{
	public bool isButton;
	public int id;

	private EventManager eventManager = EventManager.Instance;
    private AudioManager audioManager;

    void Start()
    {
        audioManager = GameObject.FindObjectOfType<AudioManager>();
    }

	public void ButtonPressed(){
		Debug.Log ("button pressed!!!");
		eventManager.FireEvent (EventTypes.ButtonPressed, new ButtonPressedEvent (id));
	    audioManager.PlayButtonSound();
	}
}
