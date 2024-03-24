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
        boxes = new GameObject[58];
        for (i = 0; i < 15; i++)
        {
            boxes[i] = Instantiate(Box, new Vector3(unit * i, 0, 0), Quaternion.identity);
            boxes[i].GetComponent<Box>().setType("white");
            boxes[i].GetComponent<Box>().setIndex(i);
        }

        for (i = 0; i < 15; i++)
        {
            boxes[i+15] = Instantiate(Box, new Vector3(unit * 14, 0, unit * i), Quaternion.identity);
            boxes[i+15].GetComponent<Box>().setType("white");
            boxes[i + 15].GetComponent<Box>().setIndex(i);
        }

        for (i = 14; i >= 0; i--)
        {
            boxes[-i+14 + 30] = Instantiate(Box, new Vector3(unit * i, 0, unit * 14), Quaternion.identity);
            boxes[-i+14 + 30].GetComponent<Box>().setType("white");
            boxes[-i+14 + 30].GetComponent<Box>().setIndex(i);
        }

        for (i = 13; i >= 1; i--)
        {
            boxes[-i+13 + 45] = Instantiate(Box, new Vector3(0, 0, unit * i), Quaternion.identity);
            boxes[-i+13 +45].GetComponent<Box>().setType("white");
            boxes[-i + 13 + 45].GetComponent<Box>().setIndex(i);
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
    }
}
