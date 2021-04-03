using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private int waveCounter;

    private Transform currentChild;

    public GameObject timerObject;
    private Timer timer;

    private void Spawn(object sender, EventArgs args)
	{
        currentChild = transform.GetChild(UnityEngine.Random.Range(0, 4));

        var spawner = currentChild.GetComponent<MonsterSpawner>();

        spawner.SpawnWaveOfEnemies();
        waveCounter++;
	}


    // Start is called before the first frame update
    void Start()
    {
        timer = timerObject.GetComponent<Timer>();
        Timer.TimerEnded += Spawn;
    }

    // Update is called once per frame
    void Update()
    {
        if (waveCounter > 0)
		{
            if (currentChild.childCount == 0 && !timer.TimerOn)
            {
                timer.StartTimer();
            }
        }
    }
}
