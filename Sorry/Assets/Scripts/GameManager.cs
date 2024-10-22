using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using Random = UnityEngine.Random;


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
    GameObject[] boxesBlue;
    GameObject[] boxesRed;
    GameObject[] boxesGreen;
    GameObject[] boxesYellow;


    List<string> turns;
    int i = 0;
    int diceNum;
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
        boxes[1].GetComponent<Box>().setColor("Blue");
        boxes[9].GetComponent<Box>().setColor("Blue");
        boxes[15].GetComponent<Box>().setColor("Yellow");
        boxes[23].GetComponent<Box>().setColor("Yellow");
        boxes[29].GetComponent<Box>().setColor("Green");
        boxes[37].GetComponent<Box>().setColor("Green");
        boxes[43].GetComponent<Box>().setColor("Red");
        boxes[51].GetComponent<Box>().setColor("Red");

        boxesBlue = new GameObject[6];
        boxesRed = new GameObject[6];
        boxesGreen = new GameObject[6];
        boxesYellow = new GameObject[6];
        for (int i = 56; i < 62; i++)
        {
            boxesBlue[i - 56] = Instantiate(Box, new Vector3(2.25f + (1.3f * (i-56)), 0, 2.5f), Quaternion.identity);
            boxesBlue[i - 56].GetComponent<Box>().setIndex(i);
            boxesBlue[i - 56].GetComponent<Box>().setColor("Blue");

            boxesRed[i - 56] = Instantiate(Box, new Vector3(14.75f, 0, 2.3f + ((i - 56) * 1.3f)), Quaternion.identity);
            boxesRed[i - 56].GetComponent<Box>().setIndex(i);
            boxesRed[i - 56].GetComponent<Box>().setColor("Red");

            boxesGreen[i - 56] = Instantiate(Box, new Vector3(15 - (1.25f * (i - 56)), 0, 14.75f), Quaternion.identity);
            boxesGreen[i - 56].GetComponent<Box>().setIndex(i);
            boxesGreen[i - 56].GetComponent<Box>().setColor("Green");

            boxesYellow[i - 56] = Instantiate(Box, new Vector3(2.4f, 0 , 15 - (1.25f * (i - 56))), Quaternion.identity);
            boxesYellow[i - 56].GetComponent<Box>().setIndex(i);
            boxesYellow[i - 56].GetComponent<Box>().setColor("Yellow");
        }

        RedSpawn = Instantiate(RedSpawn);
        GreenSpawn = Instantiate(GreenSpawn);
        YellowSpawn = Instantiate(YellowSpawn);
        BlueSpawn = Instantiate(BlueSpawn);

        BlueHome = Instantiate(BlueHome);
        RedHome = Instantiate(RedHome);
        GreenHome = Instantiate(GreenHome);
        YellowHome = Instantiate(YellowHome);
    }

    bool getWin()
    {
        return BlueHome.GetComponent<Home>().won() || RedHome.GetComponent<Home>().won() || GreenHome.GetComponent<Home>().won() || YellowHome.GetComponent<Home>().won(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        i++;

        //spawns peices
        if (i == 100)
        {
            StartCoroutine(game());
        }
    }

    private IEnumerator rollDice(string turn)
    {
        Dice.GetComponent<Dice>().setDisable(false);
        Dice.GetComponent<Dice>().resetNumFaceUp();

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
        Dice.GetComponent<Dice>().setDisable(true);
    }

    private IEnumerator camBlue()
    {
        Camera.GetComponent<CameraMovement>().changeCam(4);
        yield return new WaitForSeconds(2f);
    }

    private IEnumerator camYellow()
    {
        Camera.GetComponent<CameraMovement>().changeCam(5);
        yield return new WaitForSeconds(2f);
    }

    private IEnumerator camRed()
    {
        Camera.GetComponent<CameraMovement>().changeCam(7);
        yield return new WaitForSeconds(2f);
    }

    private IEnumerator camGreen()
    {
        Camera.GetComponent<CameraMovement>().changeCam(6);
        yield return new WaitForSeconds(2f);
    }

    private IEnumerator selectPiece(string turn) 
    {
        List<GameObject> validPieces = new List<GameObject>();

        foreach (GameObject g in GameObject.FindGameObjectsWithTag(turn))
        {
            int index = g.GetComponent<Piece>().getIndex();

            //not spawnable
            if (index == -1 && diceNum >= 3)
                continue;

            //in safe zone
            if (index > 55)
            {
                nextBox = index + diceNum;
                if (nextBox > 61)
                    continue;

                switch (turn) 
                {
                    case "Blue":
                        if (boxesBlue[nextBox-56].GetComponent<Box>().hasPiece())
                            continue;
                        break;
                    case "Yellow":
                        if (boxesYellow[nextBox - 56].GetComponent<Box>().hasPiece())
                            continue;
                        break;
                    case "Green":
                        if (boxesGreen[nextBox - 56].GetComponent<Box>().hasPiece())
                            continue;
                        break;
                    case "Red":
                        if (boxesRed[nextBox - 56].GetComponent<Box>().hasPiece())
                            continue;
                        break;
                }
            }

            //in play
            if (index != -1 && index < 56)
            {
                nextBox = index + diceNum;
                if (nextBox >= 56)
                    nextBox %= 56;

                switch (turn)
                {
                    case "Blue":
                        //if going into safety zone
                        if (nextBox > 2 && (index <= 2 || index >= 53))
                        {
                            if (boxesBlue[nextBox - 3].GetComponent<Box>().hasPiece())
                                continue;
                        }
                        else if (boxes[nextBox].GetComponent<Box>().getPieceColor() == turn)
                            continue;
                        break;

                    case "Yellow":
                        //if going into safety zone
                        if (nextBox > 16 && (index <= 16  && index >= 11))
                        {
                            if (boxesYellow[nextBox - 17].GetComponent<Box>().hasPiece())
                                continue;
                        }
                        else if (boxes[nextBox].GetComponent<Box>().getPieceColor() == turn)
                            continue;
                        break;
                    case "Green":
                        //if going into safety zone
                        if (nextBox > 30 && (index <= 30 && index >= 25))
                        {
                            if (boxesGreen[nextBox - 31].GetComponent<Box>().hasPiece())
                                continue;
                        }
                        else if (boxes[nextBox].GetComponent<Box>().getPieceColor() == turn)
                            continue;
                        break;
                    case "Red":
                        //if going into safety zone
                        if (nextBox > 44 && (index <= 44 && index >= 39))
                        {
                            if (boxesRed[nextBox - 45].GetComponent<Box>().hasPiece())
                                continue;
                        }
                        else if (boxes[nextBox].GetComponent<Box>().getPieceColor() == turn)
                            continue;
                        break;
                }
            }

            validPieces.Add(g);
        }

        if (validPieces.Count == 0)
        {
            currentBox = -2;
            yield break;
        }

        Debug.Log("Waiting for Piece Select");
        while (true)
        {
            yield return new WaitForSeconds(.1f);
            if (Input.GetMouseButton(0))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100))
                {
                    Debug.Log(hit.collider.tag);

                    if (hit.collider.tag == turn)
                    {
                        if (validPieces.Contains(hit.collider.gameObject))
                        {
                            currentBox = hit.collider.gameObject.GetComponent<Piece>().getIndex();
                            nextBox = currentBox + diceNum;

                            if (currentBox < 56) 
                                if (nextBox >= 56)
                                    nextBox %= 56;

                            break;
                        }
                    }
                }
            }
        }
    }

    private IEnumerator move(string turn)
    {       
            switch (turn) 
            {
                case "Blue":

                    //in safety zone
                    if (currentBox > 55)
                    {
                        boxesBlue[currentBox-56].GetComponent<Box>().movePiece(boxesBlue[nextBox-56]);
                        yield return new WaitForSeconds(1f);
                    }
                    // about to enter safety zone
                    else if (nextBox > 2 && (currentBox <= 2 || currentBox >= 53))
                    {
                        //corner cuts
                        boxes[currentBox].GetComponent<Box>().movePiece(boxesBlue[nextBox-3]);
                        yield return new WaitForSeconds(1f);
                    }
                    //going to enter slide piece
                    else if (!boxes[nextBox].GetComponent<Box>().getColor().Equals(turn) && !boxes[nextBox].GetComponent<Box>().getColor().Equals("white"))
                    {
                        boxes[currentBox].GetComponent<Box>().movePiece(boxes[nextBox]);
                        yield return new WaitForSeconds(1f);
                        boxes[nextBox].GetComponent<Box>().movePiece(boxes[nextBox + 1]);
                        yield return new WaitForSeconds(.5f);
                        boxes[nextBox + 1].GetComponent<Box>().movePiece(boxes[nextBox + 2]);
                        yield return new WaitForSeconds(.5f);
                        boxes[nextBox + 2].GetComponent<Box>().movePiece(boxes[nextBox + 3]);
                    }
                    //regular 
                    else
                    {
                        boxes[currentBox].GetComponent<Box>().movePiece(boxes[nextBox]);
                        yield return new WaitForSeconds(1f);
                    }
                    
                    break;

                case "Red":

                    //in safety zone
                    if (currentBox > 55)
                    {
                        boxesRed[currentBox - 56].GetComponent<Box>().movePiece(boxesRed[nextBox - 56]);
                        yield return new WaitForSeconds(1f);
                    }
                    // about to enter safety zone
                    else if (nextBox > 44 && (currentBox <= 44 && currentBox >= 39))
                    {
                    //corner cuts
                        boxes[currentBox].GetComponent<Box>().movePiece(boxesRed[nextBox - 45]);
                        yield return new WaitForSeconds(1f);
                    }
                    //going to enter slide piece
                    else if (!boxes[nextBox].GetComponent<Box>().getColor().Equals(turn) && !boxes[nextBox].GetComponent<Box>().getColor().Equals("white"))
                    {
                        boxes[currentBox].GetComponent<Box>().movePiece(boxes[nextBox]);
                        yield return new WaitForSeconds(1f);
                        boxes[nextBox].GetComponent<Box>().movePiece(boxes[nextBox + 1]);
                        yield return new WaitForSeconds(.5f);
                        boxes[nextBox + 1].GetComponent<Box>().movePiece(boxes[nextBox + 2]);
                        yield return new WaitForSeconds(.5f);
                        boxes[nextBox + 2].GetComponent<Box>().movePiece(boxes[nextBox + 3]);
                    }
                    //regular 
                    else
                    {
                        boxes[currentBox].GetComponent<Box>().movePiece(boxes[nextBox]);
                        yield return new WaitForSeconds(1f);
                    }

                break;

                case "Green":
          
                    if (currentBox > 55)
                    {
                        boxesGreen[currentBox - 56].GetComponent<Box>().movePiece(boxesGreen[nextBox - 56]);
                        yield return new WaitForSeconds(1f);
                    }
                    // about to enter safety zone
                    else if (nextBox > 30 && (currentBox <= 30 && currentBox >= 25))
                    {
                        //corner cuts
                        boxes[currentBox].GetComponent<Box>().movePiece(boxesGreen[nextBox - 31]);
                        yield return new WaitForSeconds(1f);
                    }
                    //going to enter slide piece
                    else if (!boxes[nextBox].GetComponent<Box>().getColor().Equals(turn) && !boxes[nextBox].GetComponent<Box>().getColor().Equals("white"))
                    {
                        boxes[currentBox].GetComponent<Box>().movePiece(boxes[nextBox]);
                        yield return new WaitForSeconds(1f);
                        boxes[nextBox].GetComponent<Box>().movePiece(boxes[nextBox + 1]);
                        yield return new WaitForSeconds(.5f);
                        boxes[nextBox + 1].GetComponent<Box>().movePiece(boxes[nextBox + 2]);
                        yield return new WaitForSeconds(.5f);
                        boxes[nextBox + 2].GetComponent<Box>().movePiece(boxes[nextBox + 3]);
                    }
                    //regular 
                    else
                    {
                        boxes[currentBox].GetComponent<Box>().movePiece(boxes[nextBox]);
                        yield return new WaitForSeconds(1f);
                    }

                break;

            case "Yellow":

                if (currentBox > 55)
                {
                    boxesYellow[currentBox - 56].GetComponent<Box>().movePiece(boxesYellow[nextBox - 56]);
                    yield return new WaitForSeconds(1f);
                }
                // about to enter safety zone
                else if (nextBox > 16 && (currentBox <= 16  && currentBox >= 11))
                {
                    //corner cuts
                    boxes[currentBox].GetComponent<Box>().movePiece(boxesYellow[nextBox - 17]);
                    yield return new WaitForSeconds(1f);
                }
                //going to enter slide piece
                else if (!boxes[nextBox].GetComponent<Box>().getColor().Equals(turn) && !boxes[nextBox].GetComponent<Box>().getColor().Equals("white"))
                {
                    boxes[currentBox].GetComponent<Box>().movePiece(boxes[nextBox]);
                    yield return new WaitForSeconds(1f);
                    boxes[nextBox].GetComponent<Box>().movePiece(boxes[nextBox + 1]);
                    yield return new WaitForSeconds(.5f);
                    boxes[nextBox + 1].GetComponent<Box>().movePiece(boxes[nextBox + 2]);
                    yield return new WaitForSeconds(.5f);
                    boxes[nextBox + 2].GetComponent<Box>().movePiece(boxes[nextBox + 3]);
                }
                //regular 
                else
                {
                    boxes[currentBox].GetComponent<Box>().movePiece(boxes[nextBox]);
                    yield return new WaitForSeconds(1f);
                }
                
                break;
            }
    }

    private IEnumerator game()
    {
        //starts game with random turn
        int turn = Random.Range(0, turns.Count);

        while (!getWin())
        {
            Debug.Log(turns[turn] + "'s turn");
            switch (turns[turn])
            {
                case "Blue": 
                    yield return camBlue();
                    pointLight.GetComponent<Light>().color = new Color32(205, 222, 247, 100);
                    break;

                case "Yellow": 
                    yield return camYellow();
                    pointLight.GetComponent<Light>().color = new Color32(247, 247, 228, 100);
                    break;

                case "Green": 
                    yield return camGreen();
                    pointLight.GetComponent<Light>().color = new Color32(210, 250, 222, 100);
                    break;

                case "Red": 
                    yield return camRed();
                    pointLight.GetComponent<Light>().color = new Color32(255, 198, 194, 100);
                    break;
            }

            Debug.Log("Waiting for Dice Roll");
            yield return rollDice(turns[turn]);

            switch (turns[turn])
            {
                case "Blue":

                    yield return selectPiece(turns[turn]);
                    yield return camBlue();
                    Debug.Log(currentBox);
                    if (currentBox == -1)
                        BlueSpawn.GetComponent<Spawn>().spawnPiece();
                    else if (currentBox != -2)
                        yield return move(turns[turn]);

                    break;

                case "Yellow":

                    yield return selectPiece(turns[turn]);
                    yield return camYellow();
                    Debug.Log(currentBox);
                    if (currentBox == -1)
                        YellowSpawn.GetComponent<Spawn>().spawnPiece();
                    else if (currentBox != -2)
                        yield return move(turns[turn]);

                    break;

                case "Green":

                    yield return selectPiece(turns[turn]);
                    yield return camGreen();
                    Debug.Log(currentBox);
                    if (currentBox == -1)
                        GreenSpawn.GetComponent<Spawn>().spawnPiece();
                    else if (currentBox != -2)
                        yield return move(turns[turn]);

                    break;

                case "Red":

                    yield return selectPiece(turns[turn]);
                    yield return camRed();
                    Debug.Log(currentBox);
                    if (currentBox == -1)
                        RedSpawn.GetComponent<Spawn>().spawnPiece();
                    else if (currentBox != -2)
                        yield return move(turns[turn]);

                    break;
            }

            turn++;
            if (turn == turns.Count)
                turn = 0;
        }

        if (BlueHome.GetComponent<Home>().won())
            Debug.Log("Blue Won!");

        if (RedHome.GetComponent<Home>().won())
            Debug.Log("Red Won!");
        
        if (GreenHome.GetComponent<Home>().won())
            Debug.Log("Green Won!");
        
        if (YellowHome.GetComponent<Home>().won())
            Debug.Log("Yellow Won!");
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