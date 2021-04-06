using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Shooter : MonoBehaviour
{
	public int Damage { get; set; }

	public Transform Spawn1;
	public Transform Spawn2;
	public GameObject BulletPrefab;	
	public float bulletSpeed = 10f;
	


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
		mousePos.z = 70;

		//Get the Screen position of the mouse
		Vector2 mouseOnScreen = Camera.main.ScreenToWorldPoint(mousePos);

		var ray = new Ray(positionOnScreen, mouseOnScreen - positionOnScreen);
		Debug.DrawRay(positionOnScreen, mouseOnScreen - positionOnScreen, Color.blue, 1);

		ShotFired?.Invoke(this, new ShotArgs(ray, Damage));

		GameObject bullet = Instantiate(BulletPrefab, Spawn1.position, Spawn1.rotation);
		bullet.GetComponent<Rigidbody2D>().AddForce(Spawn1.up * 3500);

        if (Spawn2!=null)
        {
			GameObject bullet2 = Instantiate(BulletPrefab, Spawn2.position, Spawn2.rotation);
			bullet2.GetComponent<Rigidbody2D>().AddForce(Spawn2.up * 3500);
		}
	}
}
