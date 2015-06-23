using UnityEngine;
using System.Collections;

public class InputCell : GameCell 
{

	// Update is called once per frame
	void Update () 
	{
	}

	void OnMouseDown()
	{
		if(gameBoard.GetActiveCell() == this)
			return;
		
		ActivateCell();
	}
	
	void ActivateCell()
	{
		gameBoard.SetActiveCell(this);
		GetComponent<Renderer>().material.color = Color.green;
	}
	
	public void DeactivateCell()
	{
		GetComponent<Renderer>().material.color = Color.white;
	}
}
