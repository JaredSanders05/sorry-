using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Box;
    List<GameObject> boxes;

    // Start is called before the first frame update
    void Start()
    {
        boxes = new List<GameObject>();
        //initialize boxes
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
