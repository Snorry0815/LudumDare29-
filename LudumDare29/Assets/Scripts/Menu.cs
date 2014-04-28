using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public Texture turnMusicOn;
	public Texture turnMusicOff;
	public AudioSource music;
	public AudioSource effects;

	void OnGUI()
	{
		switch(GameState.GetInstance().MainState)
		{
		case MainState.MENU:
			ShowMainMenu();
			break;
		case MainState.GAME:
			ShowGameMenu();
			break;
		default:

			break;
		}

		ShowAudioOptions();
	}
	private void ShowAudioOptions()
	{
		if(GameState.GetInstance().PlayMusic)
		{
			if (GUI.Button(new Rect(20,Screen.height - 110,40,40),turnMusicOn))
			{
				music.Stop();
				effects.volume = 0.0f;
				GameState.GetInstance().PlayMusic = false;
			}
		}
		else
		{
			if (GUI.Button(new Rect(20,Screen.height - 110,40,40),turnMusicOff))
			{
				music.Play();
				effects.volume = 1.0f;
				GameState.GetInstance().PlayMusic = true;
			}
		}
	}

	private void ShowMainMenu()
	{
		float buttonWidth = 200;
		float buttonHeight = 40;
		float buttonOffeset = 20;
		
		float shiftY = buttonHeight + buttonOffeset;
		
		float posX = (Screen.width - buttonWidth) / 2f;
		float posY = Screen.height / 4f;
		
		if(GUI.Button(new Rect(posX,posY,buttonWidth,buttonHeight),"Play"))
		{
			GameState.GetInstance().MainState = MainState.GAME;
			if(GameState.GetInstance().GameSubState == GameSubState.LOST)
			{
				GameState.GetInstance().GameSubState = GameSubState.RUNNING;
				SignalSystem.SignalTriggered(new ResetSignal());
			}
			Time.timeScale = 1;
		}

		posY += shiftY;
		if(GUI.Button(new Rect(posX,posY,buttonWidth,buttonHeight),"Exit"))
		{
			Application.Quit ();
		}
		posY += shiftY;
	}

	private void ShowGameMenu()
	{
		if(GUI.Button(new Rect(20,Screen.height -60,60,40),"Menu"))
		{
			GameState.GetInstance().MainState = MainState.MENU;
			Time.timeScale = 0;
		}

		if(GameState.GetInstance().GameSubState == GameSubState.LOST)
		{
			float buttonWidth = 400;
			float buttonHeight = 40;
			float buttonOffeset = 20;

			float posX = (Screen.width - buttonWidth) / 2f;
			float posY = Screen.height / 4f;

			GUIStyle guiStyle = new GUIStyle();
			guiStyle.normal.textColor = Color.yellow;
			guiStyle.fontSize = Mathf.Min (Screen.width /10,Screen.height);
			guiStyle.fontStyle = FontStyle.Bold;
			guiStyle.alignment = TextAnchor.MiddleCenter;

			GUI.Label(new Rect(posX,posY,buttonWidth,buttonHeight),"Game Over", guiStyle);
			posY += buttonHeight + buttonOffeset;
			GUI.Label(new Rect(posX,posY,buttonWidth,buttonHeight),"Score:", guiStyle);
			posY += buttonHeight + buttonOffeset;
			GUI.Label(new Rect(posX,posY,buttonWidth,buttonHeight), this.GetComponent<GameManager>().GetPoints() + "", guiStyle);


		}
	}
}
