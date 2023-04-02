using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menu : MonoBehaviour
{


    public void startButton()
    {
        SceneManager.LoadScene("intro_screen");
        PlayerPrefs.SetInt("introMusic", GameObject.Find("Music Manager").GetComponent<AudioSource>().timeSamples);
    }

    public void quitButton()
    {
        Application.Quit();
    }

    public void startScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}

