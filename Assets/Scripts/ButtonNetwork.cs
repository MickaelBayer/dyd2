using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonNetwork : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        // validate the current neurone selection.
        // play the scene
        Debug.Log("Click Validate");
        GetComponentInParent<Network>().OnChildClick();
    }
}
