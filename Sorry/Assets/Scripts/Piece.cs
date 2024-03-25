using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TerrainTools;
using UnityEngine.VFX;
using static UnityEngine.GraphicsBuffer;

public class Piece : MonoBehaviour
{
    public GameObject Spawn;
    public string color; //set before game
    public int index;
    private Transform target;
    private float speed = 9f;
   
    public void setSpawn(GameObject g)
    {
        Spawn = g;
    }

    public string getColor()
    {
        return color; 
    }

    public void setIndex(int index)
    {
        this.index = index;
    }

    public int getIndex()
    {
        return index;
    }

    private void Start()
    {
        target = transform;
    }

    public void Move(Transform t)
    {
        //moves there
        target = t;
    }

    public void kys()
    {
        Destroy(gameObject);
    }
    public void die()
    {
        //plays animation
        Spawn.GetComponent<Spawn>().add();
        Destroy(gameObject);
    }

    private void Update()
    {
        if (transform.position != target.position)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }
}
