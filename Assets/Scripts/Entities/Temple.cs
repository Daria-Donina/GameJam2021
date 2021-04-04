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
            _audio.PlayOneShot(_audio.clip);
            audioStarted = true;
        }
	}

    public IEnumerator GameOver()
    {
        text.text = "Подводный город обречен. Вы продержались "+ (spawnManager.waveCounter -1).ToString() + " волн.";
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }


	private void Update()
	{
        if (!_audio.isPlaying && audioStarted)
		{
            SceneManager.LoadScene(0, LoadSceneMode.Single);
		}
	}
}
