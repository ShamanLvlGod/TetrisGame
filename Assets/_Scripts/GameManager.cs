using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	public static GameManager instance = null;
	public Dictionary<string, GameView> gameModes = new Dictionary<string, GameView>();
	public GameView curentMode;
	public string UserID;
	public string UserName;

	[SerializeField]
	private GameDataHolder gameData;


	void Awake()
	{
		if (instance == null)
			instance = this;

		else if (instance != this)
			Destroy(gameObject);

		DontDestroyOnLoad(gameObject);


		InitGame();
	}

	void InitGame()
	{
		gameModes = gameData.GetModes();
		Resources.UnloadAsset(gameData);
		gameData = null;

		if (PlayerPrefs.HasKey("uniqueID"))
		{
			UserID = PlayerPrefs.GetString("uniqueID");
		}
		else
		{
			System.Guid myGUID = System.Guid.NewGuid();
			PlayerPrefs.SetString("uniqueID", myGUID.ToString());
			UserID = PlayerPrefs.GetString("uniqueID");

		}


		if (PlayerPrefs.HasKey("Name"))
		{
			UserName = PlayerPrefs.GetString("Name");
		}
		else
		{
			UserName = "NoName" + UserID.Substring(0, 5);
			PlayerPrefs.SetString("Name", UserName);
		}

		SetMode("MainMenu");
	}

	public void SetName(string uName)
	{
		UserName = uName;
		PlayerPrefs.SetString("Name", UserName);
	}
	public void SetMode(string name,ModeData modeData = null)
	{
		if (curentMode != null)
			Destroy(curentMode.gameObject);
		curentMode = Instantiate(gameModes[name]);
		curentMode.InitMode(modeData);

	}



}
