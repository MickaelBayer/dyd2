using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neurone : MonoBehaviour
{
    // neurone state for the game 
    public bool isKnown = false;
    // neurone state for the level
    public bool levelValue = false;
    // is the neurone active for a level
    public bool isActive = false;

    // sprite renderer attached
    private SpriteRenderer m_SpriteRenderer;

    // coroutine availability
    private bool coroutineAllowed = false;

    public Network parent;

    private Color neutral = new Color(1f, 1f, 1f, .5f);
    private Color selected = new Color(0f, 1f, 1f, .5f);

    void Start()
    {
        this.parent = this.GetComponentInParent<Network>();
        // setup background image
        this.m_SpriteRenderer = this.GetComponent<SpriteRenderer>();
        //Set the GameObject's Color quickly to a set Color
        if (this.isActive)
        {
            Debug.Log("In neurone : " + this.name);
            this.m_SpriteRenderer.color = neutral;
            // allow coroutine
            this.coroutineAllowed = true;
        }
        else
        {
            this.m_SpriteRenderer.color = Color.gray;
        }
        // setup states through player pref
        this.isKnown = PlayerPrefs.GetInt(this.name + "_isKnown") != 0;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        if (this.isActive)
        {
            // change the level state
            this.levelValue = !levelValue;
            this.m_SpriteRenderer.color = this.levelValue ? selected : neutral;
            Debug.Log("click " + this.name);
        }
    }

    void OnMouseOver()
    {
        if (this.coroutineAllowed)
        {
            this.StartCoroutine("StartPulsing");
        }
    }

    /**
    * Pulsing routine
    */
    private IEnumerator StartPulsing()
    {
        this.coroutineAllowed = false;
        for (float i = 0f; i <= 1f; i += 0.1f)
        {
            this.transform.localScale = new Vector2(
                (Mathf.Lerp(transform.localScale.x, transform.localScale.x + 0.025f, Mathf.SmoothStep(0f, 1f, i))),
                (Mathf.Lerp(transform.localScale.y, transform.localScale.y + 0.025f, Mathf.SmoothStep(0f, 1f, i)))
            );
            yield return new WaitForSeconds(0.015f);
        }

        for (float i = 0f; i <= 1f; i += 0.1f)
        {
            this.transform.localScale = new Vector2(
                (Mathf.Lerp(transform.localScale.x, transform.localScale.x - 0.025f, Mathf.SmoothStep(0f, 1f, i))),
                (Mathf.Lerp(transform.localScale.y, transform.localScale.y - 0.025f, Mathf.SmoothStep(0f, 1f, i)))
            );
            yield return new WaitForSeconds(0.015f);
        }
        this.coroutineAllowed = true;
    }

}
