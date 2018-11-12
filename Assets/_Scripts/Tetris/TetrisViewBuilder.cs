using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisViewBuilder : MonoBehaviour
{
	public GameObject borderHandler;

	public void SetBorders (int row, int col)
	{
		borderHandler.SetActive(true);

		GameObject c = Instantiate(borderHandler,transform);
		c.transform.localPosition = Vector3.left * row / 2;
		c.transform.localScale = new Vector3 (c.transform.localScale.x, col, c.transform.localScale.z);
		c = Instantiate(borderHandler, transform);
		c.transform.localPosition = Vector3.right * row / 2;
		c.transform.localScale = new Vector3(c.transform.localScale.x, col, c.transform.localScale.z);
		c = Instantiate(borderHandler, transform);
		c.transform.localPosition = Vector3.up * col / 2;
		c.transform.localScale = new Vector3(row, c.transform.localScale.y, c.transform.localScale.z);
		c = Instantiate(borderHandler, transform);
		c.transform.localPosition = Vector3.down * col / 2;
		c.transform.localScale = new Vector3(row, c.transform.localScale.y, c.transform.localScale.z);

		borderHandler.SetActive(false);
	}
}
