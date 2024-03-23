using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    GameObject[] Pieces; //all pieces in spawn
    public GameObject startPiece; //add before game,set color bedore game and index = -1
    public int startInddex; // index piece starts at

    void Start()
    {
        Pieces = new GameObject[4];
        //initialize 4 piece objects into pieces
        
    }

    public int getNumPieces()
    {
        int cnt = 0;

        foreach (GameObject p in Pieces)
        {
            if (p != null) { cnt++; }
        }

        return cnt;
    }

    public void add()
    {
        //adds piece to spawn
        for (int i = 0; i < Pieces.Length; i++)
        {
            if (Pieces[i] == null)
            {
                Pieces[i] = startPiece;
                // Instantiate();
                break;
            }
        }
    }
    public void spawnPiece()
    {
        //spawns (initializes) piece on gameboard at startIndex adn removes one from Peices
        for (int i = 0; i < Pieces.Length; i++)
        {
            if (Pieces[i] != null)
            {
                Destroy(Pieces[i]);
                Pieces[i] = null;
                break;
            }
        }

        Piece placedPiece = Instantiate(startPiece.GetComponent<Piece>(), new Vector3(0, 0, 0), Quaternion.identity) as Piece;
        placedPiece.setIndex(startInddex);
        placedPiece.setSpawn(gameObject);

    }
}
