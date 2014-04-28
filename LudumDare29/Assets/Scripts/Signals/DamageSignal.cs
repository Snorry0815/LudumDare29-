using UnityEngine;
using System.Collections;

public class DamageSignal : ISignal
{
	private int damage;
	public int Damage
	{
		set
		{
			this.damage = value; 
		}
		get
		{
			return this.damage;
		}
	}
	public DamageSignal(int damage)
	{
		this.Damage = damage;
	}
}
