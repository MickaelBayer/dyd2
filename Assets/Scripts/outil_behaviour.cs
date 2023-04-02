using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outil_behaviour : MonoBehaviour
{
    public bool frapping;
    public bool elanting;
    private bool protection;
    [SerializeField]
    float distanceMiniElan;
    [SerializeField]
    float distanceMiniArret;
    [SerializeField]
    float distanceMiniProtection;
    [SerializeField]
    float speedFrappe;
    [SerializeField]
    float speedElan;

    Vector3 positionOrigine;
    // Start is called before the first frame update

    public void frapper()
    {
        this.elanting = true;
    }
    public void proteger()
    {
        this.protection = true;
    }
    void Start()
    {
        positionOrigine = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (elanting)
        {
            float distanceElan = Vector2.Distance(this.transform.position, new Vector2(this.positionOrigine.x, this.positionOrigine.y+5.0f));
            //Debug.Log("Parapluie est a " + distanceElan + "de sa position initiale");
            if (distanceElan > this.distanceMiniElan)
            {
                this.transform.position = Vector2.Lerp(this.transform.position, new Vector3(this.positionOrigine.x, this.positionOrigine.y + 5.0f, this.positionOrigine.z), Time.deltaTime * this.speedElan);
            }
            else
            {
                this.elanting = false;
                this.frapping = true;
            }
        }
        if (frapping) { 
            float distance = Vector2.Distance(this.transform.position, GameObject.FindWithTag("incident").transform.position);
            if (distance > this.distanceMiniArret)
            {
                this.transform.position = Vector2.Lerp(this.transform.position, GameObject.FindWithTag("incident").transform.position, Time.deltaTime * this.speedFrappe);
            }
            else
            {
                this.frapping = false;
                Debug.Log("UECHE");
                try
                {
                    GameObject.FindWithTag("incident").GetComponent<particuleBehaviour>().particuleFrappee();
                }
                catch(System.Exception e)
                {
                    Debug.Log(e);
                }
            }
        }
        if (protection)
        {
            float distance = Vector2.Distance(this.transform.position, GameObject.FindWithTag("destinationImpact").transform.position);
            if (distance > this.distanceMiniProtection)
            {
                this.transform.position = Vector2.Lerp(this.transform.position, GameObject.FindWithTag("destinationImpact").transform.position, Time.deltaTime * this.speedElan);
            }
            else
            {
                this.protection = false;
                GameObject.FindWithTag("incident").GetComponent<particuleBehaviour>().particuleFrappee();
            }
        }
    }
}
