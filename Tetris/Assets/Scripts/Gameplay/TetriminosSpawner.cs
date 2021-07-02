using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetriminosSpawner : MonoBehaviour
{
    public List<SOBJTetriminos> Tetraminos = new List<SOBJTetriminos>();
	public Grid grid;
	// Start is called before the first frame update
	public List<GameObject> CurrentTetraminos = new List<GameObject>();
	public GameOverScreen gameOverScreen;
	public ScoreManager score;
	SOBJTetriminos NextTetriminos;
	public StateDisplayer stateDisplayer;

	public void OnSpawnEvent()
	{
		CallSpawnTetriminos();
	}

	public void  CallSpawnTetriminos()
	{
		if (NextTetriminos == null)
		{
			NextTetriminos = Tetraminos[Random.Range(0, Tetraminos.Count)];
		}
		grid.CheckTotalGrid();
		GameObject GO = SpawnTetriminos(NextTetriminos);
		NextTetriminos = Tetraminos[Random.Range(0, Tetraminos.Count)];
		stateDisplayer.SetCasePicture(NextTetriminos.Picture);
		if (CheckLooseCondition(GO))
		{
			Destroy(GO);
			Gameover();
		}
	}

	public void Gameover()
	{
		score.SaveScore();
		grid.EnablePause();
		grid.CleanGrid();
		gameOverScreen.gameObject.SetActive(true);
		gameOverScreen.OnEnableMenu();
	}

	public GameObject SpawnTetriminos(SOBJTetriminos obj)
	{
		GameObject GO = Instantiate(obj.Tetriminos, transform.position, new Quaternion());
		GO.GetComponent<Tetrisblock>().OnTetrisblockInvalidMove += OnSpawnEvent;
		GO.GetComponent<Tetrisblock>().grid = grid;
		GO.GetComponent<Tetrisblock>().score = score;
		CurrentTetraminos.Add(GO);
		return GO;
	}

	public bool CheckLooseCondition(GameObject obj)
	{
		List<Transform> trs = obj.GetComponent<Tetrisblock>().GetChilds();
		foreach (Transform tr in trs)
		{
			if (grid.IsCaseFull(new Vector2Int((int)tr.position.x,(int)tr.position.y)))
			{
				return true;
			}
		}
		return false;
	}

	public Vector2Int GetSpawnPosition()
	{
		int roundedX = Mathf.RoundToInt(transform.position.x);
		int roundedY = Mathf.RoundToInt(transform.position.y);
		return new Vector2Int(roundedX, roundedY);
	}
	
	public void DeleteAllTetriminios()
	{
		for (int i = 0; i < CurrentTetraminos.Count; i++)
		{
			Destroy(CurrentTetraminos[i].gameObject);
		}
		CurrentTetraminos.Clear();
	}

}
