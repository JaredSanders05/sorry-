using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private List<Transform> positions = new List<Transform>();
    public int cam;
    public float duration = 5f; // Duration in seconds over which the object will move
    public bool conditionToCheck = true; // Runs this script if move is true

    public GameObject MainCam1;
    public GameObject MainCam2;
    public GameObject MainCam3;
    public GameObject MainCam4;
    public GameObject BlueCam;
    public GameObject YellowCam;
    public GameObject GreenCam;
    public GameObject RedCam;

    void Start()
    {   
        positions.Add(MainCam1.GetComponent<Transform>());
        positions.Add(MainCam2.GetComponent<Transform>());
        positions.Add(MainCam3.GetComponent<Transform>());
        positions.Add(MainCam4.GetComponent<Transform>());
        positions.Add(BlueCam.GetComponent<Transform>());
        positions.Add(YellowCam.GetComponent<Transform>());
        positions.Add(GreenCam.GetComponent<Transform>());
        positions.Add(RedCam.GetComponent<Transform>());

        // foreach(var x in positions)
        // {
        //     Debug.Log(x);
        // }
        // Debug.Log("");
        /*  if(conditionToCheck && !isMoving)
          {
              StartCoroutine(Move());
          }*/
    }
    void Update()
    {
        
    }
    IEnumerator Move()
    {
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
/*        changeCam(cam+1); */
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
