using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_Panel : Base_UIPanel
{
	public string scoreText, highScoreText;
	[SerializeField]
	private Text score;
	[SerializeField]
	private Text highScore;

	public void UpdateHighScore(int s)
	{
		highScore.text = highScoreText + " : " + s;
	}
	public void UpdateScore(int s)
	{
		score.text = scoreText + " : " + s;
	}
}
