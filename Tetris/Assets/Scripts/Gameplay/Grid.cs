using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public struct CaseData
{
	public bool state;
	public GameObject obj;
}

public class Grid : MonoBehaviour
{
	public int ScorePerLine;
	public bool OnPause;
    static int width = 10;
    static int height = 52;
	CaseData[,] grid = new CaseData[Width, Height];
	public GameObject PauseMenu;
	public static int Width { get => width; set => width = value; }
	public static int Height { get => height; set => height = value; }
	public ScoreManager score;
	public TetriminosSpawner spawner;
	public void Update()
	{
		if(Input.GetKeyDown(KeyCode.P))
		{
			OnPause = !OnPause;
			PauseMenu.SetActive(OnPause);
		}
	}

	public void SetGridState(int x,int y,bool full)
	{
		grid[x, y].state = full;
	}

	public void SetGridState(int x, int y, bool full, GameObject obj)
	{
		grid[x, y].state = full;
		grid[x, y].obj = obj;
	}

	public bool IsCaseFull(int x, int y)
	{
		return	grid[x, y].state;
	}

	public bool IsCaseFull(Vector2Int position)
	{
		return IsCaseFull(position.x,position.y);
	}

	public void CheckTotalGrid()
	{
		for(int i = 0; i < Height;i++)
		{
			CheckGrid(i);
		}
	}

	public void CheckGrid(int LineID)
	{
		if(CheckLine(LineID))
		{
			DeleteLine(LineID);
			LowLine(LineID);
			score.AddScore(ScorePerLine);
		}	
	}


	public bool CheckLine(int LineID)
	{
		for(int i = 0; i < Width;i++)
		{
			if (grid[i,LineID].state == false)
			{
				return false;
			}
		}
		return true;
	}

	 public void LowLine(int LineID)
	{
		for(int j  = LineID; j < Height; j++)
		{
			for (int i = 0; i < width; i++)
			{
				if (grid[i,j].state == true)
				{
					grid[i, j - 1] = grid[i, j];
					grid[i, j].obj = null;
					grid[i, j].state = false;
					grid[i, j - 1].obj.transform.position -= new Vector3(0, 1, 0);
				}
			}
		}
	}

	public void DeleteLine(int LineID)
	{
		for(int j =0; j < width; j++)
		{
			RemoveBlock(j, LineID);
		}
	}

	public void EnablePause()
	{
		OnPause = true;
	}

	public void DisablePause()
	{
		OnPause = false;
	}

	

	public void CleanGrid()
	{
		for(int i = 0; i < width;i++)
		{
			for(int j = 0; j < Height;j++)
			{
				grid[i, j].state = false;
				spawner.DeleteAllTetriminios();
			}
		}
	}

	private void RemoveBlock(int i,int j)
	{
		if (grid[i, j].obj != null)
		{
			grid[i, j].state = false;
			grid[i, j].obj.GetComponentInParent<Tetrisblock>().DeleteBlock(grid[i, j].obj);
			Destroy(grid[i, j].obj);
		}
	}
}
