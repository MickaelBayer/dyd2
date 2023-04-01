using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outil_behaviour : MonoBehaviour
{
    private bool frapping;
    private bool elanting;
    [SerializeField]
    float distanceMiniElan;
    [SerializeField]
    float distanceMiniArret;
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
            float distanceElan = Vector2.Distance(this.transform.position, new Vector2(this.positionOrigine.x - 5.0f, this.positionOrigine.y));
            Debug.Log("Parapluie est a " + distanceElan + "de sa position initiale");
            if (distanceElan > this.distanceMiniElan)
            {
                this.transform.position = Vector2.Lerp(this.transform.position, new Vector3(this.positionOrigine.x - 5.0f, this.positionOrigine.y, this.positionOrigine.z), Time.deltaTime * this.speedElan);
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
                GameObject.FindWithTag("incident").GetComponent<particuleBehaviour>().particuleFrappee();
            }
        }
    }
}
