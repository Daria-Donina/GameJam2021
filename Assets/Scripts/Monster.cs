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
		Shooter.ShotFired += (sender, ray) => DetectHit(ray);
	}

	public void Clone()
	{

	}

	void DetectHit(Ray ray)
	{
		if (collider.bounds.IntersectRay(ray))
		{
			Destroy(gameObject);
		}
	}
}
