
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;

public class Dice : MonoBehaviour
{
    public static  Rigidbody rb;
    [SerializeField] private GameObject f1, f2, f3, f4, f5, f6;
    [SerializeField] private float maxAppliedForce, startAppliedForce;
    private float forceX, forceY, forceZ;
    public float numFaceUp = -1;
    public bool hadRoll, touchDown;
    private float initY;
    public int click=0;
    private bool hoverClick;

    void OnMouseDown()
    {
        /*Do your stuff here*/
        if (Input.GetMouseButtonDown(0))
        {
            hoverClick = true;
        }
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        touchDown = false;
        hadRoll = false;
        hoverClick = false;
        initY = rb.transform.position.y;

    }

    void Update()
    {
        if (rb != null)
        {
            if (hoverClick && click==0)
            {
                click=1;
                rollDice();
                hoverClick = false;
            }
        }
        else
        {
            Debug.Log("Dice is null!");
        }
    }

    public float getNumFaceUp()
    {
        return numFaceUp;
    }

    private void rollDice() {
        forceX = Random.Range(1, maxAppliedForce);
        forceY = Random.Range(1, maxAppliedForce);  
        forceZ = Random.Range(1, maxAppliedForce);
        rb.AddForce(Vector3.up * startAppliedForce);
        rb.AddTorque(forceX,forceY,forceZ);
        
        hadRoll = true;

    }
}
