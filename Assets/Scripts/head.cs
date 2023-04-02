using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class head : MonoBehaviour
{
    [SerializeField] private Sprite idleHead, happyHead, angryHead, sleepyHead, worryHead;
    private enum possibleState { idle, happy, sleepy, angry, worry };
    private possibleState headState;

    // Start is called before the first frame update
    void Start()
    {
        headState = possibleState.idle;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch(headState)
        {
            case possibleState.idle:
                this.GetComponent<SpriteRenderer>().sprite = idleHead;
                break;
            case possibleState.happy:
                this.GetComponent<SpriteRenderer>().sprite = happyHead;
                break;
            case possibleState.angry:
                this.GetComponent<SpriteRenderer>().sprite = angryHead;
                break;
            case possibleState.sleepy:
                this.GetComponent<SpriteRenderer>().sprite = sleepyHead;
                break;
            case possibleState.worry:
                this.GetComponent<SpriteRenderer>().sprite = worryHead;
                break;
        }
    }

    public void changeHeadState(string headState)
    {
        switch (headState)
        {
            case "idle":
                this.headState = possibleState.idle;
                break;
            case "happy":
                this.headState = possibleState.happy;
                break;
            case "angry":
                this.headState = possibleState.angry;
                break;
            case "sleepy":
                this.headState = possibleState.sleepy;
                break;
            case "worry":
                this.headState = possibleState.worry;
                break;
        }
    }
}
