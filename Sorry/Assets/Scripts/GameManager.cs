using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Box;

    public GameObject RedSpawn;
    public GameObject GreenSpawn;
    public GameObject YellowSpawn;
    public GameObject BlueSpawn;

    public GameObject RedHome;
    public GameObject BlueHome;
    public GameObject YellowHome;
    public GameObject GreenHome;
    GameObject[] boxes;

    int i = 0;
    float unit = 1.234286f;

    // Start is called before the first frame update
    void Start()
    {
        RedSpawn = Instantiate(RedSpawn);
        GreenSpawn = Instantiate(GreenSpawn);
        YellowSpawn = Instantiate(YellowSpawn);
        BlueSpawn = Instantiate(BlueSpawn);

        BlueHome = Instantiate(BlueHome);
        RedHome = Instantiate(RedHome);
        GreenHome = Instantiate(GreenHome);
        YellowHome = Instantiate(YellowHome);

        //initialize boxes
        boxes = new GameObject[56];
        for (i = 0; i < 56; i++)
        {
            if (i <= 14)
            {
                boxes[i] = Instantiate(Box, new Vector3(0, 0, unit * i), Quaternion.identity);
                boxes[i].GetComponent<Box>().setType("white");
                boxes[i].GetComponent<Box>().setIndex(i);
            }
            else if (i <= 28)
            {
                boxes[i] = Instantiate(Box, new Vector3(unit*(i-14), 0, unit * 14), Quaternion.identity);
                boxes[i].GetComponent<Box>().setType("white");
                boxes[i].GetComponent<Box>().setIndex(i);
            }
            else if (i <= 41)
            {
                boxes[i] = Instantiate(Box, new Vector3(unit * 14, 0, unit*(-i+42)), Quaternion.identity);
                boxes[i].GetComponent<Box>().setType("white");
                boxes[i].GetComponent<Box>().setIndex(i);
            }
            else if (i <= 55)
            {
                boxes[i] = Instantiate(Box, new Vector3(unit*(-i+56), 0, 0), Quaternion.identity);
                boxes[i].GetComponent<Box>().setType("white");
                boxes[i].GetComponent<Box>().setIndex(i);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        i++;

        if (i == 100)
        {
            RedSpawn.GetComponent<Spawn>().spawnPiece();
            BlueSpawn.GetComponent<Spawn>().spawnPiece();
            GreenSpawn.GetComponent<Spawn>().spawnPiece();
            YellowSpawn.GetComponent<Spawn>().spawnPiece();   
        }

        if (i%200 == 0)
        {
            foreach (GameObject B in boxes)
            {
                if (B.GetComponent<Box>().hasPiece())
                {
                    Debug.Log(B.GetComponent<Box>().getIndex());
                }
            }

            Debug.Log("------");
        }
    }
}
