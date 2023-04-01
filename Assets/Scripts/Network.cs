using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Network : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MonoBehaviour[] childs = this.GetComponentsInChildren<MonoBehaviour>();
        for (int i = 0; i < childs.GetLength(0); i++)
        {
            Debug.Log("In Network : " + childs[i].name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // check click on neurones
        // set the correct state of neurones

        // check validation from player
        // save player refs
        // play the puzzle scene

    }
}
