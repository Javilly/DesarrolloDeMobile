using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    string sceneToLoad;
    public static SceneChanger instance = null;
    public Slider UISlider;


    private void Start()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            sceneToLoad = "Scene1";
            LoadScene(sceneToLoad);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            sceneToLoad = "Scene2";
            LoadScene(sceneToLoad);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            sceneToLoad = "Scene3";
            LoadScene(sceneToLoad);
        }
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine("AScene");
    }

    IEnumerator AScene()
    {
        AsyncOperation loadingProgress = SceneManager.LoadSceneAsync("Scenes/Scene2");

        while (!loadingProgress.isDone)
        {
            UISlider.value = loadingProgress.progress;
            print("Progress: " + loadingProgress.progress);
            yield return null;
        }
    }
}
