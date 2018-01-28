using System.Collections;
using System.Collections.Generic;
using Events;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioClip buttonSound;
    public AudioClip spookySound;
    public AudioClip terminalButtonSound;
    public AudioClip radioSound;
    public AudioClip pickUpSound;

    public AudioSource playerBackSource;
    public AudioSource playerFrontSource;
    public AudioSource radioSource;
    public AudioSource terminalSource;

    //private static AudioManager instance = new AudioManager();
    private EventManager eventManager = EventManager.Instance;

    // Singleton instance
    /*
    public static AudioManager Instance
    {
        get
        {
            return AudioManager.instance;
        }
    }*/

    // Use this for initialization
    void Start ()
	{
        PlayPickUpSound();
        eventManager.RegisterForEvent(EventTypes.AllTriggersActivated, PlayFinalSound);
	}

    public void PlayTerminalButtonSound()
    {
        terminalSource.clip = terminalButtonSound;
        terminalSource.Play();
    }

    public void PlayRadioSound()
    {
        radioSource.clip = radioSound;
        radioSource.Play();
    }

    public void PlayPickUpSound()
    {
        playerFrontSource.clip = pickUpSound;
        playerFrontSource.Play();
    }

    public void PlayButtonSound()
    {
        playerFrontSource.clip = buttonSound;
        playerFrontSource.Play();
    }

    public void PlaySpookyPlayerSound()
    {
        playerBackSource.clip = spookySound;
        playerBackSource.Play();
    }

    public void PlayFinalSound(IEvent e)
    {
        Debug.Log("TODO: Play final sound!");
    }
}
