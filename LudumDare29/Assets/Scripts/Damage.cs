using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour 
{
	void OnCollisionEnter(Collision collision)
	{
		SignalSystem.SignalTriggered(new DamageSignal(-1));
	}
}
