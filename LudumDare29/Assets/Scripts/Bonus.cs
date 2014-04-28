using UnityEngine;
using System.Collections;

public class Bonus : MonoBehaviour {
	public GameManager GameManager{set;get;}
	public int Points{get;set;}
	private bool isSwitch = false;

	public void IsSwitch()
	{
		this.isSwitch = true;
	}

	void OnCollisionEnter(Collision collision)
	{
		this.GameManager.AddPoints(Points);
		if(isSwitch)
		{
			this.GameManager.HitSwitch();
		}
	}
}
