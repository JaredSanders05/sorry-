using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public GameObject piece;
    public string type;
  

    Box(int x, int y, int z)
    {
        piece = null;
        type = "white";
    }

    Box(int x, int y, int z, string type) 
    { 
   
        piece = null;
        this.type = type;
    }
}
