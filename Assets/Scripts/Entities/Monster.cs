using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Monster : DestroyedObject
{
	public int damage;

	private Collider2D _collider;
	public AudioSource[] playlist;
	AudioSource deathTrack;
	int trackNumber;

	private void Start()
	{
		_collider = GetComponent<Collider2D>();

		Shooter.ShotFired += DetectHit;

		trackNumber = UnityEngine.Random.Range(0, 3);
		Debug.Log(trackNumber);
		deathTrack = playlist[trackNumber];
	}

	void DetectHit(object sender, ShotArgs shot)
	{
		if (_collider.bounds.IntersectRay(shot.Ray))
		{
			Hit(shot.Damage);
		}
	}

	private void OnDestroy()
	{
		deathTrack.Play();
		Shooter.ShotFired -= DetectHit;
		
	}
}
