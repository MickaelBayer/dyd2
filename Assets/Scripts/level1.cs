using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level1 : MonoBehaviour
{
    private GameObject yurE, particle/*, umbrella*/; 
    [SerializeField] private int scenarioChoice;

    // Start is called before the first frame update
    void Start()
    {
        yurE = GameObject.Find("YurE");
        particle = GameObject.Find("Particle");
        //umbrella = GameObject.Find("Umbrella");

        try
        {
            int neuron1 = PlayerPrefs.GetInt("neuron (1)_isKnown");
        }
        catch(System.Exception e)
        {
            Debug.Log(e);
        }

        scenarioChoice = 0;
    }

    private void scenar(int choice)
    {
        switch(choice)
        {
            /*INTELLIGENT + AGGRESSIF*/
            case 0:
                yurE.GetComponent<machineAnimation>().frapperParticule();
                break;
            /*CALME + AGGRESSIF*/
            case 1:
                break;
            /*CALME + INTELLIGENT*/
            case 2:
                break;
            default:
                break;
        }
    }

    void FixedUpdate()
    {
        if (yurE.GetComponent<machineAnimation>().anim_running)
        {
            scenar(scenarioChoice);
        }
    }

}