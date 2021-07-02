using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NicknameMenu : MonoBehaviour
{
	public TetriminosSpawner spawner;
	public Grid grid;
	public GameObject MainMenu;
	public GameObject ScoreDisplayer;
	public InputField field;
	public ScoreManager score;
	public void OnConfirmeButtonPressed()
	{
		score.SetPlayerName(field.text);
		grid.DisablePause();
		spawner.CallSpawnTetriminos();
		ScoreDisplayer.SetActive(true);
		gameObject.SetActive(false);
	}

	public void OnReturnButtonPressed()
	{
		MainMenu.SetActive(true);
		gameObject.SetActive(false);
	}
}
