using UnityEngine;
using System.Collections;

public class Collector : MonoBehaviour {

	void OnTriggerEnter(Collider col)
	{
		Destroy(col.gameObject);
		SignalSystem.SignalTriggered(new PointSignal(10));
		SignalSystem.SignalTriggered(new PlaySound(0));
	}
}
