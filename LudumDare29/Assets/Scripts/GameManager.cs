using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject prefabTile;
	public int size;

	void Start () 
	{
		Spawn();
	}

	void Update () 
	{
	
	}

	void Spawn()
	{
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
					SpawnTile(new Vector3(offsetX + i*1.5f,0,0));
				}
				else
				{
					SpawnTile(new Vector3(offsetX+i*1.5f,0,offsetY));
					SpawnTile(new Vector3(offsetX+i*1.5f,0,-offsetY));
				}
			}
			relX += 1.5f;
			offsetX = relX - 3f * Mathf.Floor(off / 3f);

			offsetY += 0.866f;
			shrink = 2 * (1+j) - 4 * (int)Mathf.Floor(off / 3f);

			off += 1;
		}
	}

	void SpawnTile(Vector3 pos)
	{
		GameObject tile = Instantiate(prefabTile, pos, Quaternion.identity) as GameObject;
	}
}
