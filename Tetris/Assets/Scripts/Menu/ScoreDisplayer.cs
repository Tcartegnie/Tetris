using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplayer : MonoBehaviour
{
	public Text scoreText;
	public Text playerName;
	public void SetScore(int score)
	{
		scoreText.text = score.ToString();
	}
	public void SetPlayerName(string playername)
	{
		this.playerName.text = playername;
	}


}
