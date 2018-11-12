using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Custom/GameDataHolder", order = 1)]
public class GameDataHolder : ScriptableObject
{
	[SerializeField]
	private GameView[] gameModes;

	public Dictionary<string,GameView> GetModes()
	{
		Dictionary<string, GameView> tmp = new Dictionary<string, GameView>();
		for(int i = 0;i<gameModes.Length;i++)
		{
			tmp.Add(gameModes[i].modeName, gameModes[i]);
		}

		return tmp;
	}
	
}
