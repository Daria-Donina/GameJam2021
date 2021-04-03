using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float deltaTime = 1;

    private Text timerText;

    private TimeSpan timePlaying;
    private float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<Text>();
        timerText.text = "Time: 00:00";
    }

    // Update is called once per frame
    void Update()
    {
        //      if (Time.time > currentTime + deltaTime)
        //{
        //          currentTime = Time.time;
        //          text.text = currentTime.ToString()
        //}

        elapsedTime += Time.deltaTime;
        timePlaying = TimeSpan.FromSeconds(elapsedTime);

        timerText.text = "Time: " + timePlaying.ToString("mm':'ss");
    }
}
