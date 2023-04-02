using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gameOver : MonoBehaviour
{
    [SerializeField] private string restartLevel;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(restart());
    }

    IEnumerator restart()
    {
        yield return new WaitForSeconds(2f);

        PlayerPrefs.SetInt("ingameMusic", GameObject.Find("Music Manager").GetComponent<AudioSource>().timeSamples);
        SceneManager.LoadScene(restartLevel);
    }
}
