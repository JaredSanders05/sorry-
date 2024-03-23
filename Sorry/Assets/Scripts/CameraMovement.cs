using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Vector3 targetPosition = new Vector3(1f, 2f, 3f); // Set your target position here
    public Vector3 targetEulerAngles = new Vector3(90f, 0f, 180f); // Set your target rotation here
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
        Quaternion targetRotation = Quaternion.Euler(targetEulerAngles);
        float time = 0;

        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            transform.rotation = Quaternion.Lerp(startRotation, targetRotation, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        // Ensure the position is set to the target position after the duration
        transform.position = targetPosition;
        transform.rotation = targetRotation;
    }
    
}
