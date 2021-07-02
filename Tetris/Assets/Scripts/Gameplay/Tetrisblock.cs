using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetrisblock : MonoBehaviour {

	public List<Transform> Children = new List<Transform>();
	float PreviousTime;
	public float FallTime;
	public Vector3 RotationPoint;
	public Grid grid;
	// Update is called once per frame
	public bool CanMove = true;
	public delegate void GridEvent();
	public GridEvent OnTetrisblockInvalidMove;
	public ScoreManager score;
	private void Start()
	{
		CanMove = true;
	}
	void Update () {
		if (CanMove && !grid.OnPause)
		{
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				transform.RotateAround(transform.TransformPoint(RotationPoint), new Vector3(0, 0, 1), 90);
				if (!ValidMove())
				{
					transform.RotateAround(transform.TransformPoint(RotationPoint), new Vector3(0, 0, 1), -90);
				}
			}

			if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				MoveBlock(new Vector3(1, 0, 0));
				if (!ValidMove())
				{
					MoveBlock(new Vector3(-1, 0, 0));
				}
			}

			else if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				MoveBlock(new Vector3(-1, 0, 0));
				if (!ValidMove())
				{
					MoveBlock(new Vector3(1, 0, 0));
				}
			}

			if (Time.time - PreviousTime > (Input.GetKey(KeyCode.DownArrow) ? GetFallTime() / 10 : GetFallTime()))
			{
				transform.position += new Vector3(0, -1, 0);
				if (!ValidMove())
				{
					MoveBlock(new Vector3(0, 1, 0));
					SetPositionOnGrid();
					CanMove = false;
					OnTetrisblockInvalidMove();
				}
				PreviousTime = Time.time;
			}				
		}
	}


	public float GetFallTime()
	{
		if (score.Score <= 0)
		{
			return FallTime / 1;
		}
		else
		{
			return FallTime / (score.Score/80);
		}
	}



	public void MoveBlock(Vector3 Direction)
	{
		transform.position += Direction;
	}
	
	void CheckGrid()
	{
		foreach (Transform children in transform)
		{
			int roundedY = Mathf.RoundToInt(children.transform.position.y);
			grid.CheckGrid(roundedY);
		}
	}

	public void SetPositionOnGrid()
		{
			foreach (Transform children in transform)
			{
				Vector2Int position = GetPositionOnGrid(children);
				grid.SetGridState(position.x, position.y, true, children.gameObject);
			}
	}

	private Vector2Int GetPositionOnGrid(Transform children)
	{
		Vector2Int position = new Vector2Int();
		position.x = Mathf.RoundToInt(children.transform.position.x);
		position.y = Mathf.RoundToInt(children.transform.position.y);
		return position;
	}

	bool ValidMove()
	{
		foreach (Transform children in transform)
		{
			int roundedX = Mathf.RoundToInt(children.transform.position.x);
			int roundedY = Mathf.RoundToInt(children.transform.position.y);

			if(roundedX < 0 || roundedX >= Grid.Width || roundedY < 0)
			{
					return false;
			}
			if(grid.IsCaseFull(roundedX,roundedY))
			{
				return false;
			}
		}
		return true;
	}

	public void DeleteBlock(GameObject block)
	{
		Children.Remove(block.transform);
		Vector2Int position = GetPositionOnGrid(block.transform);
		Destroy(block.gameObject);
	}
	public List<Transform> GetChilds()
	{
		return Children;
	}
}
