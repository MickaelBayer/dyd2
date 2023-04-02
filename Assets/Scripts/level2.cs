using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level2 : MonoBehaviour
{
    private GameObject yurE, particle/*, umbrella*/;
    [SerializeField] private int scenarioChoice;

    // Start is called before the first frame update
    void Start()
    {
        yurE = GameObject.Find("YurE");
        particle = GameObject.Find("Particle");
        //umbrella = GameObject.Find("Umbrella");

        int neuron1 = 0, neuron2 = 0, neuron3 = 0, neuron4 = 0;
        try
        {
            neuron1 = PlayerPrefs.GetInt("Neurone (1)_levelValue");
            neuron2 = PlayerPrefs.GetInt("Neurone (2)_levelValue");
            neuron3 = PlayerPrefs.GetInt("Neurone (3)_levelValue");
            neuron4 = PlayerPrefs.GetInt("Neurone (4)_levelValue");
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }
        
        if(neuron1 == 0 && neuron2 == 0 && neuron3 == 0 && neuron4 == 1)
        {   //colere
            //pas assez fort
            scenarioChoice = 4;
        }
        else if (neuron1 == 0 && neuron2 == 0 && neuron3 == 1 && neuron4 == 0)
        {   //protege plante
            //pas assez fort
            scenarioChoice = 1;
        }
        else if (neuron1 == 0 && neuron2 == 1 && neuron3 == 0 && neuron4 == 0)
        {   //colere
            //pas assez fort
            scenarioChoice = 4;
        }
        else if (neuron1 == 1 && neuron2 == 0 && neuron3 == 0 && neuron4 == 0)
        {   //sommeil
            scenarioChoice = 3;
        }
        else if (neuron1 == 0 && neuron2 == 0 && neuron3 == 1 && neuron4 == 1)
        {   //tabasse
            //pas assez fort
            scenarioChoice = 4;
        }
        else if (neuron1 == 0 && neuron2 == 1 && neuron3 == 0 && neuron4 == 1)
        {   //tabasse
            // assez fort
            scenarioChoice = 0;
        }
        else if (neuron1 == 1 && neuron2 == 0 && neuron3 == 0 && neuron4 == 1)
        {   //tabasse
            //pas assez fort
            scenarioChoice = 4;
        }
        else if (neuron1 == 0 && neuron2 == 1 && neuron3 == 1 && neuron4 == 0)
        {   //tabasse
            scenarioChoice = 4;
        }
        else if (neuron1 == 1 && neuron2 == 1 && neuron3 == 0 && neuron4 == 0)
        {   //tabasse
            //pas assez fort
            scenarioChoice = 4;
        }
        else
        {   //tabasse
            //pas assez fort
            scenarioChoice = 4;
        }
    }

    public int getScenarioChoice()
    {
        return this.scenarioChoice;
    }

    private void scenar(int choice)
    {
        switch (choice)
        {
            /*AGGRESSIF * 2*/
            case 0:
                yurE.GetComponent<yurE_level2>().frapperPlante();
                StartCoroutine(waitToLoadVictory());
                break;
            /*INTELLIGENT*/
            case 1:
                yurE.GetComponent<yurE_level2>().protectionPlante();
                StartCoroutine(waitToGameOver());
                yurE.GetComponent<machineAnimation>().anim_running = false;
                break;
            /*CALME*/
            case 2:
                yurE.GetComponent<yurE_level2>().waitPlantDie();
                StartCoroutine(waitToLoadVictory());
                break;
            case 3:
                yurE.GetComponent<machineAnimation>().sommeil();
                StartCoroutine(waitToGameOver());
                break;
            case 4:
                yurE.GetComponent<machineAnimation>().frapperParticule();
                StartCoroutine(waitToLoadVictory());
                break;
            default:
                break;
        }
    }

    private IEnumerator waitToLoadVictory()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Victory");
    }

    private IEnumerator waitToGameOver()
    {
        yield return new WaitForSeconds(3f);
        try
        {
            PlayerPrefs.SetInt("ingameMusic", GameObject.Find("Music Manager").GetComponent<AudioSource>().timeSamples);
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }
        SceneManager.LoadScene("game_over_level2");
    }


    void FixedUpdate()
    {
        if (yurE.GetComponent<yurE_level2>().anim_running)
        {
            scenar(scenarioChoice);
        }
    }

}