using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class head : MonoBehaviour
{
    [SerializeField] private Sprite idleHead, happyHead;
    private enum possibleState { idle, happy };
    private possibleState headState;

    // Start is called before the first frame update
    void Start()
    {
        headState = possibleState.idle;
    }

    // Update is called once per frame
    void fixedUpdate()
    {
        switch(headState)
        {
            case possibleState.idle:
                this.GetComponent<SpriteRenderer>().sprite = idleHead;
                break;
            case possibleState.happy:
                this.GetComponent<SpriteRenderer>().sprite = happyHead;
                break;
        }
    }
}
