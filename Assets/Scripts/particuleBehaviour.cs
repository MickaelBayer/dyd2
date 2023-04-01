using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particuleBehaviour : MonoBehaviour
{
    [SerializeField]
    GameObject destination;
    [SerializeField]
    float particuleSpeed;
    [SerializeField]
    float distanceMiniArret;
    bool isFrapped;

    [SerializeField]
    GameObject destinationImpact;
    [SerializeField]
    float speedChuteParticle;
    [SerializeField]
    bool isFalling;

    // Start is called before the first frame update
    void Start()
    {
        isFalling = true;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        if (isFalling)
        {

        }
    }

    public void particuleFrappee()
    {
        isFrapped = true;
    }
}
