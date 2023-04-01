using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class machineAnimation : MonoBehaviour
{
    [Header("Simulation de l'etat recçu: Niveau et Etat des neurones")]
    [SerializeField]
    int Niveau;
    [SerializeField]
    int codeEtat;
    [SerializeField]
    bool anim_running;

    [Header("Variables de paramétrages d'animation")]
    [SerializeField]
    float distanceMiniArret;
    [SerializeField]
    float speedYurE;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        if (anim_running) {
            proceedAnimation(this.Niveau, this.codeEtat);
        }
    }

    public void proceedAnimation(int Niveau, int Etat)
    {
        switch (Niveau)
        {
            /*NIVEAU 1: PARTICULE QUI S'ECRASE*/
            case 0:
                switch (Etat)
                {
                    /*CALME + AGGRESSIF*/
                    case 0:
                        goToDestination(GameObject.FindWithTag("incident"));
                        break;
                    /*INTELLIGENT + AGGRESSIF*/
                    case 1:
                        break;
                    /*CALME + INTELLIGENT*/
                    case 2:
                        break;
                    default:
                        break;
                }
                break;
            case 1:
                break;
            default:
                break;
        }
    }


    public void goToDestination(GameObject destination)
    {
        float distance = Vector3.Distance(this.transform.position, destination.transform.position);
        if(distance > this.distanceMiniArret)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, destination.transform.position, Time.deltaTime * this.speedYurE);
        }
        else
        {
            this.anim_running = false;
        }
    }
}
