using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    GameObject piece;
    string type;
    int index;

    Box(string type, int index)
    {
        piece = null;
        this.type = type;
        this.index = index;
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
    }

    //piece is set by trigger commands, 
    private void OnTriggerEnter(Collider other)
    {
        piece = other.gameObject;
        piece.GetComponent<Piece>().setIndex(index);
    }

    private void OnTriggerExit(Collider other)
    {
        piece = null;
    }

    public string getType()
    { 
        return type;
    }

    //may never be used
    public int getIndex()
    {
        return index;
    }

    public GameObject getPiece()
    {
        return piece;
    }
}
