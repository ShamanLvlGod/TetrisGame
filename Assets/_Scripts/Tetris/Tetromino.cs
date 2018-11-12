using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetromino : MonoBehaviour
{
	[SerializeField]
	private float timer = 0;
	[SerializeField]
	private bool isRotatable = true;
	private bool m_isAxisInUse = false;
	private GameController gm;

	public void InitTetromino (GameController gameController)
	{
		gm = gameController;
	}

	void Update ()
	{

		if (Input.GetAxisRaw("Horizontal") != 0)
		{

			if (m_isAxisInUse == false)
			{
				transform.position += Vector3.right * Input.GetAxisRaw("Horizontal");

				if (IsValidGridPosition())
					UpdateMatrixGrid();
				else
					transform.position += Vector3.left * Input.GetAxisRaw("Horizontal");
				m_isAxisInUse = true;
			}				
		}
		if (Input.GetAxisRaw("Vertical") > 0 && isRotatable)
		{
			if (m_isAxisInUse == false)
			{
				transform.Rotate(new Vector3(0,0,-90));
			//	transform.RotateAround(GetComponent<SpriteRenderer>().bounds.center, Vector3.forward, -90);
				if (IsValidGridPosition())
					UpdateMatrixGrid();
				else
					transform.Rotate(new Vector3(0, 0, 90));


				m_isAxisInUse = true;

			}
		}
		else if (Input.GetAxisRaw("Vertical") < 0 || Time.time - timer >= gm.dropRate)
		{
			transform.position += Vector3.down;

			if (IsValidGridPosition())
				UpdateMatrixGrid();
			else
			{
				transform.position += Vector3.up;

				gm.gameGrid.DeleteWholeRows(gm.AddScore);
				foreach (Transform child in transform)
				{
					Vector2 v = GameGrid.RoundVector(child.position);

					if (v.y>=gm.spawner.transform.position.y)
					{
						gm.GameOver();
					}
				}

				gm.spawner.Spawn();
				enabled = false;
			}
			timer = Time.time;
		}
		else if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
			{
				m_isAxisInUse = false;
			}
	}

	bool IsValidGridPosition()
	{
		foreach(Transform child in transform)
		{
			Vector2 v = GameGrid.RoundVector(child.position);


			if (!gm.gameGrid.IsInsideBorder(v))
				return false;
			if (gm.gameGrid.grid[(int)v.x, (int)v.y] != null && gm.gameGrid.grid[(int)v.x, (int)v.y].parent != transform)
				return false;
		}
		return true;
	}

	void UpdateMatrixGrid()
	{
		for (int y = 0; y < gm.gameGrid.col; y++) 
		{
			for (int x = 0; x < gm.gameGrid.row; x++)
			{
				if (gm.gameGrid.grid[x, y] != null)
				{
					if (gm.gameGrid.grid[x, y].parent == transform)
					{
						gm.gameGrid.grid[x, y] = null;
					}
				}
			}
		}
		foreach(Transform child in transform)
		{
			Vector2 v = GameGrid.RoundVector(child.position);
			gm.gameGrid.grid[(int)v.x, (int)v.y] = child;
		}
		//Debug.Log(gm.gameGrid.WriteWholeMatrix());
	}
}
