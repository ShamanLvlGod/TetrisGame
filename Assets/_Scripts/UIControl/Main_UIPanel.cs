using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main_UIPanel : Base_UIPanel
{
	[SerializeField]
    private Button startButton;
	[SerializeField]
	private InputField nameInput;
    public override void OpenBehavior()
    {
        base.OpenBehavior();
        startButton.onClick.RemoveAllListeners();
        startButton.onClick.AddListener( ()=> { StartButtonPressed(); } );
		nameInput.text = GameManager.instance.UserName;
		nameInput.onEndEdit.RemoveAllListeners();
		nameInput.onEndEdit.AddListener( (string nm) => { GameManager.instance.SetName(nm); });
    }

    void StartButtonPressed()
    {
		GameManager.instance.SetMode("StandardTetris");
    }
}
