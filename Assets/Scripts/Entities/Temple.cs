using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Temple : MonoBehaviour
{
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

	private void Update()
	{
        if (!_audio.isPlaying && audioStarted)
		{
            SceneManager.LoadScene(0, LoadSceneMode.Single);
		}
	}
}
