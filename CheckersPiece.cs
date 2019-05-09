using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckersPiece : MonoBehaviour {
    public int position;
    private bool isKinged = false;
    public bool isRed;
    private GameObject[] highlightedPieces, piecesToDestroy;
    private bool[] highlightedPiecesJump;
    private SoundManager sManager;
    
	// Use this for initialization
	void Start () {
        highlightedPieces = new GameObject[4];
        piecesToDestroy = new GameObject[4];
        highlightedPiecesJump = new bool[4];
        sManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void ShowPossibleMoves()
    {
        if (!isKinged)
        {
            #region UnKinged
            if (isRed)
            {
                if (!(position + 7 > 63))
                {
                    if (!(position % 8 == 0))
                    {
                        GameObject pieceAtPlace = CheckIfPlayerOnPiece(position + 7);


                        if (pieceAtPlace == null)
                        {
                            highlightedPieces[0] = BoardPiece.FindBoardPiece(position + 7);
                            highlightedPieces[0].GetComponent<BoardPiece>().Highlight();
                        }
                        else
                        {
                            if (!(position + 14 > 63))
                            {
                                if (!pieceAtPlace.GetComponent<CheckersPiece>().isRed && position % 8 != 1 && CheckIfPlayerOnPiece(position + 14) == null)
                                {
                                    highlightedPiecesJump[0] = true;
                                    piecesToDestroy[0] = pieceAtPlace;
                                    highlightedPieces[0] = BoardPiece.FindBoardPiece(position + 14);
                                    highlightedPieces[0].GetComponent<BoardPiece>().Highlight();
                                }
                            }
                        }
                    }
                }

                if (!(position + 9 > 63))
                {
                    if (!(position % 8 == 7))
                    {
                        GameObject pieceAtPlace = CheckIfPlayerOnPiece(position + 9);

                        if (pieceAtPlace == null)
                        {
                            highlightedPieces[1] = BoardPiece.FindBoardPiece(position + 9);
                            highlightedPieces[1].GetComponent<BoardPiece>().Highlight();
                        }
                        else
                        {
                            if (!(position + 18 > 63))
                            {
                                if (!pieceAtPlace.GetComponent<CheckersPiece>().isRed && position % 8 != 6 && CheckIfPlayerOnPiece(position + 18) == null)
                                {
                                    highlightedPiecesJump[1] = true;
                                    piecesToDestroy[1] = pieceAtPlace;
                                    highlightedPieces[1] = BoardPiece.FindBoardPiece(position + 18);
                                    highlightedPieces[1].GetComponent<BoardPiece>().Highlight();
                                }
                            }
                        }
                    }
                }
            } else
            {
                if (!(position - 9 < 0))
                {
                    if (!(position % 8 == 0))
                    {
                        GameObject pieceAtPlace = CheckIfPlayerOnPiece(position - 9);

                        if (pieceAtPlace == null)
                        {
                            highlightedPieces[0] = BoardPiece.FindBoardPiece(position - 9);
                            highlightedPieces[0].GetComponent<BoardPiece>().Highlight();
                        }
                        else
                        {
                            if (!(position - 18 < 0))
                            {
                                if (pieceAtPlace.GetComponent<CheckersPiece>().isRed && position % 8 != 1 && CheckIfPlayerOnPiece(position - 18) == null)
                                {
                                    highlightedPiecesJump[0] = true;
                                    piecesToDestroy[0] = pieceAtPlace;
                                    highlightedPieces[0] = BoardPiece.FindBoardPiece(position - 18);
                                    highlightedPieces[0].GetComponent<BoardPiece>().Highlight();
                                }
                            }
                        }
                    }
                }

                if (!(position - 7 < 0))
                {
                    if (!(position % 8 == 7))
                    {
                        GameObject pieceAtPlace = CheckIfPlayerOnPiece(position - 7);

                        if (pieceAtPlace == null)
                        {
                            highlightedPieces[1] = BoardPiece.FindBoardPiece(position - 7);
                            highlightedPieces[1].GetComponent<BoardPiece>().Highlight();
                        }
                        else
                        {
                            if (!(position - 14 < 0))
                            {
                                if (pieceAtPlace.GetComponent<CheckersPiece>().isRed && position % 8 != 6 && CheckIfPlayerOnPiece(position - 14) == null)
                                {
                                    highlightedPiecesJump[1] = true;
                                    piecesToDestroy[1] = pieceAtPlace;
                                    highlightedPieces[1] = BoardPiece.FindBoardPiece(position - 14);
                                    Debug.Log(highlightedPieces[1]);

                                    highlightedPieces[1].GetComponent<BoardPiece>().Highlight();
                                }
                            }
                        }
                    }
                }
            }
            #endregion
        } else
        {
            #region isKinged
            if (isRed)
            {
                if (!(position + 9 > 63) && !(position % 8 == 7))
                {
                    GameObject pieceAtPlace;
                    pieceAtPlace = CheckIfPlayerOnPiece(position + 9);

                    if (pieceAtPlace == null)
                    {
                        highlightedPieces[0] = BoardPiece.FindBoardPiece(position + 9);
                        highlightedPieces[0].GetComponent<BoardPiece>().Highlight();
                    }
                    else
                    {
                        if (!(position + 18 > 63))
                        {
                            if (!pieceAtPlace.GetComponent<CheckersPiece>().isRed && position % 8 != 6 && CheckIfPlayerOnPiece(position + 18) == null)
                            {
                                highlightedPiecesJump[0] = true;
                                piecesToDestroy[0] = pieceAtPlace;
                                highlightedPieces[0] = BoardPiece.FindBoardPiece(position + 18);
                                highlightedPieces[0].GetComponent<BoardPiece>().Highlight();
                            }
                        }
                    }
                }


                if (!(position + 7 > 63) && !(position % 8 == 0))
                {
                    GameObject pieceAtPlace;
                    pieceAtPlace = CheckIfPlayerOnPiece(position + 7);

                    if (pieceAtPlace == null)
                    {
                        highlightedPieces[1] = BoardPiece.FindBoardPiece(position + 7);
                        highlightedPieces[1].GetComponent<BoardPiece>().Highlight();
                    }
                    else
                    {
                        if (!(position + 7 > 63))
                        {
                            if (!pieceAtPlace.GetComponent<CheckersPiece>().isRed && position % 8 != 1 && CheckIfPlayerOnPiece(position + 14) == null)
                            {
                                highlightedPiecesJump[1] = true;
                                piecesToDestroy[1] = pieceAtPlace;
                                highlightedPieces[1] = BoardPiece.FindBoardPiece(position + 14);
                                highlightedPieces[1].GetComponent<BoardPiece>().Highlight();
                            }
                        }
                    }
                }

                if (!(position - 7 < 0) && !(position % 8 == 7))
                {
                    GameObject pieceAtPlace;
                    pieceAtPlace = CheckIfPlayerOnPiece(position - 7);

                    if (pieceAtPlace == null)
                    {
                        highlightedPieces[2] = BoardPiece.FindBoardPiece(position - 7);
                        highlightedPieces[2].GetComponent<BoardPiece>().Highlight();
                    }
                    else
                    {
                        if (!(position - 14 < 0))
                        {
                            if (!pieceAtPlace.GetComponent<CheckersPiece>().isRed && position % 8 != 6 && CheckIfPlayerOnPiece(position - 14) == null)
                            {
                                highlightedPiecesJump[2] = true;
                                piecesToDestroy[2] = pieceAtPlace;
                                highlightedPieces[2] = BoardPiece.FindBoardPiece(position - 14);
                                highlightedPieces[2].GetComponent<BoardPiece>().Highlight();
                            }
                        }
                    }
                }

                if (!(position - 9 < 0) && !(position % 8 == 0))
                {
                    GameObject pieceAtPlace;
                    pieceAtPlace = CheckIfPlayerOnPiece(position - 9);

                    if (pieceAtPlace == null)
                    {
                        highlightedPieces[3] = BoardPiece.FindBoardPiece(position - 9);
                        highlightedPieces[3].GetComponent<BoardPiece>().Highlight();
                    }
                    else
                    {
                        if (!(position - 18 < 0))
                        {
                            if (!pieceAtPlace.GetComponent<CheckersPiece>().isRed && position % 8 != 1 && CheckIfPlayerOnPiece(position - 18) == null)
                            {
                                highlightedPiecesJump[3] = true;
                                piecesToDestroy[3] = pieceAtPlace;
                                highlightedPieces[3] = BoardPiece.FindBoardPiece(position - 18);
                                highlightedPieces[3].GetComponent<BoardPiece>().Highlight();
                            }
                        }
                    }
                }
            } else
            {
                if (!(position + 9 > 63) && !(position % 8 == 7))
                {
                    GameObject pieceAtPlace;
                    pieceAtPlace = CheckIfPlayerOnPiece(position + 9);

                    if (pieceAtPlace == null)
                    {
                        highlightedPieces[0] = BoardPiece.FindBoardPiece(position + 9);
                        highlightedPieces[0].GetComponent<BoardPiece>().Highlight();
                    }
                    else
                    {
                        if (pieceAtPlace.GetComponent<CheckersPiece>().isRed && position % 8 != 6 && CheckIfPlayerOnPiece(position + 18) == null)
                        {
                            highlightedPiecesJump[0] = true;
                            piecesToDestroy[0] = pieceAtPlace;
                            highlightedPieces[0] = BoardPiece.FindBoardPiece(position + 18);
                            highlightedPieces[0].GetComponent<BoardPiece>().Highlight();
                        }
                    }
                }


                if (!(position + 7 > 63) && !(position % 8 == 0))
                {
                    GameObject pieceAtPlace;
                    pieceAtPlace = CheckIfPlayerOnPiece(position + 7);

                    if (pieceAtPlace == null)
                    {
                        highlightedPieces[1] = BoardPiece.FindBoardPiece(position + 7);
                        highlightedPieces[1].GetComponent<BoardPiece>().Highlight();
                    }
                    else
                    {
                        if (pieceAtPlace.GetComponent<CheckersPiece>().isRed && position % 8 != 1 && CheckIfPlayerOnPiece(position + 14) == null)
                        {
                            highlightedPiecesJump[1] = true;
                            piecesToDestroy[1] = pieceAtPlace;
                            highlightedPieces[1] = BoardPiece.FindBoardPiece(position + 14);
                            highlightedPieces[1].GetComponent<BoardPiece>().Highlight();
                        }
                    }
                }

                if (!(position - 7 < 0) && !(position % 8 == 7))
                {
                    GameObject pieceAtPlace;
                    pieceAtPlace = CheckIfPlayerOnPiece(position - 7);

                    if (pieceAtPlace == null)
                    {
                        highlightedPieces[2] = BoardPiece.FindBoardPiece(position - 7);
                        highlightedPieces[2].GetComponent<BoardPiece>().Highlight();
                    }
                    else
                    {
                        if (pieceAtPlace.GetComponent<CheckersPiece>().isRed && position % 8 != 6 && CheckIfPlayerOnPiece(position - 14) == null)
                        {
                            highlightedPiecesJump[2] = true;
                            piecesToDestroy[2] = pieceAtPlace;
                            highlightedPieces[2] = BoardPiece.FindBoardPiece(position - 14);
                            highlightedPieces[2].GetComponent<BoardPiece>().Highlight();
                        }
                    }
                }

                if (!(position - 9 < 0) && !(position % 8 == 0))
                {
                    GameObject pieceAtPlace;
                    pieceAtPlace = CheckIfPlayerOnPiece(position - 9);

                    if (pieceAtPlace == null)
                    {
                        highlightedPieces[3] = BoardPiece.FindBoardPiece(position - 9);
                        highlightedPieces[3].GetComponent<BoardPiece>().Highlight();
                    }
                    else
                    {
                        if (pieceAtPlace.GetComponent<CheckersPiece>().isRed && position % 8 != 1 && CheckIfPlayerOnPiece(position - 18) == null)
                        {
                            highlightedPiecesJump[3] = true;
                            piecesToDestroy[3] = pieceAtPlace;
                            highlightedPieces[3] = BoardPiece.FindBoardPiece(position - 18);
                            highlightedPieces[3].GetComponent<BoardPiece>().Highlight();
                        }
                    }
                }
            }
        }
        #endregion
    }

    private static GameObject CheckIfPlayerOnPiece (int pieceNum)
    {
        GameObject[] redPieces = GameObject.FindGameObjectsWithTag("Red");
        GameObject[] bluePieces = GameObject.FindGameObjectsWithTag("Blue");

        for (int i = 0; i< redPieces.Length; i++)
        {
            if (redPieces[i].GetComponent<CheckersPiece>().position == pieceNum)
            {
                return redPieces[i];
            }
        }

        for (int i = 0; i < bluePieces.Length; i++)
        {
            if (bluePieces[i].GetComponent<CheckersPiece>().position == pieceNum)
            {
                return bluePieces[i];
            }
        }

        return null;
    }

    public void MoveTo (GameObject boardPiece)
    {
        //Debug.Log(highlightedPieces[0]);
        //Debug.Log(highlightedPieces[1]);
        sManager.ClickSound();
        if (boardPiece == highlightedPieces[0] && highlightedPiecesJump[0])
        {
            Destroy(piecesToDestroy[0]);
        }

        if (boardPiece == highlightedPieces[1] && highlightedPiecesJump[1])
        {
            Destroy(piecesToDestroy[1]);
        }
        if (boardPiece == highlightedPieces[2] && highlightedPiecesJump[2])
        {
            Destroy(piecesToDestroy[2]);
        }
        if (boardPiece == highlightedPieces[3] && highlightedPiecesJump[3])
        {
            Destroy(piecesToDestroy[3]);
        }

        transform.position = new Vector3(boardPiece.transform.position.x, transform.position.y, boardPiece.transform.position.z);
        position = boardPiece.GetComponent<BoardPiece>().boardNumber;
        if (!isKinged)
        {
            CheckIfKinged();
        }
        UnHighlightBoardPieces();
        ResetVariables();
        Manager m = GameObject.FindGameObjectWithTag("Manager").GetComponent<Manager>();
        //CheckForVictory();
        StartCoroutine(CheckForWin());
        m.isRedPlayerTurn = !m.isRedPlayerTurn;
        m.UpdateTurnText();
    }

    IEnumerator CheckForWin ()
    {
        yield return new WaitForSeconds(2.6f);
        CheckForVictory();
    }
    private void CheckForVictory ()
    {
        if (isRed)
        {
            GameObject[] bluePieces;
            try
            {
                bluePieces = GameObject.FindGameObjectsWithTag("Blue");
                //print(bluePieces.Length); 
            }
            catch
            {
                // Victory
                //print("dacuq");
                Victory();
                return;
            }

            for (int i = 0; i < bluePieces.Length; i++)
            {
                if (bluePieces[i].GetComponent<CheckersPiece>().CheckIfAnyMoves())
                {
                    return;
                }
            }

            // Victory
            Victory();
        }
        else
        {
            GameObject[] redPieces;
            try
            {
                redPieces = GameObject.FindGameObjectsWithTag("Red");
                //print(redPieces.Length);
            }
            catch
            {
                // Victory
                print("dacuq");
                Victory();
                return;
            }

            for (int i = 0; i < redPieces.Length; i++)
            {
                if (redPieces[i].GetComponent<CheckersPiece>().CheckIfAnyMoves())
                {
                    return;
                }
            }

            // Victory
            Victory();
        }
    }

    private void Victory ()
    {
        Manager.ManagerVictory(isRed);
    }

    public bool CheckIfAnyMoves ()
    {
        if (!isKinged)
        {
            if (isRed)
            {
                if (!(position + 7 > 63))
                {
                    if (!(position % 8 == 0))
                    {
                        GameObject pieceAtPlace = CheckIfPlayerOnPiece(position + 7);


                        if (pieceAtPlace == null)
                        {
                            return true;
                        }
                        else
                        {
                            if (!(position + 14 > 63))
                            {
                                if (!pieceAtPlace.GetComponent<CheckersPiece>().isRed && position % 8 != 1 && CheckIfPlayerOnPiece(position + 14) == null)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }

                if (!(position + 9 > 63))
                {
                    if (!(position % 8 == 7))
                    {
                        GameObject pieceAtPlace = CheckIfPlayerOnPiece(position + 9);

                        if (pieceAtPlace == null)
                        {
                            return true;
                        }
                        else
                        {
                            if (!(position + 18 > 63))
                            {
                                if (!pieceAtPlace.GetComponent<CheckersPiece>().isRed && position % 8 != 6 && CheckIfPlayerOnPiece(position + 18) == null)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (!(position - 9 < 0))
                {
                    if (!(position % 8 == 0))
                    {
                        GameObject pieceAtPlace = CheckIfPlayerOnPiece(position - 9);

                        if (pieceAtPlace == null)
                        {
                            return true;
                        }
                        else
                        {
                            if (!(position - 18 < 0))
                            {
                                if (pieceAtPlace.GetComponent<CheckersPiece>().isRed && position % 8 != 1 && CheckIfPlayerOnPiece(position - 18) == null)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }

                if (!(position - 7 < 0))
                {
                    if (!(position % 8 == 7))
                    {
                        GameObject pieceAtPlace = CheckIfPlayerOnPiece(position - 7);

                        if (pieceAtPlace == null)
                        {
                            return true;
                        }
                        else
                        {
                            if (!(position - 14 < 0))
                            {
                                if (pieceAtPlace.GetComponent<CheckersPiece>().isRed && position % 8 != 6 && CheckIfPlayerOnPiece(position - 14) == null)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
        }
        else
        {
            if (isRed)
            {
                if (!(position + 9 > 63) && !(position % 8 == 7))
                {
                    GameObject pieceAtPlace;
                    pieceAtPlace = CheckIfPlayerOnPiece(position + 9);

                    if (pieceAtPlace == null)
                    {
                        return true;
                    }
                    else
                    {
                        if (!(position + 18 > 63))
                        {
                            if (!pieceAtPlace.GetComponent<CheckersPiece>().isRed && position % 8 != 6 && CheckIfPlayerOnPiece(position + 18) == null)
                            {
                                return true;
                            }
                        }
                    }
                }


                if (!(position + 7 > 63) && !(position % 8 == 0))
                {
                    GameObject pieceAtPlace;
                    pieceAtPlace = CheckIfPlayerOnPiece(position + 7);

                    if (pieceAtPlace == null)
                    {
                        return true;
                    }
                    else
                    {
                        if (!(position + 7 > 63))
                        {
                            if (!pieceAtPlace.GetComponent<CheckersPiece>().isRed && position % 8 != 1 && CheckIfPlayerOnPiece(position + 14) == null)
                            {
                                return true;
                            }
                        }
                    }
                }

                if (!(position - 7 < 0) && !(position % 8 == 7))
                {
                    GameObject pieceAtPlace;
                    pieceAtPlace = CheckIfPlayerOnPiece(position - 7);

                    if (pieceAtPlace == null)
                    {
                        return true;
                    }
                    else
                    {
                        if (!(position - 14 < 0))
                        {
                            if (!pieceAtPlace.GetComponent<CheckersPiece>().isRed && position % 8 != 6 && CheckIfPlayerOnPiece(position - 14) == null)
                            {
                                return true;
                            }
                        }
                    }
                }

                if (!(position - 9 < 0) && !(position % 8 == 0))
                {
                    GameObject pieceAtPlace;
                    pieceAtPlace = CheckIfPlayerOnPiece(position - 9);

                    if (pieceAtPlace == null)
                    {
                        return true;
                    }
                    else
                    {
                        if (!(position - 18 < 0))
                        {
                            if (!pieceAtPlace.GetComponent<CheckersPiece>().isRed && position % 8 != 1 && CheckIfPlayerOnPiece(position - 18) == null)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            else
            {
                if (!(position + 9 > 63) && !(position % 8 == 7))
                {
                    GameObject pieceAtPlace;
                    pieceAtPlace = CheckIfPlayerOnPiece(position + 9);

                    if (pieceAtPlace == null)
                    {
                        return true;
                    }
                    else
                    {
                        if (pieceAtPlace.GetComponent<CheckersPiece>().isRed && position % 8 != 6 && CheckIfPlayerOnPiece(position + 18) == null)
                        {
                            return true;
                        }
                    }
                }


                if (!(position + 7 > 63) && !(position % 8 == 0))
                {
                    GameObject pieceAtPlace;
                    pieceAtPlace = CheckIfPlayerOnPiece(position + 7);

                    if (pieceAtPlace == null)
                    {
                        return true;
                    }
                    else
                    {
                        if (pieceAtPlace.GetComponent<CheckersPiece>().isRed && position % 8 != 1 && CheckIfPlayerOnPiece(position + 14) == null)
                        {
                            return true;
                        }
                    }
                }

                if (!(position - 7 < 0) && !(position % 8 == 7))
                {
                    GameObject pieceAtPlace;
                    pieceAtPlace = CheckIfPlayerOnPiece(position - 7);

                    if (pieceAtPlace == null)
                    {
                        return true;
                    }
                    else
                    {
                        if (pieceAtPlace.GetComponent<CheckersPiece>().isRed && position % 8 != 6 && CheckIfPlayerOnPiece(position - 14) == null)
                        {
                            return true;
                        }
                    }
                }

                if (!(position - 9 < 0) && !(position % 8 == 0))
                {
                    GameObject pieceAtPlace;
                    pieceAtPlace = CheckIfPlayerOnPiece(position - 9);

                    if (pieceAtPlace == null)
                    {
                        return true;
                    }
                    else
                    {
                        if (pieceAtPlace.GetComponent<CheckersPiece>().isRed && position % 8 != 1 && CheckIfPlayerOnPiece(position - 18) == null)
                        {
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }

    private void CheckIfKinged ()
    {
        if (isRed)
        {
            if (position / 8 == 7)
            {
                isKinged = true;
            }
        } else
        {
            if (position / 8 == 0)
            {
                isKinged = true;
            }
        }
    }

    public void UnHighlightBoardPieces()
    {
        if (highlightedPieces[0] != null)
        {
            highlightedPieces[0].GetComponent<BoardPiece>().UnHighlight();
            highlightedPieces[0] = null;
        }

        if (highlightedPieces[1] != null)
        {
            highlightedPieces[1].GetComponent<BoardPiece>().UnHighlight();
            highlightedPieces[1] = null;
        }

        if (highlightedPieces[2] != null)
        {
            highlightedPieces[2].GetComponent<BoardPiece>().UnHighlight();
            highlightedPieces[2] = null;
        }

        if (highlightedPieces[3] != null)
        {
            highlightedPieces[3].GetComponent<BoardPiece>().UnHighlight();
            highlightedPieces[3] = null;
        }
    }

    private void ResetVariables ()
    {
        highlightedPieces[0] = null;
        highlightedPieces[1] = null;
        highlightedPieces[2] = null;
        highlightedPieces[3] = null;

        highlightedPiecesJump[0] = false;
        highlightedPiecesJump[1] = false;
        highlightedPiecesJump[2] = false;
        highlightedPiecesJump[3] = false;

        piecesToDestroy[0] = null;
        piecesToDestroy[1] = null;
        piecesToDestroy[2] = null;
        piecesToDestroy[3] = null;
    }
}
