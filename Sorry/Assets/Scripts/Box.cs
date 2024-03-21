using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public GameObject piece;
    public string type;
    public int y;
    public int x;
    public int z;

    Box(int x, int y, int z)
    {
        this.y = y;     
        this.x = x;
        this.z = z;
        piece = null;
        type = "white";
    }

    Box(int x, int y, int z, string type) 
    { 
        this.x=x;
        this.y=y;
        this.z=z;
        piece = null;
        this.type = type;
    }
}
