using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class GameManager : MonoBehaviour
{
    public GameObject Box;
    public Camera Camera;
    public GameObject Dice;

    public GameObject RedSpawn;
    public GameObject GreenSpawn;
    public GameObject YellowSpawn;
    public GameObject BlueSpawn;

    public GameObject RedHome;
    public GameObject BlueHome;
    public GameObject YellowHome;
    public GameObject GreenHome;
    public GameObject pointLight;
    GameObject[] boxes;

    List<string> turns;
    int i = 0;
    float diceNum;
    int currentBox;
    int nextBox;
    float unit = 1.234286f;

    // Start is called before the first frame update
    void Start()
    {
        turns = new List<string> {"Blue", "Yellow", "Green", "Red"};

        //initialize boxes
        boxes = new GameObject[56];
        for (i = 0; i < 56; i++)
        {
            if (i <= 14)
            {
                boxes[i] = Instantiate(Box, new Vector3(0, 0, unit * i), Quaternion.identity);
                boxes[i].GetComponent<Box>().setIndex(i);
            }
            else if (i <= 28)
            {
                boxes[i] = Instantiate(Box, new Vector3(unit*(i-14), 0, unit * 14), Quaternion.identity);
                boxes[i].GetComponent<Box>().setIndex(i);
            }
            else if (i <= 41)
            {
                boxes[i] = Instantiate(Box, new Vector3(unit * 14, 0, unit*(-i+42)), Quaternion.identity);
                boxes[i].GetComponent<Box>().setIndex(i);
            }
            else if (i <= 55)
            {
                boxes[i] = Instantiate(Box, new Vector3(unit*(-i+56), 0, 0), Quaternion.identity);
                boxes[i].GetComponent<Box>().setIndex(i);
            }
        }

        RedSpawn.GetComponent<Spawn>().setBox(boxes[46]);
        GreenSpawn.GetComponent<Spawn>().setBox(boxes[32]);
        YellowSpawn.GetComponent<Spawn>().setBox(boxes[18]);
        BlueSpawn.GetComponent<Spawn>().setBox(boxes[4]);
        boxes[1].GetComponent<Box>().setColor("blue");
        boxes[9].GetComponent<Box>().setColor("blue");
        boxes[15].GetComponent<Box>().setColor("yellow");
        boxes[23].GetComponent<Box>().setColor("yellow");
        boxes[29].GetComponent<Box>().setColor("green");
        boxes[37].GetComponent<Box>().setColor("green");
        boxes[43].GetComponent<Box>().setColor("red");
        boxes[51].GetComponent<Box>().setColor("red");

        RedSpawn = Instantiate(RedSpawn);
        GreenSpawn = Instantiate(GreenSpawn);
        YellowSpawn = Instantiate(YellowSpawn);
        BlueSpawn = Instantiate(BlueSpawn);

        BlueHome = Instantiate(BlueHome);
        RedHome = Instantiate(RedHome);
        GreenHome = Instantiate(GreenHome);
        YellowHome = Instantiate(YellowHome);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        i++;

        //spawns peices
        if (i == 100)
        {
            StartCoroutine(game(1f));
        }
    }

    //wait till dice has been rolled
    private IEnumerator rollDice(string turn)
    {
        //call correct rotation
        switch (turn)
        {
            case "Yellow" : Camera.GetComponent<CameraMovement>().changeCam(1); break;
            case "Blue": Camera.GetComponent<CameraMovement>().changeCam(0); break;
            case "Red": Camera.GetComponent<CameraMovement>().changeCam(3); break;
            case "Green": Camera.GetComponent<CameraMovement>().changeCam(2); break;
        }
        while (Dice.GetComponent<Dice>().getNumFaceUp() == -1)
        {
            yield return new WaitForSeconds(.1f);
        }
        
        diceNum = Dice.GetComponent<Dice>().getNumFaceUp();
        Dice.GetComponent<Dice>().resetNumFaceUp();
    }

    private IEnumerator camBlue()
    {
        Camera.GetComponent<CameraMovement>().changeCam(4);
        yield return new WaitForSeconds(3f);
    }

    private IEnumerator camYellow()
    {
        Camera.GetComponent<CameraMovement>().changeCam(5);
        yield return new WaitForSeconds(3f);
    }

    private IEnumerator camRed()
    {
        Camera.GetComponent<CameraMovement>().changeCam(7);
        yield return new WaitForSeconds(3f);
    }

    private IEnumerator camGreen()
    {
        Camera.GetComponent<CameraMovement>().changeCam(6);
        yield return new WaitForSeconds(3f);
    }

    //run till peice selected or spawned
    private IEnumerator selectPiece(GameObject Spawn, string turn) 
    {
        //can select or spawn a peice
        //only can spawn piece if you rolled a 1 or 2


        yield return new WaitForSeconds(1f);
    }

    //run till move done
    private IEnumerator move(string turn)
    {
        //checks if current block is safezone entry


        /*if (nextBoxIndex >= 56) //make sure index not out of bounds
            nextBoxIndex %= 56;

        //check enter box
        //
        //check box color for slide
        if (!boxes[nextBoxIndex].GetComponent<Box>().getColor().Equals(currentColor) && !boxes[nextBoxIndex].GetComponent<Box>().getColor().Equals("white"))
        {
            boxes[randBoxIndex].GetComponent<Box>().movePiece(boxes[nextBoxIndex]);
            yield return new WaitForSeconds(1f);
            boxes[nextBoxIndex].GetComponent<Box>().movePiece(boxes[nextBoxIndex + 1]);
            yield return new WaitForSeconds(.5f);
            boxes[nextBoxIndex + 1].GetComponent<Box>().movePiece(boxes[nextBoxIndex + 2]);
            yield return new WaitForSeconds(.5f);
            boxes[nextBoxIndex + 2].GetComponent<Box>().movePiece(boxes[nextBoxIndex + 3]);
        }
        else
            boxes[randBoxIndex].GetComponent<Box>().movePiece(boxes[nextBoxIndex]);*/

        return null;
    }

    private IEnumerator game(float waitTime)
    {
        //starts game with random turn
        int turn = Random.Range(0, turns.Count);

        while (true)
        {
            Debug.Log(turns[turn] + "'s turn");
            switch (turns[turn])
            {
                case "Blue": yield return camBlue(); break;
                case "Yellow": yield return camYellow(); break;
                case "Green": yield return camGreen(); break;
                case "Red": yield return camRed(); break;
            }

            Debug.Log("Wait for Dice Roll");
            yield return rollDice(turns[turn]);

            switch (turns[turn])
            {
                case "Blue":

                    //find all gameobject with tag of the turn's color
                        //if none come up you need a 1 or 2 to spawn a piece
                        //if some come up you can either select a piece or spawn a piece
                    Debug.Log("Wait for Piece Select");
                    yield return selectPiece(BlueSpawn, turns[turn]);
                    yield return camBlue();
                    //if not spawned
                        yield return move(turns[turn]);

                    break;

                case "Yellow":

                    //find all gameobject with tag of the turn's color
                        //if none come up you need a 1 or 2 to spawn a piece
                        //if some come up you can either select a piece or spawn a piece
                    Debug.Log("Wait for Piece Select");
                    yield return selectPiece(YellowSpawn, turns[turn]);
                    yield return camYellow();
                    //if not spawned
                        yield return move(turns[turn]);

                    break;

                case "Green":

                    //find all gameobject with tag of the turn's color
                        //if none come up you need a 1 or 2 to spawn a piece
                        //if some come up you can either select a piece or spawn a piece
                    Debug.Log("Wait for Piece Select");
                    yield return selectPiece(GreenSpawn, turns[turn]);
                    yield return camGreen();
                    //if not spawned
                        yield return move(turns[turn]);

                    break;

                case "Red":

                    //find all gameobject with tag of the turn's color
                        //if none come up you need a 1 or 2 to spawn a piece
                        //if some come up you can either select a piece or spawn a piece
                    Debug.Log("Wait for Piece Select");
                    yield return selectPiece(RedSpawn, turns[turn]);
                    //if not spawned
                    yield return camRed();
                        yield return move(turns[turn]);

                    break;
            }

            turn++;
            if (turn == turns.Count)
                turn = 0;
        }
    }
}

/*
 *     yield return new WaitForSeconds(waitTime);

            //list off index all boxes with a piece
            List<int> list = new List<int>();
            foreach (GameObject B in boxes)
            {
                if (B.GetComponent<Box>().hasPiece())
                {
                    list.Add(B.GetComponent<Box>().getIndex());
                }
            }

            //picks random box that has a peice
            int randBoxIndex = list[Random.Range(0, list.Count)];
            string currentColor = boxes[randBoxIndex].GetComponent<Box>().getPieceColor();
            int nextBoxIndex = randBoxIndex + Random.Range(1, 7);
            if (nextBoxIndex >= 56) //make sure index not out of bounds
                nextBoxIndex %= 56;

            //check enter box
            //
            //check box color for slide
            if (!boxes[nextBoxIndex].GetComponent<Box>().getColor().Equals(currentColor) && !boxes[nextBoxIndex].GetComponent<Box>().getColor().Equals("white"))
            {
                boxes[randBoxIndex].GetComponent<Box>().movePiece(boxes[nextBoxIndex]);
                yield return new WaitForSeconds(1f);
                boxes[nextBoxIndex].GetComponent<Box>().movePiece(boxes[nextBoxIndex+1]);
                yield return new WaitForSeconds(.5f);
                boxes[nextBoxIndex+1].GetComponent<Box>().movePiece(boxes[nextBoxIndex+2]);
                yield return new WaitForSeconds(.5f);
                boxes[nextBoxIndex+2].GetComponent<Box>().movePiece(boxes[nextBoxIndex+3]);
            }
            else 
                boxes[randBoxIndex].GetComponent<Box>().movePiece(boxes[nextBoxIndex]);
 */