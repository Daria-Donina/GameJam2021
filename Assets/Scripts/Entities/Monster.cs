using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Monster : DestroyedObject
{
	public int damage;

	//private Collider2D _collider;
	private SpriteRenderer _sprite;
	private Color RedColor = new Color (1, 0, 0, 1);
	public AudioClip[] playlist;
	public AudioClip deathTrack;
	int trackNumber;

	public static event EventHandler<AudioClip> MonsterDied;

	private void Start()
	{
		//_collider = GetComponent<Collider2D>();
		_sprite = GetComponent<SpriteRenderer>();

		//Shooter.ShotFired += DetectHit;

		trackNumber = UnityEngine.Random.Range(0, 3);		
		deathTrack = playlist[trackNumber];
	}



	//void DetectHit(object sender, ShotArgs shot)
	//{
	//	if (_collider.bounds.IntersectRay(shot.Ray))
	//	{			
	//		Hit(shot.Damage);
	//		StartCoroutine("DamageTakenIndicator");
	//	}
	//}

	protected override void BeforeDestroy()
	{
		MonsterDied?.Invoke(this, deathTrack);
	}

	public void TakeDamage(int damage)
    {
		Hit(damage);
		StartCoroutine("DamageTakenIndicator");
    }

	IEnumerator DamageTakenIndicator()
    {
		_sprite.color = RedColor;		
		yield return new WaitForSeconds(0.3f);
		_sprite.color = new Color(1,1,1,1);
	}
}
