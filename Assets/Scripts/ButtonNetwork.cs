using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonNetwork : MonoBehaviour
{
    [SerializeField] private string nextScene;
    Network networkScript;
    // Start is called before the first frame update
    void Start()
    {
        networkScript = GameObject.Find("Network").GetComponent<Network>();

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
        networkScript.OnChildClick(nextScene);
    }
}
