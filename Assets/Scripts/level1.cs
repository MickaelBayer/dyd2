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
            particle.GetComponent<particuleBehaviour>().setIsFalling(true);
    }

    public int getScenarioChoice()
    {
        return this.scenarioChoice;
    }

    private void scenar(int choice)
    {
        switch(choice)
        {
            /*AGGRESSIF*/
            case 0:
                yurE.GetComponent<machineAnimation>().frapperParticule();
                break;
            /*INTELLIGENT*/
            case 1:
                yurE.GetComponent<machineAnimation>().protectionParticule();
                yurE.GetComponent<machineAnimation>().anim_running = false;
                break;
            /*CALME*/
            case 2:
                yurE.GetComponent<machineAnimation>().sommeil();
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