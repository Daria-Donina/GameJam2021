using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Monster : DestroyedObject
{
	public int damage;

	private Collider2D collider;

	private void Start()
	{
		collider = GetComponent<Collider2D>();

		Shooter.ShotFired += DetectHit;
	}

	void DetectHit(object sender, ShotArgs shot)
	{
		if (collider.bounds.IntersectRay(shot.Ray))
		{
			Hit(shot.Damage);
		}
	}

	private void OnDestroy()
	{
		Shooter.ShotFired -= DetectHit;
	}
}
