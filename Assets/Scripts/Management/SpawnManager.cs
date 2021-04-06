using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public int waveCounter;
    private int NestIndex;
    public Text wavesCounterText;
    public Text wavesNestText;

    private Transform currentChild;

    public GameObject timerObject;
    private Timer timer;

    //minimap indicators
    public GameObject[] MapIndicators;
    GameObject currentIndicator;

    private void Spawn(object sender, EventArgs args)
    {
        NestIndex = UnityEngine.Random.Range(0, 4);
        Debug.Log("Nest Index: " + NestIndex);
        Debug.Log(this);

        currentChild = transform.GetChild(NestIndex);

        var spawner = currentChild.GetComponent<MonsterSpawner>();
        
        waveCounter++;
        StartCoroutine("ShowWaveCounter");
        spawner.SpawnWaveOfEnemies(waveCounter);
    }

    public AudioSource audioScr;
    // Start is called before the first frame update
    void Start()
    {
        timer = timerObject.GetComponent<Timer>();
        Timer.TimerEnded += Spawn;
        Monster.MonsterDied += PlayAudio;
    }

    private void PlayAudio(object sender, AudioClip audio)
	{
        audioScr.PlayOneShot(audio);
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


    IEnumerator ShowWaveCounter()
    {
        if (waveCounter > 0)
        {
            wavesCounterText.text = "WAVE #" + waveCounter.ToString();
            currentIndicator = MapIndicators[NestIndex];
            switch (NestIndex)
            {
                case 0:
                    wavesNestText.text = "WAVE COMING FROM NORTH";
                    currentIndicator.SetActive(true);
                    break;
                case 1:
                    wavesNestText.text = "WAVE COMING FROM WEST";
                    currentIndicator.SetActive(true);
                    break;
                case 2:
                    wavesNestText.text = "WAVE COMING FROM EAST";
                    currentIndicator.SetActive(true);
                    break;
                case 3:
                    wavesNestText.text = "WAVE COMING FROM SOUTH";
                    currentIndicator.SetActive(true);
                    break;
            }
        }
        yield return new WaitForSeconds(10f);
        currentIndicator.SetActive(false);
        wavesCounterText.text = " ";
        wavesNestText.text = " ";
    }

	private void OnDestroy()
	{
        Timer.TimerEnded -= Spawn;
        Monster.MonsterDied -= PlayAudio;
    }

}
