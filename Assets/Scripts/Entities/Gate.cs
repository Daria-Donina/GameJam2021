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
	public GameObject pic;

	public Sprite[] damageSprites;	

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

    private void Update()
    {
		HealthToSprite();
	}

	void HealthToSprite()
    {
		if (Health >= 900)
		{
			pic.GetComponent<SpriteRenderer>().sprite = damageSprites[0];
		}
		else if (Health >= 800 && Health < 900)
		{
			pic.GetComponent<SpriteRenderer>().sprite = damageSprites[1];
		}
		else if (Health >= 700 && Health < 800)
		{
			pic.GetComponent<SpriteRenderer>().sprite = damageSprites[2];
		}
		else if (Health >= 600 && Health < 700)
		{
			pic.GetComponent<SpriteRenderer>().sprite = damageSprites[3];
		}
		else if (Health >= 500 && Health < 600)
		{
			pic.GetComponent<SpriteRenderer>().sprite = damageSprites[4];
		}
		else if (Health >= 400 && Health < 500)
		{
			pic.GetComponent<SpriteRenderer>().sprite = damageSprites[5];
		}
		else if (Health >= 300 && Health < 400)
		{
			pic.GetComponent<SpriteRenderer>().sprite = damageSprites[6];
		}
		else if (Health >= 200 && Health < 300)
		{
			pic.GetComponent<SpriteRenderer>().sprite = damageSprites[7];
		}
		else if (Health >= 100 && Health < 200)
		{
			pic.GetComponent<SpriteRenderer>().sprite = damageSprites[8];
		}
		else if (Health < 100)
		{
			pic.GetComponent<SpriteRenderer>().sprite = damageSprites[9];
		}
	}
}
