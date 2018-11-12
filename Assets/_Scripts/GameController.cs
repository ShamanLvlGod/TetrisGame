using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameController : GameView
{
	[SerializeField]
	private Vector2 gameSize;
	public GameGrid gameGrid;
	public ModeData modeData;
	public Transform nextSpawnPos;
	public Spawner spawner;
	public bool isGame = true;
	public int unitSize = 1;
	public float dropRate = 1;
	public virtual void Start()
	{
		modeData = new ModeData();
		modeData.name = modeName;
		gameGrid = new GameGrid((int)gameSize.x,(int)gameSize.y);

		spawner.transform.position = gameGrid.GetSpawnerPos();


		if (PlayerPrefs.HasKey(modeName + "highScore"))
		{
			modeData.highScore = PlayerPrefs.GetInt(modeName + "highScore");
		}
		else
		{
			PlayerPrefs.SetInt(modeName + "highScore", modeData.highScore);
		}

	}
	public void CalcDropRate()
	{
		dropRate = Mathf.Clamp( 1 - Time.time / 150,0.1f,1);

	}
	public override void InitMode(ModeData mode)
	{

	}
	public virtual void AddScore()
	{
		modeData.score += (int)Time.time;
	}
	public virtual void GameOver()
	{
		isGame = false;
		if (modeData.score > modeData.highScore)
		{
			PlayerPrefs.SetInt(modeName + "highScore", modeData.score);
			modeData.highScore = modeData.score;
		}
		GameManager.instance.SetMode("GameOver", modeData);

	}
}
