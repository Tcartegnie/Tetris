using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/TetriminosList", order = 1)]
public class SOBJTetriminiosList : ScriptableObject
{
	public List<SOBJTetriminos> Tetriminos = new List<SOBJTetriminos>();

	public SOBJTetriminos GetRandomTetriminos()
	{
		return	Tetriminos[Random.Range(0,Tetriminos.Count)];
	}
}
