using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid
{
	public int row;
	public int col;

	public Transform[,] grid;

	public GameGrid()
	{
		row = 10;
		col = 20;
		grid = new Transform[row, col];
	}
	public GameGrid(int r, int c)
	{
		row = Mathf.Clamp(r,10,25);
		col = Mathf.Clamp(c,15,35);
		grid = new Transform[row, col];
	}
	public Vector2 GetSpawnerPos()
	{
		return new Vector2(Mathf.Round(row / 2), Mathf.Round(col - 4));
	}

	public static Vector2 RoundVector(Vector2 v)
	{
		return new Vector2(Mathf.Round(v.x), Mathf.Round(v.y));
	}

	public bool IsInsideBorder(Vector2 pos)
	{
		return ((int)pos.x >= 0 && (int)pos.x < row && (int)pos.y >= 0 && (int)pos.y < col);
	}
	public void DeleteRow(int y)
	{
		for (int x = 0; x < row; x++)
		{
			GameObject.Destroy(grid[x, y].gameObject);
			grid[x, y] = null;
		}
	}

	public void DecraseRow(int y)
	{
		for (int x = 0; x < row; x++)
		{
			if (grid[x, y] != null)
			{
				grid[x, y - 1] = grid[x, y];
				grid[x, y] = null;

				grid[x, y - 1].position += Vector3.down;
			}
		}
	}

	public void DecraseRowsAbove(int y)
	{
		for (int i = y; i < col; i++)
			DecraseRow(i);

	}

	public bool IsRowFull(int y)
	{
		for (int x = 0; x < row; x++)
			if (grid[x, y] == null)
				return false;

		return true;
	}
	public delegate void addScore();
	public void DeleteWholeRows(addScore score)
	{
		for (int y = 0; y < col; y++)
		{
			if (IsRowFull(y))
			{
				score();
				DeleteRow(y);
				DecraseRowsAbove(y + 1);
				y--;
			}
		}
	}

	public string WriteWholeMatrix()
	{
		string tmp = "";
		for (int i = 0; i < row; i++)
		{

			for (int j = 0; j < col; j++)
			{
				if (grid[i, j] == null)
					tmp += 0 + "";
				else
					tmp += "*";

			}
			tmp += "\n";
		}

		return tmp;
	}
}
