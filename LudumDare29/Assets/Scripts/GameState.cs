using UnityEngine;
using System.Collections;

public enum MainState
{
	GAME,
	MENU
}

public enum GameSubState
{
	RUNNING,
	WON,
	LOST
}

public enum MenuSubState
{
	MAIN_MENU,
	CREDITS,
	HIGHSCORE
}


public class GameState 
{
	private static GameState gameState = null;

	public MainState MainState{set;get;}
	public GameSubState GameSubState{set;get;}
	public MenuSubState MenuSubState{set;get;}
	public bool PlayMusic{set;get;}

	public static GameState GetInstance()
	{
		if(gameState == null)
		{
			gameState = new GameState();
		}
		return gameState;
	}

	private GameState()
	{
		Init();
	}

	public void Init()
	{
		this.MainState = MainState.MENU;
		this.GameSubState = GameSubState.RUNNING;
		this.MenuSubState = MenuSubState.MAIN_MENU;
		this.PlayMusic = true;
	}

	public bool GameIsRunning()
	{
		return (this.MainState == MainState.GAME) && (this.GameSubState == GameSubState.RUNNING);
	}
}
