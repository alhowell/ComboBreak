using UnityEngine;
using System.Collections;

public class GameBoard : MonoBehaviour 
{
	public int BoardSize;
	private InputCell[] gameBoard;
	private GameCell[] boardCombo;
	private SelectionCell[] boardSelections;
	private NumberPool numberPool;
	private int boardWidth = 0;
	private int boardHeight = 0;
	private InputCell activeCell;
	// Use this for initialization
	void Start () 
	{
		initializeBoard();
		numberPool = FindObjectOfType<NumberPool>();
		numberPool.GenerateNumberPool(BoardSize * 10);
	}
	
	// Update is called once per frame
	void Update () 
	{
		CheckInput();
	}

	void CheckInput()
	{
		if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
		{
			Vector3 pos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

			if(hit.collider == null || hit.collider.tag == "Cell")
			{
				SetActiveCell(null);
			}
			else if(hit.collider.tag == "InputCell")
			{
				InputCell cell = hit.collider.GetComponent<InputCell>();
				SetActiveCell(cell);
			}
			else if(hit.collider.tag == "SelectionCell")
			{
				SelectionCell cell = hit.collider.GetComponent<SelectionCell>();
				cell.TransferValue(activeCell);
			}
		}
	}

	/// <summary>
	/// Initializes the board.
	/// </summary>
	void initializeBoard()
	{
		boardWidth = boardHeight = BoardSize;
		GameObject inputCell = Resources.Load("InputGameCell") as GameObject;
		GameObject selectionCell = Resources.Load("SelectionGameCell") as GameObject;
		GameObject defGameCell = Resources.Load("DefGameCell") as GameObject;

		gameBoard = new InputCell[boardWidth * boardHeight];
		boardSelections = new SelectionCell[boardHeight];
		boardCombo = new GameCell[boardWidth];

		int selectionsIndex = 0;
		int comboIndex = 0;
		for(int y = 0; y <= boardHeight; y++)
		{
			for(int x = 0; x <= boardWidth; x++)
			{
				Vector3 position = new Vector3(x + (x * 0.15f), (-y*(BoardSize - 2)) - (y * 0.15f), 0);
				if(x == boardWidth && y != boardHeight)
				{
					GameObject so = Instantiate(selectionCell, position, Quaternion.identity)as GameObject;
					boardSelections[selectionsIndex] = so.GetComponent<SelectionCell>();
				}
				else if(y == boardHeight && x < boardWidth)
				{
					GameObject bco = Instantiate(defGameCell, position, Quaternion.identity)as GameObject;
					boardCombo[comboIndex++] = bco.GetComponent<GameCell>();
				}
				else if(x < boardWidth)
				{
					GameObject gbo = Instantiate(inputCell, position, Quaternion.identity) as GameObject;
					gameBoard[x] = gbo.GetComponent<InputCell>();
				}
			}
		}

		int[] Combo = {3, 5, 6};
		SetBoardCombo(Combo);
	}

	/// <summary>
	/// Sets the board combo.
	/// </summary>
	/// <param name="_combo">_combo.</param>
	public void SetBoardCombo(int[] _combo)
	{

		for(int i = 0; i < boardCombo.Length; i++)
		{
			boardCombo[i].MyValue = _combo[i];
		}
	}

	public void SetActiveCell(InputCell _cell)
	{
		if(activeCell)
			activeCell.DeactivateCell();

		activeCell = _cell;

		if(activeCell)
			activeCell.ActivateCell();
	}

	public InputCell GetActiveCell()
	{
		return activeCell;
	}

	public int[] GetBoardCombo()
	{
		int[] combo = new int[boardCombo.Length];
		for(int i = 0; i < combo.Length; i++)
		{
			combo[i] = boardCombo[i].MyValue;
		}
		return combo;
	}

}
