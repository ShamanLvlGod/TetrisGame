using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisController : GameController
{
	public TetrisViewBuilder tv;
	public HUD_Panel hp;

	private int nextSpawnPosShift = 4;
	public override void Start()
	{
		base.Start();
		hp.UpdateHighScore(modeData.highScore);
		hp.UpdateScore(modeData.score);
		SetUpTetroworld();
		spawner.Spawn();
	}
	public override void AddScore()
	{
		base.AddScore();
		hp.UpdateScore(modeData.score);
	}
	void SetUpTetroworld()
	{
		tv.SetBorders(gameGrid.row, gameGrid.col);
		Vector3 worldCenter = new Vector3(((float)gameGrid.row / 2) - (float)unitSize / 2, ((float)gameGrid.col / 2) - (float)unitSize / 2, 0);
		tv.transform.position = worldCenter;
		Camera.main.transform.position = new Vector3(worldCenter.x + nextSpawnPosShift * unitSize, worldCenter.y, -10);
		nextSpawnPos.position = worldCenter + Vector3.right*((gameGrid.row/2) + nextSpawnPosShift * unitSize);
		Camera.main.orthographicSize = Mathf.Max(gameGrid.col, gameGrid.row + nextSpawnPosShift*2 * unitSize) / 2;
	}
}
