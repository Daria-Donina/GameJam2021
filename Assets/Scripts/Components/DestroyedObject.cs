﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class DestroyedObject : MonoBehaviour
{
	[SerializeField]
	private int health;
	[SerializeField]
	private int maxHealth;

	public int Health
	{
		get => health;
		set
		{
			health = Math.Min(value, maxHealth);
			if (health <= 0)
			{
				BeforeDestroy();
				Destroy(gameObject);
			}
		}
	}

	protected virtual void BeforeDestroy() { }

	public int MaxHealth { get => maxHealth; protected set { } }


	protected void Hit(int damage)
	{
		Health -= damage;
	}	
}
