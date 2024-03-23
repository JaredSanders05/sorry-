using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform pos1;
    public float duration = 5f; // Duration in seconds over which the object will move
    public bool conditionToCheck = true; // Runs this script if move is true
    
    void Update(){
        if(conditionToCheck){
           StartCoroutine(Move());
        }
    }
    IEnumerator Move(){
        Vector3 startPosition = transform.position; // Store the starting position
        Quaternion startRotation = transform.rotation; // Store the starting rotation
        float time = 0;

        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, pos1.position, time / duration);
            transform.rotation = Quaternion.Lerp(startRotation, pos1.rotation, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        // Ensure the position is set to the target position after the duration
        transform.position = pos1.position;
        transform.rotation = pos1.rotation;
    }
    
}
