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
		Vector2 positionOnScreen = transform.position;

		var mousePos = Input.mousePosition;
		mousePos.z = 10;

		//Get the Screen position of the mouse
		Vector2 mouseOnScreen = Camera.main.ScreenToWorldPoint(mousePos);

		Debug.Log(Input.mousePosition);
		Debug.Log(mouseOnScreen);

		var ray = new Ray(positionOnScreen, mouseOnScreen - positionOnScreen);
		Debug.DrawRay(positionOnScreen, mouseOnScreen - positionOnScreen, Color.blue, 1);

		ShotFired?.Invoke(this, ray);
	}
}
