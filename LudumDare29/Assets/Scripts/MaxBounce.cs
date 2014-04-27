using UnityEngine;
using System.Collections;

public class MaxBounce : MonoBehaviour {

	public float maxHeight = 3f;

	private float hitY = 0;
	private bool bounce = false;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (this.bounce && (transform.position.y > this.hitY) )
		{
			this.bounce = false;
			Vector3 vel = this.rigidbody.velocity;
			if(vel.y > 0f)
			{
				vel.y = 0f;
			}
			this.rigidbody.velocity = vel;
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if (this.bounce)
		{
			if (transform.position.y + maxHeight < this.hitY)
			{
				this.hitY = transform.position.y + maxHeight;
			}
		}
		else
		{
			this.bounce = true;
			this.hitY = transform.position.y + maxHeight;
		}
	}
}



