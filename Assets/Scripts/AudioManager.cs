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
    public AudioClip beepSound;
    public AudioClip terminalSuccessSound;
    public AudioClip mechanicalChangeSound;
    public AudioClip heavyBreathingSound;

    public AudioSource playerBackSource;
    public AudioSource playerFrontSource;
    public AudioSource radioSource;
    public AudioSource terminalSource;
    public AudioSource clockSource;

    //private static AudioManager Instance;
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

    /*
    void Awake()
    {
        if (Instance != null)
            GameObject.Destroy(GM);
        else
            Instance = this;

        DontDestroyOnLoad(this);
    }*/

    // Use this for initialization
    void Start ()
    {
        //beepSound = Resources.Load<AudioClip>("Assets/Audio/bee.wav");

        //PlayPickUpSound();
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

    public void PlayClockBeepSound()
    {
        clockSource.clip = beepSound;
        clockSource.Play();
    }

    public void PlayTerminalSuccessSound()
    {
        terminalSource.clip = terminalSuccessSound;
        terminalSource.Play();
    }

    public void PlayMechanicalChangeSound()
    {
        playerBackSource.clip = mechanicalChangeSound;
        playerBackSource.Play();
    }

    public void PlayHeavyBreathingSound()
    {
        playerBackSource.clip = heavyBreathingSound;
        playerBackSource.Play();
    }


    public void PlayFinalSound(IEvent e)
    {
        Debug.Log("TODO: Play final sound!");
    }
}
