using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Box : MonoBehaviour
{
    public GameObject piece;
    public string color;
    public int index;


    private void Start()
    {
        piece = null;
    }

    public bool hasPiece()
    {
        return piece != null;
    }

    public void setColor(string color)
    {
        this.color = color; 
    }

    public void setIndex(int index)
    {
        this.index=index;
    }

    public void movePiece(GameObject b)
    {
        piece.GetComponent<Piece>().setIndex(b.GetComponent<Box>().getIndex());
        piece.GetComponent<Piece>().Move(b.transform);
        piece = null;
    }

    public string getColor()
    { 
        return color;
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
