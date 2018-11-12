using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class HSController : MonoBehaviour
{
	private static HSController inst;
	
	public static HSController Instance
	{
		get { return inst; }
	}
	void Awake()
	{

		if (inst == null)
			inst = this;

		else if (inst != this) {
			Destroy (gameObject);
			return;
		}


	}
	void OnEnable()
	{
		StartCoroutine(PostScores(startGetScores));

		//
		//HSController.Instance.startGetScores ();
	}

	[SerializeField]
	private GameOverView gm;

	private string uniqueID;
	private string PlayerName;
	private string modeName;
	private int score;

	private string secretKey = "123456789";
	private string addScoreURL = "argametest.000webhostapp.com/addscore.php?";
	private string highscoreURL = "argametest.000webhostapp.com/display.php?";


	

	public string[] onlineHighscore;

	public void startGetScores()
	{
		StartCoroutine(GetScores());
	}

	public void startPostScores()
	{	
		StartCoroutine(PostScores());
	}

	public void updateOnlineHighscoreData()
	{
		uniqueID = GameManager.instance.UserID;
		PlayerName = GameManager.instance.UserName;
		score = gm.preModeHighscore;
		modeName = gm.preModeName;
	}

	public  string Md5Sum(string strToEncrypt)
	{
		System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
		byte[] bytes = ue.GetBytes(strToEncrypt);
		

		System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
		byte[] hashBytes = md5.ComputeHash(bytes);
		
		string hashString = "";
		
		for (int i = 0; i < hashBytes.Length; i++)
		{
			hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
		}
		
		return hashString.PadLeft(32, '0');
	}

	IEnumerator PostScores(Action callback = null)
	{
		updateOnlineHighscoreData ();

		string hash = Md5Sum(PlayerName + score + secretKey);
		//string post_url = addScoreURL + "name=" + WWW.EscapeURL(name) + "&score=" + score + "&hash=" + hash;
		string post_url = addScoreURL + "uniqueID=" + uniqueID+ "&name=" + WWW.EscapeURL (PlayerName) + "&score=" + score + "&mode=" + modeName + "&hash=" + hash;
		Debug.Log ("post url " + post_url);
		WWW hs_post = new WWW("http://"+post_url);
		yield return hs_post; 
	//	print("There was an error posting the high score: " + hs_post.text);

		if (hs_post.error != null)
		{
			print("There was an error posting the high score: " + hs_post.error);
		}
		if(callback != null)
		{
			callback();
		}
	}

	IEnumerator GetScores()
	{
		updateOnlineHighscoreData();

		Scrolllist.Instance.SetLoading(true);

		WWW hs_get = new WWW("http://"+highscoreURL + "&mode=" + modeName);

		yield return hs_get;
		
		if (hs_get.error != null)
		{
			Debug.Log("There was an error getting the high score: " + hs_get.error);

		}
		else
		{

			string help = hs_get.text;

		//	Debug.Log("There was an error getting the high score: " + hs_get.text);

			//help= help.Substring(5, hs_get.text.Length-5);

			onlineHighscore = help.Split(";"[0]);

		}
		Scrolllist.Instance.SetLoading(false);
		Scrolllist.Instance.getScrollEntrys ();
	}
	
}
