using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ShotArgs : EventArgs
{
	public ShotArgs(Ray ray, int damage)
	{
		Ray = ray;
		Damage = damage;
	}

	public Ray Ray { get; set; }
	public int Damage { get; set; }
}
