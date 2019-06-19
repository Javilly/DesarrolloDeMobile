using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{
    //SceneManager
    string sceneToLoad;
    public Slider UISlider;


    int actualTurn;
    int ballsCounter;
    public MyPlayersInfo[] playersArray;


    public static GameSystem instance = null;

    public bool gameStarted = false;


    private void Awake()
    {
        if (instance == null)

            instance = this;

        else if (instance != this)

            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        sceneToLoad = "Scene1";

        //playersArray = new MyPlayersInfo[playersQuant];
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene("LoadingScene", LoadSceneMode.Additive);
        StartCoroutine(AScene(sceneName));
    }

    IEnumerator AScene(string sceneToLoad)
    {
        AsyncOperation loadingProgress = SceneManager.LoadSceneAsync(sceneToLoad);

        while (!loadingProgress.isDone)
        {
            //UISlider.value = loadingProgress.progress;
            print("Progress: " + loadingProgress.progress);
            yield return null;
        }
    }
    
    public void StartGame(MyPlayersInfo[] arrayPasada)
    {
        LoadScene(sceneToLoad);
        playersArray = arrayPasada;
        gameStarted = true;
        actualTurn = 0;
        ballsCounter = 0;
    }

    public void StickPicked()
    {

    }

    public void PassTurn()
    {
        playersArray[actualTurn].playerPoints = ballsCounter;
        ballsCounter = 0;
        actualTurn++;
    }

    void Update()
    {
        if (gameStarted)
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
    public MyPlayersInfo(int plPos, string plName, int plPoints)
    {
        playerPosition = plPos;
        playerName = plName;
        playerPoints = plPoints;
    }
}