using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private List<Transform> positions = new List<Transform>();
    public int cam;
    public float duration = 5f; // Duration in seconds over which the object will move
    public bool conditionToCheck = true; // Runs this script if move is true

    private bool isMoving = false;
    void Start()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Camera"))
        {
            positions.Add(go.GetComponent<Transform>());
        }
        // foreach(var x in positions)
        // {
        //     Debug.Log(x);
        // }
        // Debug.Log("");
        if(conditionToCheck && !isMoving)
        {
            StartCoroutine(Move());
        }
    }
    void Update()
    {
        
    }
    IEnumerator Move()
    {
        isMoving = true;
        Vector3 startPosition = transform.position; // Store the starting position
        Quaternion startRotation = transform.rotation; // Store the starting rotation
        float time = 0;

        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, positions[cam].position, time / duration);
            transform.rotation = Quaternion.Lerp(startRotation, positions[cam].rotation, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        // Ensure the position is set to the target position after the duration
        transform.position = positions[cam].position;
        transform.rotation = positions[cam].rotation;
        yield return new WaitForSeconds(2);
        changeCam(cam+1);
        isMoving = false;
    }
    public void changeCam(int index)
    {
        if(index >= positions.Count)
            cam = 0;
        else if(index <0)
            cam = positions.Count;
        else
            cam = index;
        StartCoroutine(Move());
    }
}
