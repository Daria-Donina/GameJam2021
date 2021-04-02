using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Shooter : MonoBehaviour
{

	public void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Shoot();
		}
	}

	public static event EventHandler<Ray> ShotFired;

	public void Shoot()
	{
		// звук
		// анимация

		//Get the Screen positions of the object
		Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

		//Get the Screen position of the mouse
		Vector2 mouseOnScreen = Camera.main.ScreenToViewportPoint(Input.mousePosition);

		var ray = new Ray(positionOnScreen, mouseOnScreen);
		Gizmos.DrawRay(ray);

		ShotFired?.Invoke(this, ray);
	}
}
