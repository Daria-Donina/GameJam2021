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

    private AudioSource audioSrc;
    public bool TimerOn
	{
        get => timerOn;
        set
		{
            if (value == false && timerOn)
			{
                TimerEnded?.Invoke(this, EventArgs.Empty);
                timerText.enabled = false;
			}

            timerOn = value;
        }
	}

	public float ElapsedTime
	{
        get => elapsedTime;
        set
		{
            if (value < 6 && elapsedTime > 6)
			{
                audioSrc.PlayOneShot(audioSrc.clip);
            }
            elapsedTime = value;
        }
	}

	public static event EventHandler<EventArgs> TimerEnded;

    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<Text>();
        timerText.text = "00:00";
        ElapsedTime = startTime;
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ElapsedTime > 0 && TimerOn)
		{
            ElapsedTime -= Time.deltaTime;

            timePlaying = TimeSpan.FromSeconds(ElapsedTime);

            timerText.text = timePlaying.ToString("mm':'ss");
        }
        else
		{
            TimerOn = false;
		}
    }

    private const float startTime = 60;
    public void StartTimer()
	{
        ElapsedTime = startTime;
        TimerOn = true;
        timerText.enabled = true;
	}
}
