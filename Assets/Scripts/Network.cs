using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Network : MonoBehaviour
{
    public int level;

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
            if (i < 3 * this.level)
            {
                neurones[i].isActive = true;
                if (i == 2)
                {
                    PlayerPrefs.SetInt(neurones[i].name + "_isKnown", 1);
                }
                neurones[i].isKnown = PlayerPrefs.GetInt(neurones[i].name + "_isKnown") != 0;
                Debug.Log(neurones[i].name + "_isKnown = " + PlayerPrefs.GetInt(neurones[i].name + "_isKnown"));
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

    public void OnChildClick()
    {
        // save the state
        // play the scene
        Debug.Log("Parent on child click");

        foreach (Neurone neurone in this.neurones)
        {
            Debug.Log(neurone.name + " - " + neurone.levelValue);
            // Decide if the neurone should be known
            PlayerPrefs.SetInt(this.name + "_isKnown", neurone.isKnown ? 1 : 0);
            PlayerPrefs.SetInt(this.name + "_levelValue", neurone.levelValue ? 1 : 0);
        }
        SceneManager.LoadScene("animationMachine");
    }
}
