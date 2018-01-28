using System.Collections;
using System.Collections.Generic;
using Events;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioClip buttonSound;
    public AudioClip spookySound;

    public AudioSource behindPlayerSource;
    public AudioSource inFrontOfPlayerSource;

    private static AudioManager instance = new AudioManager();
    private EventManager eventManager = EventManager.Instance;

    // Singleton instance
    public static AudioManager Instance
    {
        get
        {
            return AudioManager.instance;
        }
    }

    // Use this for initialization
    void Start ()
	{
        PlaySpookyPlayerSound();
        eventManager.RegisterForEvent(EventTypes.AllTriggersActivated, PlayFinalSound);
	}

    public void PlayButtonSound()
    {
        inFrontOfPlayerSource.clip = buttonSound;
        inFrontOfPlayerSource.Play();
    }

    public void PlaySpookyPlayerSound()
    {
        behindPlayerSource.clip = spookySound;
        behindPlayerSource.Play();
    }

    public void PlayFinalSound(IEvent e)
    {
        Debug.Log("TODO: Play final sound!");
    }
}
