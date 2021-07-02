using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

	public Grid grid;
	public GameObject MainMenu;
	public ScoreManager Scoremanager;
 public void OnContinuePressed()
	{
		grid.DisablePause();
		TurnOffMenu();
	}

	public void OnQuitPressed()
	{
		Scoremanager.ResetScore();
		grid.EnablePause();
		grid.CleanGrid();
		TurnOffMenu();
	}

	private void TurnOffMenu()
	{
		MainMenu.SetActive(true);
		gameObject.SetActive(false);
	}
}
