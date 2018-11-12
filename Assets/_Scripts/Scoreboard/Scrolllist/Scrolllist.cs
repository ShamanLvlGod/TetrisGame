using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Scrolllist : MonoBehaviour
{

	private static Scrolllist inst;

	public static Scrolllist Instance
	{
		get { return inst; }
	}
	void Awake()
	{

		if (inst == null)
			inst = this;
		else if (inst != this)
		{
			Destroy(gameObject);
			return;
		}
	}

	public GameObject ScrollEntry;
	public GameObject ScrollContain;
	public int yourPosition;
	public GameObject LoadingText;
	private bool loading = true;

	public void SetLoading(bool b)
	{
		loading = b;

		LoadingText.SetActive(loading);
	}
	void Update ()
	{
	
	}

	public void getScrollEntrys()
	{
		foreach (Transform childTransform in ScrollContain.transform) Destroy(childTransform.gameObject);

		int j = 1;
		for (int i=0; i<HSController.Instance.onlineHighscore.Length-1; i++) {
			GameObject ScorePanel;
			ScorePanel = Instantiate (ScrollEntry) as GameObject;
			ScorePanel.transform.SetParent(ScrollContain.transform);
			ScorePanel.transform.localScale = ScrollContain.transform.localScale;
			Transform ThisScoreName = ScorePanel.transform.Find ("ScoreText");
			Text ScoreName = ThisScoreName.GetComponent<Text> ();
			//
			Transform ThisScorePoints = ScorePanel.transform.Find ("ScorePoints");
			Text ScorePoints = ThisScorePoints.GetComponent<Text> ();
			//
			Transform ThisScorePosition = ScorePanel.transform.Find ("ScorePosition");
			Text ScorePosition = ThisScorePosition.GetComponent<Text> ();

			//first position is yellow
			if (j==1)
			{
				ScoreName.color=Color.yellow;
				ScorePoints.color=Color.yellow;
				ScorePosition.color=Color.yellow;
			}
			ScorePosition.text = j+". ";
			string helpString = "";

			helpString = helpString+HSController.Instance.onlineHighscore [i]+" ";
			i++;

			ScoreName.text = helpString;

			//
			ScorePoints.text = HSController.Instance.onlineHighscore [i];

		/*	if(HSController.Instance.onlineHighscore [i]=="9999")
			{
				ScoreName.color=Color.red;
				ScorePoints.color=Color.red;
				ScorePosition.color=Color.red;
				yourPosition = j;
			}*/
			j++;

		}

	}
}
