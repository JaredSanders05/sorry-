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
    List<GameObject> boxes;

    int i = 0;
    float unit = 1.234286f;

    // Start is called before the first frame update
    void Start()
    {
        boxes = new List<GameObject>();
        RedSpawn = Instantiate(RedSpawn);
        GreenSpawn = Instantiate(GreenSpawn);
        YellowSpawn = Instantiate(YellowSpawn);
        BlueSpawn = Instantiate(BlueSpawn);

        //initialize boxes
        Box = Instantiate(Box);
    }

    // Update is called once per frame
    void Update()
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
