using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    GameObject[] Pieces; //all pieces in spawn
    public GameObject Piece; //add before game,set color bedore game and index = -1

    void Start()
    {
        Pieces = new GameObject[4];
        //initialize 4 piece objects into pieces
    }

    public void add()
    {
        //adds piece to spawn circle
    }
    public void spawnPiece()
    {
        //spawns (initializes) piece on gameboard at start pos and correct box index 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
