using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {
    public GameObject whiteBoardPiece, blackBoardPiece, parentBoard, tracker;
    private GameObject selectedPiece;
    public bool isRedPlayerTurn = true;
    private GameObject blueText, redText;
    private static GameObject vPanel;
    // Use this for initialization
    void Start () {
        blueText = GameObject.FindGameObjectWithTag("BlueText");
        redText = GameObject.FindGameObjectWithTag("RedText");
        vPanel = GameObject.FindGameObjectWithTag("VictoryPanel");
        vPanel.SetActive(false);
        CreateChessBoard();
        UpdateTurnText();
	}
	
	// Update is called once per frame
	void Update () {
        CheckTouches();
        CheckMouse();
	}

    private void CreateChessBoard ()
    {
        Debug.Log("THIS RUN?");
        for (int x = 0; x < 8; x++)
        {
            bool blackPieceNext;
            if (x % 2 == 0)
            {
                blackPieceNext = true;
            }
            else
            {
                blackPieceNext = false;
            }
            for (int y = 0; y < 8; y++)
            {
                GameObject typeOfBoardPieceToSpawn = blackPieceNext ? blackBoardPiece : whiteBoardPiece;
                GameObject spawnedBoardPiece = Instantiate(typeOfBoardPieceToSpawn, new Vector3(x, 0, y), Quaternion.identity, parentBoard.transform);
                spawnedBoardPiece.GetComponent<BoardPiece>().boardNumber = y * 8 + x;
                spawnedBoardPiece.GetComponent<BoardPiece>().isBlackPiece = blackPieceNext;
                blackPieceNext = !blackPieceNext;
            }
        }

        parentBoard.transform.position = new Vector3 ( -3.5f, 0f, -3.5f );
        parentBoard.transform.parent = tracker.transform;
    }

    private void CheckTouches ()
    {
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit))
            {
                if (raycastHit.collider.gameObject.tag == "Blue" && !isRedPlayerTurn)
                {
                    UnHighlightSelectedPlayer();
                    selectedPiece = raycastHit.collider.gameObject;
                    selectedPiece.GetComponent<CheckersPiece>().ShowPossibleMoves();
                }

                if (raycastHit.collider.gameObject.tag == "Red" && isRedPlayerTurn)
                {
                    UnHighlightSelectedPlayer();
                    selectedPiece = raycastHit.collider.gameObject;
                    selectedPiece.GetComponent<CheckersPiece>().ShowPossibleMoves();
                }

                if (raycastHit.collider.gameObject.tag == "BoardPiece")
                {
                    if (raycastHit.collider.gameObject.GetComponent<BoardPiece>().isHighlighted)
                    {
                        selectedPiece.GetComponent<CheckersPiece>().MoveTo(raycastHit.collider.gameObject);
                    }
                }
            }
        }
    }

    private void CheckMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.gameObject.tag == "Blue" && !isRedPlayerTurn)
                {
                    UnHighlightSelectedPlayer();
                    selectedPiece = raycastHit.collider.gameObject;
                    selectedPiece.GetComponent<CheckersPiece>().ShowPossibleMoves();
                }

                if (raycastHit.collider.gameObject.tag == "Red" && isRedPlayerTurn)
                {
                    //Debug.Log("test");
                    UnHighlightSelectedPlayer();
                    selectedPiece = raycastHit.collider.gameObject;
                    selectedPiece.GetComponent<CheckersPiece>().ShowPossibleMoves();
                }

                if (raycastHit.collider.gameObject.tag == "BoardPiece")
                {
                    if (raycastHit.collider.gameObject.GetComponent<BoardPiece>().isHighlighted)
                    {
                        selectedPiece.GetComponent<CheckersPiece>().MoveTo(raycastHit.collider.gameObject);
                    }
                }
            }
        }
    }

    private void UnHighlightSelectedPlayer ()
    {
        if (selectedPiece != null)
        {
            selectedPiece.GetComponent<CheckersPiece>().UnHighlightBoardPieces();
        }
    }

    public static void TargetFound ()
    {
        GameObject.FindGameObjectWithTag("ScanPrompt").SetActive(false);
    }

    public void UpdateTurnText ()
    {
        if (isRedPlayerTurn)
        {
            redText.SetActive(true);
            blueText.SetActive(false);
        } else
        {
            redText.SetActive(false);
            blueText.SetActive(true);
        }
    }

    public static void ManagerVictory (bool isRed)
    {
        //print("Victory called");
        GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().VictorySound();
        vPanel.SetActive(true);
        if (isRed)
        {
            GameObject.FindGameObjectWithTag("BlueVictory").SetActive(false);
        } else
        {
            GameObject.FindGameObjectWithTag("RedVictory").SetActive(false);
        }
    }
}
