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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (isFrapped)
        {
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
}
