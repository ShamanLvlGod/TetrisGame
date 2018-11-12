using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

	[SerializeField]
	private GameController gameController;
	[SerializeField]
	private Tetromino[] tetrominos;

	public Tetromino nextSpawn;
	

	public void Spawn ()
	{
		if(gameController.isGame)
		{
			gameController.CalcDropRate();
			if (nextSpawn != null)
			{
				nextSpawn.transform.position = transform.position;
				nextSpawn.enabled = true;
			}
			else
			{
				Tetromino tmp = Instantiate(tetrominos[Random.Range(0, tetrominos.Length)], transform.position, Quaternion.identity,transform);
				tmp.InitTetromino(gameController);
			}


			nextSpawn = Instantiate(tetrominos[Random.Range(0, tetrominos.Length)], gameController.nextSpawnPos.position, Quaternion.identity,transform);
			nextSpawn.InitTetromino(gameController);
			nextSpawn.enabled = false;
		}
	}
}
