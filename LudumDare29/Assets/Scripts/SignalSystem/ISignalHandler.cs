using UnityEngine;
using System.Collections;

public interface ISignalHandler
{
	void AddListener(ISignalListener listener);
	void SignalTriggered(ISignal iSignal);
}
