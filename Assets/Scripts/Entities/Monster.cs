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
	public AudioClip[] playlist;
	public AudioClip deathTrack;
	int trackNumber;

	public static event EventHandler<AudioClip> MonsterDied;

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
			Debug.Log("i was hit");
			Hit(shot.Damage);
		}
	}

	protected override void BeforeDestroy()
	{
		MonsterDied?.Invoke(this, deathTrack);
	}

	private void OnDestroy()
	{
		Shooter.ShotFired -= DetectHit;
	}
}
