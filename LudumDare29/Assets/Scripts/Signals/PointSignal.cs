using UnityEngine;
using System.Collections;

public class PointSignal : ISignal
{
	private int points;
	public int Points
	{
		set
		{
			this.points = value; 
		}
		get
		{
			return this.points;
		}
	}
	public PointSignal(int points)
	{
		this.Points = points;
	}
}
