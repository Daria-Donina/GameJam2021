using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Temple : MonoBehaviour
{
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private AudioSource audio;
    private bool audioStarted;

    private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
            audio.PlayOneShot(audio.clip);
            audioStarted = true;
        }
	}

	private void Update()
	{
        if (!audio.isPlaying && audioStarted)
		{
            SceneManager.LoadScene(0, LoadSceneMode.Single);
		}
	}
}
