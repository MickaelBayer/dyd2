using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class particleBehaviorSetup : MonoBehaviour
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
    GameObject[] destinationsBeforeImpact;
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
        Vector3 dir = destinationsBeforeImpact[compteurDestination].transform.position - transform.position;
        float angle = -90 + Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (isFalling)
        {
            float distanceBeforeDestination = Vector2.Distance(this.transform.position, destinationsBeforeImpact[compteurDestination].transform.position);
            if (distanceBeforeDestination >= this.distanceMiniChangementDirection)
            {
                Debug.Log("La particule de merde est à " + distanceBeforeDestination + " distance, elle change de direction en arrivant à " + this.distanceMiniChangementDirection);
                this.transform.position = Vector2.Lerp(this.transform.position, destinationsBeforeImpact[compteurDestination].transform.position, Time.deltaTime * this.speedChuteParticle);
            }
            else
            {
                if (compteurDestination < destinationsBeforeImpact.Length - 1)
                {
                    compteurDestination++;
                    if (compteurDestination == destinationsBeforeImpact.Length - 1)
                    {
                        compteurDestination = 0;
                    }
                }
            }

        }
    }
}
