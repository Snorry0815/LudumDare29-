using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
	public float force = 1.0f;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.UpArrow)) 
		{
			rigidbody.AddForce(new Vector3(0f,0f,this.force));
		}
		else if (Input.GetKeyDown(KeyCode.DownArrow)) 
		{
			rigidbody.AddForce(new Vector3(0f,0f,-this.force));
		}
		else if (Input.GetKeyDown(KeyCode.LeftArrow)) 
		{
			rigidbody.AddForce(new Vector3(-this.force,0f,0f));
		}
		else if (Input.GetKeyDown(KeyCode.RightArrow)) 
		{
			rigidbody.AddForce(new Vector3(this.force,0f,0f));
		}
		else if (Input.GetKeyDown(KeyCode.Space)) 
		{
			SignalSystem.SignalTriggered(new ResetSignal());
		}
	}
}
