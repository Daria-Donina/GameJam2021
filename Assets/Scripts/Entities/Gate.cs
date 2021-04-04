using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Gate : DestroyedObject
{
	[SerializeField]
	[Range(0, 4)]
	private float timeBetweenHits;

	private float lastHitTime;

	private void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
			var monster = collision.gameObject.GetComponent<Monster>();

			if (Time.time > lastHitTime + timeBetweenHits)
			{
				Hit(monster.damage);
				lastHitTime = Time.time;
			}

			Debug.Log("Gate HP: " + Health);

		}
	}
}
