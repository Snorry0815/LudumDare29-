using UnityEngine;
using System.Collections;

public class PlaySound : ISignal
{
	private int sound;
	public int Sound
	{
		set
		{
			this.sound = value; 
		}
		get
		{
			return this.sound;
		}
	}
	public PlaySound(int sound)
	{
		this.Sound = sound;
	}
}
