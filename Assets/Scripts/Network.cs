using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Network : MonoBehaviour
{
    public int activatedNeurons;

    // Neurone order :
    // - 0 : calm
    // - 1 : angry
    // - 2 : smart
    // - 3 : 
    // - 4 :
    // - 5 :
    // - 6 :
    // - 7 :
    // - 8 :
    // - 9:
    // - 10:
    // - 11:
    // - 12:
    public Neurone[] neurones;
    void Awake()
    {
        this.neurones = this.GetComponentsInChildren<Neurone>();
        for (int i = 0; i < neurones.Length; i++)
        {
            if (i < this.activatedNeurons-1)
            {
                neurones[i].isActive = true;
                neurones[i].isKnown = PlayerPrefs.GetInt(neurones[i].name + "_isKnown") != 0;
                if (neurones[i].isKnown)
                {
                    switch (i)
                    {
                        case 0:
                            neurones[i].initColor = new Color(1f, 1f, 0f, .5f);
                            break;
                        case 1:
                            neurones[i].initColor = new Color(1f, 0f, 0f, .5f);
                            break;
                        case 2:
                            neurones[i].initColor = new Color(0f, 0f, 1f, .5f);
                            break;
                        case 3:
                            neurones[i].initColor = new Color(1f, 0f, 0f, .5f);
                            break;
                        default:
                            neurones[i].initColor = neurones[i].neutral;
                            break;
                    }
                }
                else
                {
                    neurones[i].initColor = neurones[i].neutral;
                }
            }
            else
            {
                neurones[i].initColor = Color.gray;
            }
        }
    }

    public void OnChildClick(string scene)
    {
        // save the state
        // play the scene
        bool infoGiven = false;
        foreach (Neurone neurone in this.neurones)
        {
            // Decide if the neurone should be known
            if (!neurone.isKnown && !infoGiven && neurone.levelValue)
            {
                neurone.isKnown = true;
                infoGiven = true;
            }
            PlayerPrefs.SetInt(neurone.name + "_isKnown", neurone.isKnown ? 1 : 0);
            PlayerPrefs.SetInt(neurone.name + "_levelValue", neurone.levelValue ? 1 : 0);
        }
        PlayerPrefs.SetInt("ingameMusic", GameObject.Find("Music Manager").GetComponent<AudioSource>().timeSamples);
        SceneManager.LoadScene(scene);
    }
}
