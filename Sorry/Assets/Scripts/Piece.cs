using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TerrainTools;
using UnityEngine.VFX;

public class Piece : MonoBehaviour
{
    public string color;

    Piece(string color)
    {
        this.color = color;
    }

    public void Move(int x, int y, int z)
    {
       //moves there
    }

    public void die()
    {
        //plays animation
        //dies
    }
}
