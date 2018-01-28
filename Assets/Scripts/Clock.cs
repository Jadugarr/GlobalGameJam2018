using System.Collections;
using System.Collections.Generic;
using Events;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public TextMesh textMesh;
    public float timeLeft;
    private bool fired;

    public AudioManager audioManager;
    private bool beep10;
    private bool beep3;
    private bool beep2;
    private bool beep1;

    // Use this for initialization
    void Start()
    {
        fired = false;
        textMesh.text = "00:00";

        beep10 = false;
        beep3 = false;
        beep2 = false;
        beep1 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!fired)
        {
            timeLeft -= Time.deltaTime;

            int minutes = (int) timeLeft / 60;
            int seconds = (int) (timeLeft - (minutes * 60));

            textMesh.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            if (audioManager)
            {
                if (timeLeft < 11 && !beep10)
                {
                    audioManager.PlayClockBeepSound();
                    beep10 = true;
                }

                if (timeLeft < 4 && !beep3)
                {
                    audioManager.PlayClockBeepSound();
                    beep3 = true;
                }

                if (timeLeft < 3 && !beep2)
                {
                    audioManager.PlayClockBeepSound();
                    beep2 = true;
                }

                if (timeLeft < 2 && !beep1)
                {
                    audioManager.PlayClockBeepSound();
                    beep1 = true;
                }
            }

            if (timeLeft <= 0)
            {
                OnTimerDown();
                fired = true;

                textMesh.text = "00:00";
            }
        }
    }

    void OnTimerDown()
    {
        EventManager.Instance.FireEvent(EventTypes.TimeOut, null);
        audioManager.PlayHeavyBreathingSound();
    }
}