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
	public Button Confirmation;
	public void OnConfirmeButtonPressed()
	{
		score.SetPlayerName(field.text);
		grid.DisablePause();
		spawner.CallSpawnTetriminos();
		field.text = "";
		ScoreDisplayer.SetActive(true);
		gameObject.SetActive(false);
	}

	public void OnReturnButtonPressed()
	{
		field.text = "";
		MainMenu.SetActive(true);
		gameObject.SetActive(false);
	}

	public void OnInputFieldValueChange()
	{
		if(field.text == "")
		{
			Confirmation.interactable = false;
		}
		else
		{
			Confirmation.interactable = true;
		}
	}
}
