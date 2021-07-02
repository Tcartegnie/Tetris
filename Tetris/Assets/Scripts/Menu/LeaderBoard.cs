using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempData
{
	public string name;
	public int value;
	public TempData(string name, int value)
	{
		this.name = name;
		this.value = value;
	}
}

public class LeaderBoard : MonoBehaviour
{
	public GameObject MainMenu;
	public GameObject ScoreDisplayer;
	public Transform Content;
	public ScoreManager datas;
	public List<GameObject> DataRects = new List<GameObject>();
	public void DisplayScoreList()
	{
		Dictionary<string,int> Datas =  datas.LoadPlayerNameList();
		List<TempData> TempDatas = new List<TempData>();
		foreach(KeyValuePair<string,int> paire in Datas)
		{
			TempDatas.Add(new TempData(paire.Key,paire.Value));
		}

		TempData TempData = new TempData("",0);
		for(int i = 0; i < TempDatas.Count;i++)
		{
			for (int j = 0; j < TempDatas.Count; j++)
			{
				if (TempDatas[i].value <= TempDatas[j].value)
				{
					TempData = TempDatas[i];
					TempDatas[i] = TempDatas[j];
					TempDatas[j] = TempData; 
				}
			}
	
		}

		for (int i = TempDatas.Count-1; i >= 0; i--)
		{
			AddNewScoreDisplayer(TempDatas[i].name, TempDatas[i].value);
		}

	}

	public void AddNewScoreDisplayer(string Name, int score)
	{
		GameObject GO =	Instantiate(ScoreDisplayer, Content);
		ScoreDisplayer currentDisplayer = GO.GetComponent<ScoreDisplayer>();
		currentDisplayer.SetPlayerName(Name);
		currentDisplayer.SetScore(score);
		DataRects.Add(GO);
	}

	public void DeleteAll()
	{
		for(int i = 0; i < DataRects.Count;i++)
		{
			Destroy(DataRects[i].gameObject);
		}
		DataRects.Clear();
	}


	public void OnReturnButtonPressed()
	{
		DeleteAll();
		MainMenu.SetActive(true);
		gameObject.SetActive(false);
	}

}
