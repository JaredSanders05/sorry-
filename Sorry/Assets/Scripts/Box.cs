using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Box : MonoBehaviour
{
    public GameObject piece;
    public string color;
    public int index;

    public GameObject corner1;
    public GameObject corner2;
    public GameObject corner3;
    public GameObject corner4;

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

    public string getColor()
    {
        return color;
    }

    public void movePiece(GameObject b)
    {
        StartCoroutine(wait(.5f,b));
    }

    private IEnumerator wait(float waitTime, GameObject b)
    {
        piece.GetComponent<Piece>().setIndex(b.GetComponent<Box>().getIndex());

        int i = b.GetComponent<Box>().getIndex();
        if ((i > 0 && i < 14) && (index < 56 && index > 42))
        {
            // Debug.Log("corner1");
            piece.GetComponent<Piece>().Move(corner1.transform);
            yield return new WaitForSeconds(waitTime);
        }
        else if (i > 14 && index < 14)
        {
            // Debug.Log("corner2");
            piece.GetComponent<Piece>().Move(corner2.transform);
            yield return new WaitForSeconds(waitTime);
        }
        else if (i > 28 && index < 28)
        {
            // Debug.Log("corner3");
            piece.GetComponent<Piece>().Move(corner3.transform);
            yield return new WaitForSeconds(waitTime);
        }
        else if (i > 42 && index < 42)
        {
            // Debug.Log("corner4");
            piece.GetComponent<Piece>().Move(corner4.transform);
            yield return new WaitForSeconds(waitTime);
        }

        piece.GetComponent<Piece>().Move(b.transform);
        piece = null;
    }

    public string getPieceColor()
    {
        if (piece == null)
            return "white";

        return piece.tag;
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
}
