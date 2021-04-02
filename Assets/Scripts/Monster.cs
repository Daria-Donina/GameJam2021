using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Monster : MonoBehaviour
{
	public Vector3 SpawnPoint { get; set; }

	private Collider2D collider;

	public void Start()
	{
		collider = GetComponent<Collider2D>();
		Shooter.ShotFired += DetectHit;
	}

	public void Clone()
	{

	}

	void DetectHit(object sender, Ray ray)
	{
		if (collider.bounds.IntersectRay(ray))
		{
			Destroy(gameObject);
		}
	}

	private void OnDestroy()
	{
		Shooter.ShotFired -= DetectHit;
	}
}
