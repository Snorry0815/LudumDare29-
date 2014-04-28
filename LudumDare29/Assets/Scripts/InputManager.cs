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
		if (Input.GetKey(KeyCode.UpArrow)) 
		{
			rigidbody.AddForce(new Vector3(0f,0f,this.force));
		}
		else if (Input.GetKey(KeyCode.DownArrow)) 
		{
			rigidbody.AddForce(new Vector3(0f,0f,-this.force));
		}
		else if (Input.GetKey(KeyCode.LeftArrow)) 
		{
			rigidbody.AddForce(new Vector3(-this.force,0f,0f));
		}
		else if (Input.GetKey(KeyCode.RightArrow)) 
		{
			rigidbody.AddForce(new Vector3(this.force,0f,0f));
		}
		else if (Input.GetKey(KeyCode.Space)) 
		{
			GameState.GetInstance().MainState = MainState.GAME;
			if(GameState.GetInstance().GameSubState == GameSubState.LOST)
			{
				GameState.GetInstance().GameSubState = GameSubState.RUNNING;
				SignalSystem.SignalTriggered(new ResetSignal());
			}
			Time.timeScale = 1;
		}
	}
}
