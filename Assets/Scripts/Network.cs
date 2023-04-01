using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Network : MonoBehaviour
{
    public int level;

    // Neurone order :
    // - 1 : calm
    // - 2 : angry
    // - 3 : smart
    // - 4 : 
    // - 5 :
    // - 6 :
    // - 7 :
    // - 8 :
    // - 9 :
    // - 10:
    // - 11:
    // - 12:
    // - 13:
    public Neurone[] neurones;
    void Awake()
    {
        this.neurones = this.GetComponentsInChildren<Neurone>();
        for (int i = 0; i < neurones.Length; i++)
        {
            if (i < 3 * this.level)
            {
                neurones[i].isActive = true;
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
    }
}
