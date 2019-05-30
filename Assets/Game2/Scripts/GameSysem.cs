using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSysem : MonoBehaviour
{

    static int playersQuant = 2;

    MyPlayersInfo[] playersArray = new MyPlayersInfo[playersQuant];

    bool turnPassed = false;


    void Start()
    {
        playersArray[1].playerPosition = 0;
        playersArray[1].playerName = "Chapi";
        playersArray[1].playerPoints = 0;

        playersArray[2].playerPosition = 1;
        playersArray[2].playerName = "Bota";
        playersArray[2].playerPoints = 0;
    }


    void EndTurn()
    {
        
    }


    void Update()
    {
        if (turnPassed)
        {

        }
    }
}


public class MyPlayersInfo
{
    //define all of the values for the class
    public int playerPosition;
    public string playerName;
    public int playerPoints;

    //define a constructor for the class
    public MyPlayersInfo()
    {

    }
}