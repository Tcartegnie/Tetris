using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using System;

[Serializable]
class SaveData
{
	public string playerName;
	public int score;
}
[Serializable]
class SaveListData
{
	public Dictionary<string, int> playerDatas = new Dictionary<string, int>();
}
public class ScoreManager : MonoBehaviour
{
    public int Score;
	public string PlayerName;
	static string PlayerListFileName = "Save";
	public ScoreDisplayer scoreDisplayer;

	public void AddScore(int score)
	{
		Score += score;
		UpdateScore();
	}
	public void SetScore(int score)
	{
		Score = 0;
		UpdateScore();
	}
	public void UpdateScore()
	{
		scoreDisplayer.SetScore(Score);
	} 

	public Dictionary<string, int> LoadPlayerNameList()
	{
		BinaryFormatter bf = new BinaryFormatter();
		string DataPath = Application.persistentDataPath + "/" + PlayerListFileName + ".dat";
		if (File.Exists(DataPath))
		{
			FileStream file = File.Open(DataPath, FileMode.Open);
			SaveListData data = new SaveListData();
			data = (SaveListData)bf.Deserialize(file);
			file.Close();
			return data.playerDatas;
		}
		Debug.Log("File " + DataPath +" do not exist");
		return new Dictionary<string, int>();
	}

	public void SaveScore()
	{
		BinaryFormatter bf = new BinaryFormatter();
		string DataPath = Application.persistentDataPath + "/" + PlayerListFileName + ".dat";
		Debug.Log(DataPath);
		Dictionary<string, int> playerscors = LoadPlayerNameList();
		FileStream file;
		
		if (playerscors.ContainsKey(PlayerName))
		{
			if (Score > playerscors[PlayerName])
			{
				playerscors[PlayerName] = Score;
			}
			else
			{
				return;
			}
		}
		else
		{
			playerscors.Add(PlayerName,Score);
		}

		if(!File.Exists(DataPath))
		{
			file = File.Create(DataPath);
		}
		else
		{
			file = File.Open(DataPath, FileMode.Open);
		}
		SaveListData Data = new SaveListData();
		Data.playerDatas = playerscors;
		bf.Serialize(file, Data);
		file.Close();
	}

	public void SetPlayerName(string name)
	{
		PlayerName = name;
		UpdatePlayerName();
	}

	public void UpdatePlayerName()
	{
		scoreDisplayer.SetPlayerName(PlayerName);
	}
	public void ResetScore()
	{
		SetScore(0);
	}
}
