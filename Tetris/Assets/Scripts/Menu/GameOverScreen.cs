using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
	public GameObject MainMenu;
    public ScoreDisplayer FinalScoreDisplay;
    public ScoreManager score;
	public TetriminosSpawner Spawner;
	public Grid grid;

	public void OnEnableMenu()
	{
		FinalScoreDisplay.SetPlayerName(score.PlayerName);
		FinalScoreDisplay.SetScore(score.Score);
	}

    public void OnTryAgainPressed()
	{
		ResetGame();
		Spawner.CallSpawnTetriminos();
		gameObject.SetActive(false);
	}

	private void ResetGame()
	{
		score.ResetScore();
		grid.DisablePause();
	}

	public void OnReturnToMainMenuPressed()
	{
		ResetGame();
		MainMenu.SetActive(true);
		gameObject.SetActive(false);
	}
}
