using System.Collections;
using TMPro;
using UnityEngine;

public class checkFaceUp : MonoBehaviour
{
    Dice d;
    void Awake() {
        d = FindObjectOfType<Dice>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (d.GetComponent<Rigidbody>().velocity == Vector3.zero && d.hadRoll) {
            d.numFaceUp = int.Parse(other.name);
            d.hadRoll = false ;
            d.click = 0;
        }
    }




}
