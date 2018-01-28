using System.Collections;
using System.Collections.Generic;
using Events;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public TextMesh textMesh;
    public float timeLeft;
    private bool fired;

    // Use this for initialization
    void Start()
    {
        fired = false;
        textMesh.text = "00:00";
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
    }
}