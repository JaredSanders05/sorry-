using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TerrainTools;
using UnityEngine.VFX;

public class Piece : MonoBehaviour
{
    public GameObject Spawn;
    public string color; //set before game
    public int index; 


    //Used to Initialize piece to gameboard
    Piece (string color, int index, GameObject Spawn)
    {
        this.color = color;
        this.index = index;
        this.Spawn = Spawn;
    }

    public void setIndex(int index)
    {
        this.index = index;
    }

    public int getIndex(int index)
    {
        return index;
    }


    public void Move(Transform t)
    {
       //moves there
    }

    public void die()
    {
/*        Spawn.getScript.add();
*/       //plays animation
        Destroy(this);
    }
}