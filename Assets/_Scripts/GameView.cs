using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ModeData
{
	[SerializeField]
	public string name;
	[SerializeField]
	public int score;
	[SerializeField]
	public int highScore;

	public ModeData(){}
}

abstract public class GameView : MonoBehaviour
{
	public string modeName;
	public Base_UIPanel canvas;

	abstract public void InitMode(ModeData previusMode);
}
