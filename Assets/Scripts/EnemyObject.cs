using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyObject : MonoBehaviour
{
	private Collider2D collider;

	[SerializeField]
	private int health;

	public int Health
	{
		get => health;
		set
		{
			health = value;
			if (health <= 0)
			{
				Destroy(gameObject);
			}
		}
	}

	public void Start()
	{
		collider = GetComponent<Collider2D>();
		Shooter.ShotFired += DetectHit;
	}

	void DetectHit(object sender, ShotArgs shot)
	{
		if (collider.bounds.IntersectRay(shot.Ray))
		{
			Health -= shot.Damage;
			Debug.Log(shot.Damage);
			Debug.Log(Health);
		}
	}

	private void OnDestroy()
	{
		Shooter.ShotFired -= DetectHit;
	}
}
