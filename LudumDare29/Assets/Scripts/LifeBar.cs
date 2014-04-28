using UnityEngine;
using System.Collections;

public class LifeBar : MonoBehaviour 
{
	public Texture lifeBarTexture;

	private int life = 17;

	public void SetLife(int life)
	{
		this.life = life;
	}

	void OnGUI()
	{
		if(life > 0)
		{
			GUI.DrawTextureWithTexCoords(new Rect(20, 20, life * 15, 64), lifeBarTexture, new Rect(0.0f, 0.0f, (life / 17.0f) - 0.01f, 1.0f));
		}
	}
}
