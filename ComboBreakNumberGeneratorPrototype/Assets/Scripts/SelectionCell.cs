using UnityEngine;
using System.Collections;

public class SelectionCell : GameCell 
{
	private NumberPool numberPool;

	override protected void Start()
	{
		base.Start();
		numberPool = FindObjectOfType<NumberPool>();
		MyValue = numberPool.GetNextNumber();
	}

	// Update is called once per frame
	void Update () 
	{
	
	}

	public void TransferValue(InputCell _cell)
	{
			_cell.MyValue = MyValue;
			MyValue = numberPool.GetNextNumber();
	}
}
