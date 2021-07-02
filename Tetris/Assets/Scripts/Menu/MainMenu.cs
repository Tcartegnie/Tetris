using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

	public GameObject PseudoMenu;
	public GameObject LeadBoardMenu;
	public ScoreManager score;

	public void OnNewGamePressed()
	{
		PseudoMenu.SetActive(true);
		gameObject.SetActive(false);
	}

	public void OnLeadboardPressed()
	{
		LeadBoardMenu.SetActive(true);
		LeadBoardMenu.GetComponent<LeaderBoard>().DisplayScoreList();
		gameObject.SetActive(false);
	}

	public void OnQuitPressed()
	{
		Application.Quit();
	}
}
