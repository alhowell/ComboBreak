using UnityEngine;
using System.Collections;

public class SelectionCell : GameCell 
{

	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnMouseDown()
	{
		if(gameBoard.GetActiveCell() != null)
		{
			gameBoard.GetActiveCell().MyValue = MyValue;
			MyValue = -1;
		}
	}
}
