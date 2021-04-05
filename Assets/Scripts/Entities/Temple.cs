using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Temple : MonoBehaviour
{
    public SpawnManager spawnManager;
    public Text text;
    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    private AudioSource _audio;
    private bool audioStarted;

    private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Enemy" && !audioStarted)
		{
            StartCoroutine("GameOver");
            
        }
	}

    public IEnumerator GameOver()
    {
        if (spawnManager.waveCounter - 1 == 1)
        {
            text.text = "Подводный город обречен.\nВы продержались " + (spawnManager.waveCounter - 1).ToString() + " волну.";
        }
        else if(spawnManager.waveCounter - 1 == 2)
        {
            text.text = "Подводный город обречен.\nВы продержались " + (spawnManager.waveCounter - 1).ToString() + " волны.";
        }
        else if (spawnManager.waveCounter - 1 == 3)
        {
            text.text = "Подводный город обречен.\nВы продержались " + (spawnManager.waveCounter - 1).ToString() + " волны.";
        }
        else if (spawnManager.waveCounter - 1 == 4)
        {
            text.text = "Подводный город обречен.\nВы продержались " + (spawnManager.waveCounter - 1).ToString() + " волны.";
        }
        else
        {
            text.text = "Подводный город обречен.\nВы продержались " + (spawnManager.waveCounter - 1).ToString() + " волн.";
        }

        _audio.PlayOneShot(_audio.clip);
        audioStarted = true;
        yield return new WaitForSeconds(10f);
        SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
    }


	private void Update()
	{
        if (!_audio.isPlaying && audioStarted)
		{
            SceneManager.LoadScene(0, LoadSceneMode.Single);
		}
	}
}
