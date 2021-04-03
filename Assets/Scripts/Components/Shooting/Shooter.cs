using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Shooter : MonoBehaviour
{
	public int Damage { get; set; }

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Shoot();
		}
	}

	[SerializeField]
	private AudioSource audioSrc;

	public static event EventHandler<ShotArgs> ShotFired;

	public void Shoot()
	{
		if (audioSrc)
		{
			audioSrc.PlayOneShot(audioSrc.clip);
		}

		// анимация

		//Get the Screen positions of the object
		Vector2 positionOnScreen = transform.position;

		var mousePos = Input.mousePosition;
		mousePos.z = 40;

		//Get the Screen position of the mouse
		Vector2 mouseOnScreen = Camera.main.ScreenToWorldPoint(mousePos);

		var ray = new Ray(positionOnScreen, mouseOnScreen - positionOnScreen);
		Debug.DrawRay(positionOnScreen, mouseOnScreen - positionOnScreen, Color.blue, 1);

		ShotFired?.Invoke(this, new ShotArgs(ray, Damage));
	}
}
