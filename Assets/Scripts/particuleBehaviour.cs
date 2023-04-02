using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class particuleBehaviour : MonoBehaviour
{
    [SerializeField]
    GameObject destination;
    [SerializeField]
    float particuleSpeed;
    [SerializeField]
    float distanceMiniArret;
    [SerializeField]
    float distanceMiniChangementDirection;
    bool isFrapped;

    /*[SerializeField]
    GameObject destinationImpact;*/
    [SerializeField]
    float speedChuteParticle;
    [SerializeField]
    bool isFalling;

    [SerializeField]
    GameObject yurE;

    private int compteurDestination;

    // Start is called before the first frame update
    void Start()
    {
        compteurDestination = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = GameObject.FindWithTag("destinationImpact").transform.position - transform.position;
        float angle = -90 + Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (isFalling)
        {
            float distanceBeforeDestination = Vector2.Distance(this.transform.position, GameObject.FindWithTag("destinationImpact").transform.position);
            if (distanceBeforeDestination >= this.distanceMiniArret)
            {
                //Debug.Log("La particule de merde est à " + distanceBeforeDestination + " distance, elle change de direction en arrivant à " + this.distanceMiniChangementDirection);
                this.transform.position = Vector2.Lerp(this.transform.position, GameObject.FindWithTag("destinationImpact").transform.position, Time.deltaTime * this.speedChuteParticle);
            }
        }
    }

    private void FixedUpdate()
    {
        if (isFrapped)
        {
            isFalling = false;
            float distance = Vector2.Distance(this.transform.position, destination.transform.position);
            if (distance > this.distanceMiniArret)
            {
                this.transform.position = Vector2.Lerp(this.transform.position, destination.transform.position, Time.deltaTime * this.particuleSpeed);
            }
        }
    }

    public void particuleFrappee()
    {
        isFrapped = true;
    }

    public void setIsFalling(bool fall)
    {
        this.isFalling = fall; 
    }
}
