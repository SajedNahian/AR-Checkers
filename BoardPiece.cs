using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardPiece : MonoBehaviour {
    public int boardNumber;
    private GameObject redPiece, bluePiece;
    public bool isBlackPiece, isHighlighted;
    private float heightOfPieces = .2f;
    public Material highlightMaterial, originalMaterial;
	// Use this for initialization
	void Start () {
        originalMaterial = GetComponent<Renderer>().material;
        redPiece = GameObject.FindGameObjectWithTag("Red");
        bluePiece = GameObject.FindGameObjectWithTag("Blue");
        if (isBlackPiece)
        {
            if (boardNumber / 8 <= 2)
            {
                SpawnRedPiece();
            }

            if (boardNumber / 8 >= 5)
            {
                SpawnBluePiece();
            }
        }
        if (boardNumber == 63)
        {
            Destroy(redPiece);
            Destroy(bluePiece);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void SpawnRedPiece ()
    {
        GameObject piece = Instantiate(redPiece, new Vector3(transform.position.x, heightOfPieces, transform.position.z), Quaternion.identity);
        piece.transform.parent = GameObject.FindGameObjectWithTag("ImageTarget").transform;
        piece.GetComponent<CheckersPiece>().position = boardNumber;
        piece.GetComponent<CheckersPiece>().isRed = true;
    }

    private void SpawnBluePiece ()
    {
        GameObject piece = Instantiate(bluePiece, new Vector3(transform.position.x, heightOfPieces, transform.position.z), Quaternion.identity);
        piece.transform.parent = GameObject.FindGameObjectWithTag("ImageTarget").transform;
        piece.GetComponent<CheckersPiece>().position = boardNumber;
        piece.GetComponent<CheckersPiece>().isRed = false;
    }

    public static GameObject FindBoardPiece (int num)
    {
        GameObject[] boardPieces = GameObject.FindGameObjectsWithTag("BoardPiece");

        foreach (GameObject bPiece in boardPieces)
        {
            if (bPiece.GetComponent<BoardPiece>().boardNumber == num)
            {
                return bPiece;
            }
        }

        return null;
    }

    public void Highlight ()
    {
        GetComponent<Renderer>().material = highlightMaterial;
        isHighlighted = true;
    }

    public void UnHighlight ()
    {
        GetComponent<Renderer>().material = originalMaterial;
        isHighlighted = false;
    }
}
