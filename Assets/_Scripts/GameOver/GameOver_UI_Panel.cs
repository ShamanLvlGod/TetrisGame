using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver_UI_Panel : HUD_Panel
{
	[SerializeField]
	private Button menuButton;
	[SerializeField]
	private Button scoreboardButton;
	[SerializeField]
	private Base_UIPanel scoreboard;
	public override void OpenBehavior()
	{
		base.OpenBehavior();
		menuButton.onClick.RemoveAllListeners();
		menuButton.onClick.AddListener(() => { MenuButtonPressed(); });
		scoreboardButton.onClick.RemoveAllListeners();
		scoreboardButton.onClick.AddListener(() => { ScoreboardButtonPressed(); });
	}

	void ScoreboardButtonPressed()
	{
		UIManager.instance.TriggerPanelTransition(scoreboard);
		CloseBehavior();
	}
	void MenuButtonPressed()
	{
		GameManager.instance.SetMode("MainMenu");
	}
}
