using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class Home : MonoBehaviour
{
    GameObject[] Pieces;
    public GameObject startPiece;

    private void Start()
    {
        Pieces = new GameObject[4];
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Piece>().kys();
        //adds piece to spawn   
        for (int i = 0; i < Pieces.Length; i++)
        {
            if (Pieces[i] == null)
            {
                Pieces[i] = Instantiate(startPiece, this.transform, worldPositionStays: false);
                Pieces[i].GetComponent<BoxCollider>().enabled = false;
                switch (i)
                {
                    case 0: Pieces[i].transform.position = transform.position + new Vector3(.5f, 0, .5f); break;
                    case 1: Pieces[i].transform.position = transform.position + new Vector3(.5f, 0, -.5f); break;
                    case 2: Pieces[i].transform.position = transform.position + new Vector3(-.5f, 0, -.5f); break;
                    case 3: Pieces[i].transform.position = transform.position + new Vector3(-.5f, 0, .5f); break;
                }
                Pieces[i].transform.localScale = new Vector3(.7f, .7f, .7f);
                break;
            }
        }
    }

    public bool getWin()
    {
        int cnt = 0;

        foreach (GameObject P in Pieces)
            if (P != null)
                cnt++;

        return cnt == 4;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
