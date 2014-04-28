using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour 
	, SignalListener<PlaySound>
{

	public AudioSource effects;

	public AudioClip[] audioClips;
	// Use this for initialization
	void Start () 
	{
		SignalSystem.AddListener<PlaySound>(this);
	}
	public void SignalTrigered(PlaySound sound)
	{
		effects.clip = audioClips[sound.Sound];
		effects.Play();
	}
}
