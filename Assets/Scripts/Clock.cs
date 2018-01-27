using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{

    public TextMesh textMesh;
    public float timeLeft;

	// Use this for initialization
	void Start ()
	{
	    timeLeft = 60 * 3 + 5;
	    textMesh.text = "00:00";
	}
	
	// Update is called once per frame
	void Update ()
	{
	    timeLeft -= Time.deltaTime;

	    int minutes = (int) timeLeft / 60;
	    int seconds = (int) (timeLeft - (minutes * 60));

	    textMesh.text = string.Format("{0:00}:{1:00}", minutes, seconds);
	}
}
