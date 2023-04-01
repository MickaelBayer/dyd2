using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Network : MonoBehaviour
{

    public Neurone[] neurones;
    // Start is called before the first frame update
    void Start()
    {
        this.neurones = this.GetComponentsInChildren<Neurone>();
        for (int i = 0; i < neurones.GetLength(0); i++)
        {
            Debug.Log("In Network : " + neurones[i].name);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnChildClick()
    {
        // save the state
        // play the scene
        Debug.Log("Parent on child click");

        foreach (Neurone neurone in this.neurones)
        {
            Debug.Log(neurone.name + " - " + neurone.levelValue);
            // TODO: Decide if the neurone should be known
            PlayerPrefs.SetInt(this.name + "_isKnown", neurone.isKnown ? 1 : 0);
            PlayerPrefs.SetInt(this.name + "_levelValue", neurone.levelValue ? 1 : 0);
        }
    }
}
