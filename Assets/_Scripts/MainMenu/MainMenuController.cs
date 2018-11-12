using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : GameView
{

	public override void InitMode(ModeData mode)
	{

	}

	void Start ()
	{
		UIManager.instance.TriggerPanelTransition(canvas);
	}

}
