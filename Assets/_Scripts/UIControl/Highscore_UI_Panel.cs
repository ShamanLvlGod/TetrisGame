using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore_UI_Panel : Base_UIPanel
{
	[SerializeField]
	private Button menuButton;
	public override void OpenBehavior()
	{
		base.OpenBehavior();
		menuButton.onClick.RemoveAllListeners();
		menuButton.onClick.AddListener(() => { MenuButtonPressed(); });
	}
	
	void MenuButtonPressed()
	{
		GameManager.instance.SetMode("MainMenu");
	}
}
