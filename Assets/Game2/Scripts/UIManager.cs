﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //UI
    public Slider sliderPlayers;
    public Text textPlayers;
    public GameObject sliderGO;
    public GameObject inputGO;
    public Text textNames;
    public Text listPlayers;

    //GameManager
    public GameObject gameManager;
    GameSystem GSScript;

    //state counter
    int counter = 0;

    //Misc
    private bool quantPlayersSelected = false;
    MyPlayersInfo[] playersArray;
    public static UIManager instance = null;


    private void Awake()
    {
        if (instance == null)

            instance = this;

        else if (instance != this)

            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        GSScript = gameManager.GetComponent<GameSystem>();
    }


    public void ButtonPressed()
    {
        if (!quantPlayersSelected)
        {
            playersArray = new MyPlayersInfo[(int)sliderPlayers.value];
            sliderGO.SetActive(false);
            inputGO.SetActive(true);
            listPlayers.text = "Players list:";
            quantPlayersSelected = true;
        }
        else
        {
            if (counter < playersArray.Length)
            {
                playersArray[counter] = new MyPlayersInfo(counter, textNames.text, 0);
                print("Counter: " + counter + ".   ArrayL: " + playersArray.Length);
                listPlayers.text += "\n\t -" + playersArray[counter].playerName;
                textNames.text = "";
                counter++;
            }
            else
            {
                GSScript.StartGame(playersArray);
            }
        }
    }

    void Update()
    {
        textPlayers.text = sliderPlayers.value.ToString();
    }
}
