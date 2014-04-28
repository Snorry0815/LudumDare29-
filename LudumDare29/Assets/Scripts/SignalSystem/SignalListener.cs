using UnityEngine;
using System.Collections;

public interface SignalListener<S>:ISignalListener where S:ISignal
{
	void SignalTrigered(S signal);
}
