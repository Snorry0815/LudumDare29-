using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour 
{
	public GameManager GameManager{set;get;}

	void OnCollisionEnter(Collision collision)
	{
		this.GameManager.ChangeLife(-1);
	}

}
