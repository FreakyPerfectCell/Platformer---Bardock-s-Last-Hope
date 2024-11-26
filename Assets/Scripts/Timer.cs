using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    float currentTime;
    public float startingTime = 10f;

    [SerializeField] Text countdownText;

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
        }
        else
        {
            currentTime = 0;
            ChangeSceneToEnding();
        }

        countdownText.text = currentTime.ToString("0");
    }

    public float GetCurrentTime()
    {
        return currentTime;
    }

    void ChangeSceneToEnding()
    {
        Debug.Log("Timer reached 0. Changing to Ending scene.");
        SceneManager.LoadScene("Ending");
    }
}