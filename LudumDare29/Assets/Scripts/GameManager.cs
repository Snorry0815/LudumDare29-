using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager 
		: MonoBehaviour
		, SignalListener<DamageSignal>
		, SignalListener<PointSignal>
		, SignalListener<OpenForceFieldSignal> 
		, SignalListener<ResetSignal>
{

	public GameObject prefabTile;
	public GameObject prefabForceField;
	public GameObject prefabTunnelStraight;	
	public GameObject prefabTunnelLeft;
	public GameObject prefabTunnelUp;

	private GameObject startTunnel = null;

	public GameObject ball;
	public GameObject ballCamera;

	public int size;

	public int life = 17;
	public int tunnelLength = 10;

	private int switchCount = 0;

	private GameObject forceField = null;
	private Vector3 center = Vector3.zero;
	private Vector3 lastPos = Vector3.zero;
	private List<Vector3> centers = new List<Vector3>();
	private List<GameObject> tunnels = new List<GameObject>();

	private float d = 15f;

	private GameObject deleteTunnel = null;
	private GameObject tiles = null;
	private bool deleteTiles = false;

	void Start () 
	{
		Reset();

		SignalSystem.AddListener<DamageSignal>(this);
		SignalSystem.AddListener<PointSignal>(this);
		SignalSystem.AddListener<OpenForceFieldSignal>(this);
		SignalSystem.AddListener<ResetSignal>(this);
	}

	private void Reset()
	{
		if(this.startTunnel != null)
		{
			Destroy(this.startTunnel);
		}
		this.startTunnel = Instantiate(prefabTunnelStraight, Vector3.zero, Quaternion.identity) as GameObject;

		centers.Clear();
		foreach(GameObject tunnel in tunnels)
		{
			Destroy(tunnel);
		}
		this.tunnels.Clear();
		if(this.tiles != null)
		{
			Destroy(this.tiles);
			this.tiles = null;
		}

		this.ball.transform.position = new Vector3(0.0f, 4.0f, 0.0f);

		this.life = 17;
		ChangeLife(0);
		this.switchCount = 0;
		if(this.forceField != null)
		{
			Destroy(this.forceField);
			this.forceField = null;
		}

		this.center = Vector3.zero;
		this.lastPos = Vector3.zero;

		this.d = 15f;
		if(this.deleteTunnel != null)
		{
			Destroy(this.deleteTunnel);
			this.deleteTunnel = null;
		}
		
		this.deleteTunnel = null;
		this.deleteTiles = false;

		centers.Add(center);
		tunnels.Add(startTunnel);
		Spawn();
	}

	public void SignalTrigered(DamageSignal damage)
	{
		ChangeLife(damage.Damage);
	}
	public void SignalTrigered(PointSignal points)
	{
	}
	public void SignalTrigered(OpenForceFieldSignal open)
	{	
		HitSwitch();
	}
	public void SignalTrigered(ResetSignal reset)
	{
		Reset();
	}

	void Update () 
	{
		Vector3 camPos = ballCamera.transform.position;
		float y = ballCamera.transform.position.y - ball.transform.position.y;
		if(y > 15f)
		{
			camPos.y = ball.transform.position.y + 15f;
			float diff = ballCamera.transform.position.y - camPos.y;
			d -= diff;
			if ((d <= 0.0f) && (centers.Count > 1))
			{
				lastPos = centers[0];
				centers.RemoveAt(0);

				if(this.deleteTunnel != null )
				{
					Destroy(this.deleteTunnel);
					if (this.deleteTiles)
					{
						this.deleteTiles  = false;
						Destroy(this.tiles);
						this.tiles = null;
						Spawn();
					}
				}
				this.deleteTunnel = tunnels[0];
				tunnels.RemoveAt(0);
				d += 30.0f;
			}
			Vector3 target = centers[0];
			float alpha = 1.0f - d / 30f;
			camPos.x = (target.x - lastPos.x) * alpha + lastPos.x;
			camPos.z = (target.z - lastPos.z) * alpha + lastPos.z;

			ballCamera.transform.position = camPos;

		}
	}

	void Spawn()
	{
		Vector3 pos = centers[centers.Count - 1];
		this.forceField = Instantiate(prefabForceField, pos, Quaternion.identity) as GameObject;

		this.tiles = new GameObject();
		this.tiles.name = "Tiles";

		float offsetX = - 3f * size / 4f + 0.75f;
		float relX = offsetX;
		float offsetY = 0.0f;
		int shrink = 0;
		float off = 1;
		for (int j=0;j<size-3;++j)
		{
			for (int i=0;i<size-shrink;i+=2)
			{	
				if (j == 0)
				{
					SpawnTile(pos + new Vector3(offsetX + i*1.5f,0,0));
				}
				else
				{
					SpawnTile(pos + new Vector3(offsetX+i*1.5f,0,offsetY));
					SpawnTile(pos + new Vector3(offsetX+i*1.5f,0,-offsetY));
				}
			}
			relX += 1.5f;
			offsetX = relX - 3f * Mathf.Floor(off / 3f);

			offsetY += 0.866f;
			shrink = 2 * (1+j) - 4 * (int)Mathf.Floor(off / 3f);

			off += 1;
		}

		for (int i=0;i<tunnelLength;++i)
		{
			int dir = Random.Range(0,5);
			SpawnTunnel(dir);
		}
		SpawnTunnel(0);
	}

	private void SpawnTunnel(int direction)
	{
		GameObject tunnel;
		Vector3 pos = centers[centers.Count-1];
		switch(direction)
		{
		case 1:
			pos += new Vector3(-10.0f,-30.0f,0.0f);
			tunnel = Instantiate(prefabTunnelLeft, pos, Quaternion.identity) as GameObject;
			tunnel.name = "TunnelLeft";
			break;
		case 2:
			pos += new Vector3(10.0f,-30.0f,0.0f);
			tunnel = Instantiate(prefabTunnelLeft, pos, Quaternion.identity) as GameObject;
			tunnel.transform.Rotate(0.0f,180.0f,0.0f);
			tunnel.name = "TunnelRight";
			break;
		case 3:
			pos += new Vector3(0.0f,-30.0f,-10.0f);
			tunnel = Instantiate(prefabTunnelUp, pos, Quaternion.identity) as GameObject;
			tunnel.name = "TunnelUp";
			break;
		case 4:
			pos += new Vector3(0.0f,-30.0f,10.0f);
			tunnel = Instantiate(prefabTunnelUp, pos, Quaternion.identity) as GameObject;
			tunnel.transform.Rotate(0.0f,180.0f,0.0f);
			tunnel.name = "TunnelDown";
			break;
		case 0:
		default :
			pos += new Vector3(0.0f,-30.0f,0.0f);
			tunnel = Instantiate(prefabTunnelStraight, pos, Quaternion.identity) as GameObject;
			tunnel.name = "TunnelStraight";
			break;
		}
		centers.Add(pos);
		tunnels.Add(tunnel);
	}

	void SpawnTile(Vector3 pos)
	{
		GameObject tile = Instantiate(prefabTile, pos, Quaternion.identity) as GameObject;
		Bonus bonus = tile.GetComponent<Bonus>();
		if(Random.value > 0.9f)
		{
			tile.GetComponent<MeshRenderer>().material.color = Color.red;
			++this.switchCount;
			bonus.IsSwitch();
		}
		tile.transform.parent = this.tiles.transform;

		bonus.Points = 2;
	}

	public void ChangeLife(int change)
	{
		this.life += change;
		this.GetComponent<LifeBar>().SetLife(this.life);
	}
	
	public void HitSwitch()
	{
		--this.switchCount;
		if(this.switchCount <= 0)
		{
			if(this.forceField != null)
			{
				Destroy (this.forceField);
				this.forceField = null;
				this.deleteTiles = true;
			}
		}
	}
}
