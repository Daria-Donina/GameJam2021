using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text timerText;

    private TimeSpan timePlaying;

    private float elapsedTime;

    private bool timerOn = true;
    public bool TimerOn
	{
        get => timerOn;
        set
		{
            if (value == false && timerOn)
			{
                TimerEnded?.Invoke(this, EventArgs.Empty);
			}

            timerOn = value;
        }
	}

    public static event EventHandler<EventArgs> TimerEnded;

    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<Text>();
        timerText.text = "Time: 00:00";
        elapsedTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (elapsedTime > 0 && TimerOn)
		{
            elapsedTime -= Time.deltaTime;

            timePlaying = TimeSpan.FromSeconds(elapsedTime);

            timerText.text = "Time: " + timePlaying.ToString("mm':'ss");
        }
        else
		{
            TimerOn = false;
		}
    }

    private const float startTime = 60;
    public void StartTimer()
	{
        elapsedTime = startTime;
        TimerOn = true;
	}
}
