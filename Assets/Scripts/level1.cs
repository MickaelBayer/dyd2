using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        int neuron1 = 0, neuron2 = 0, neuron3 = 0;
        try
        {
            neuron1 = PlayerPrefs.GetInt("Neurone (1)_levelValue");
            neuron2 = PlayerPrefs.GetInt("Neurone (2)_levelValue");
            neuron3 = PlayerPrefs.GetInt("Neurone (3)_levelValue");
        }
        catch(System.Exception e)
        {
            Debug.Log(e);
        }
        particle.GetComponent<particuleBehaviour>().setIsFalling(true);

        if ((neuron1 == 1 && neuron2 == 0 && neuron3 == 1) || (neuron1 == 1 && neuron2 == 0 && neuron3 == 0) || (neuron1 == 0 && neuron2 == 0 && neuron3 == 1))
        {
            scenarioChoice = 1;
        }
        else if (neuron1 == 0 && neuron2 == 1 && neuron3 == 1 )
        {
            scenarioChoice = 0;
        }
        else
        {
            scenarioChoice = 2;
        }

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
                StartCoroutine(waitToLoadVictory());
                break;
            /*INTELLIGENT*/
            case 1:
                yurE.GetComponent<machineAnimation>().protectionParticule();
                StartCoroutine(waitToLoadVictory());
                break;
            /*CALME*/
            case 2:
                yurE.GetComponent<machineAnimation>().sommeil();
                StartCoroutine(waitToGameOver());
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
        SceneManager.LoadScene("game_over");
    }
    

void FixedUpdate()
    {
        if (yurE.GetComponent<machineAnimation>().anim_running)
        {
            scenar(scenarioChoice);
        }
    }

}