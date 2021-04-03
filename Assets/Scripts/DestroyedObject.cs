using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class DestroyedObject : MonoBehaviour
{
	[SerializeField]
	private int health;

	protected int Health
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

	protected void Hit(int damage)
	{
		Health -= damage;
	}
}
