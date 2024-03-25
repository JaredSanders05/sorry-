using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Box : MonoBehaviour
{
    public GameObject piece;
    string type;
    int index;

    Box(string type, int index)
    {
        piece = null;
        this.type = type;
        this.index = index;
    }

    private void Start()
    {
        piece = null;
    }

    public bool hasPiece()
    {
        return piece != null;
    }

    public void setType(string type)
    {
        this.type = type; 
    }

    public void setIndex(int index)
    {
        this.index=index;
    }

    public void movePiece(Transform t)
    {
        piece.GetComponent<Piece>().Move(t);
        piece = null;
    }

    public string getType()
    { 
        return type;
    }

    public GameObject getPiece()
    {
        return piece;
    }

    //may never be used
    public int getIndex()
    {
        return index;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (piece == null && other.gameObject.GetComponent<Piece>().getIndex() == index)
            piece = other.gameObject;
        else if (other.gameObject.GetComponent<Piece>().getIndex() == index)
        {
            piece.GetComponent<Piece>().die();
            piece = other.gameObject;
        }
    }
    public void setPieceIndex(int i)
    {
        piece.GetComponent<Piece>().setIndex(i);
    }

    public string getPieceColor()
    {
        return piece.GetComponent<Piece>().getColor();
    }
}
