using UnityEngine;
using System.Collections;

public class NumberPool : MonoBehaviour 
{
	private int[] numberPool;
	private int poolIndex;
	private GameBoard gameBoard;

	// Use this for initialization
	void Start () 
	{
		gameBoard = FindObjectOfType<GameBoard>();
	}

	// Update is called once per frame
	void Update () 
	{
	
	}

	public void GenerateNumberPool(int poolSize)
	{
		int x = 0;
		int upperLimit = FindUpperLimit() - 1;
		numberPool = new int[poolSize];

		while(x < numberPool.Length)
		{
			numberPool[x++] = Random.Range(1, upperLimit);
		}
	}

	int FindUpperLimit()
	{
		int high = -1;
		int[] combo = gameBoard.GetBoardCombo();

		foreach(int i in combo)
		{
			if(i > high)
				high = i;
		}
		return high;
	}

	public int GetNextNumber()
	{
		poolIndex += 1;
		if(poolIndex >= numberPool.Length)
			return -1;
		return numberPool[poolIndex++];
	}
}
