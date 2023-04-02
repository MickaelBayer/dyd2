using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menu : MonoBehaviour
{

    [SerializeField]
    GameObject bulle;

    void Start()
    {
        bulle.SetActive(false);
    }
    public void startButton()
    {
        PlayerPrefs.SetInt("introMusic", GameObject.Find("Music Manager").GetComponent<AudioSource>().timeSamples);
        SceneManager.LoadScene("intro_screen");
    }

    public void quitButton()
    {
        Application.Quit();
    }

    public void resetButton()
    {
        PlayerPrefs.DeleteAll();
        bulle.SetActive(true);
    }

    public void startSceneWithMusic(string sceneName)
    {
        if (sceneName != "level1_setup")
        {
            PlayerPrefs.SetInt("ingameMusic", GameObject.Find("Music Manager").GetComponent<AudioSource>().timeSamples);
        }
        SceneManager.LoadScene(sceneName);
    }

    public void firstStartScene(string sceneName)
    {

        PlayerPrefs.SetInt("ingameMusic", 0);

        SceneManager.LoadScene(sceneName);
    }

}

