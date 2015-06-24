using UnityEngine;
using System.Collections;

public class GameCell : MonoBehaviour {

	//the value the cell currently contains
	private  int myValue;
	public int MyValue
	{
		get
		{
			return myValue;
		}
		set
		{
			myValue = value;
			text.text = (value > 0 ? value.ToString(): "");
		}
	}

	protected GameBoard gameBoard;

	[SerializeField]
	private TextMesh text;
	
	// Use this for initialization
	virtual protected void Start () 
	{
		transform.parent = GameObject.Find("GameController").transform;
		gameBoard = transform.parent.GetComponent<GameBoard>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
	
}
