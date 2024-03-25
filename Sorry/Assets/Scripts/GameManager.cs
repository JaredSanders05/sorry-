using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

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

        RedSpawn.GetComponent<Spawn>().setBox(boxes[46]);
        GreenSpawn.GetComponent<Spawn>().setBox(boxes[32]);
        YellowSpawn.GetComponent<Spawn>().setBox(boxes[18]);
        BlueSpawn.GetComponent<Spawn>().setBox(boxes[4]);


        RedSpawn = Instantiate(RedSpawn);
        GreenSpawn = Instantiate(GreenSpawn);
        YellowSpawn = Instantiate(YellowSpawn);
        BlueSpawn = Instantiate(BlueSpawn);

        BlueHome = Instantiate(BlueHome);
        RedHome = Instantiate(RedHome);
        GreenHome = Instantiate(GreenHome);
        YellowHome = Instantiate(YellowHome);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        i++;

        //spawns peices
        if (i == 100)
        {
            RedSpawn.GetComponent<Spawn>().spawnPiece();
            BlueSpawn.GetComponent<Spawn>().spawnPiece();
            GreenSpawn.GetComponent<Spawn>().spawnPiece();
            YellowSpawn.GetComponent<Spawn>().spawnPiece();
            StartCoroutine( movePieces(2f) );
        }
    }

    private IEnumerator movePieces(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);

            List<int> list = new List<int>();
            foreach (GameObject B in boxes)
            {
                if (B.GetComponent<Box>().hasPiece())
                {
                    list.Add(B.GetComponent<Box>().getIndex());
                }
            }

            //picks random box that has a peice
            int randIndex = list[Random.Range(0, list.Count)];
            int move = randIndex + Random.Range(1, 7);
            if (move >= 56)
                move %= 56;
            boxes[randIndex].GetComponent<Box>().setPieceIndex(move);
            boxes[randIndex].GetComponent<Box>().movePiece(boxes[move].transform);
        }
    }
}
