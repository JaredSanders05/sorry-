using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class moveDice : MonoBehaviour
{
    Dice d;
    [SerializeField] private TextMeshProUGUI tmp;
    // Start is called before the first frame update
    void Awake()
    {
        d = FindObjectOfType<Dice>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (d != null && tmp!=null)
        {
            if (d.numFaceUp != -1)
            {
                tmp.text = "Dice: " + d.numFaceUp.ToString();
            }
        }
    }
}
