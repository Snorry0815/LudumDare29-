using UnityEngine;
using System.Collections;

public class Bonus : MonoBehaviour {
	public int Points{get;set;}
	private bool isSwitch = false;

	public void IsSwitch()
	{
		this.isSwitch = true;
	}

	void OnCollisionEnter(Collision collision)
	{
		SignalSystem.SignalTriggered(new PointSignal(Points));
		if(isSwitch)
		{
			SignalSystem.SignalTriggered(new OpenForceFieldSignal());
		}
	}
}
