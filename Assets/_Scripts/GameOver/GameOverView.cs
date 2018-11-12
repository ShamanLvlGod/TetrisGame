using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverView : GameView
{
	public string preModeName;
	public int preModeHighscore;

	[SerializeField]
	private GameOver_UI_Panel gui;
	public override void InitMode(ModeData previusMode)
	{
		if(previusMode != null)
		{
			preModeName = previusMode.name;
			preModeHighscore = previusMode.highScore;
			gui.UpdateHighScore(previusMode.highScore);
			gui.UpdateScore(previusMode.score);
		}
	}
}
