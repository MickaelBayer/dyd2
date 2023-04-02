using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicManager : MonoBehaviour
{
    [SerializeField] private string saveSample;

    private void Start()
    {
        resumeMusic();
    }

    private void resumeMusic()
    {
        try
        {
            int sample = PlayerPrefs.GetInt(saveSample);
            GetComponent<AudioSource>().timeSamples = sample;
        }
        catch(System.Exception e)
        {
            Debug.Log(e);
        }
    }

}
