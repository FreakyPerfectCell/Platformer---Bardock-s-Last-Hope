using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneGame : MonoBehaviour
{
    public KiManager kiManager;
    public Timer timer;
    public AudioSource[] allAudioSources;

    void Start()
    {
        if (kiManager == null || timer == null)
        {
            Debug.LogError("KiManager or Timer script is not assigned.");
        }
    }

    void Update()
    {
        Debug.Log("Score: " + kiManager.collectedKiCount);
        Debug.Log("Timer: " + timer.GetCurrentTime());

        if (kiManager.collectedKiCount >= 10 || timer.GetCurrentTime() <= 0)
        {
            StopAllSounds();
            ChangeToEndingScene();
        }
    }

    void StopAllSounds()
    {
        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.Stop();
        }
    }

    void ChangeToEndingScene()
    {
        Debug.Log("Scene is changing to 'Ending'");
        SceneManager.LoadScene("Ending");  // Make sure "Ending" scene is added in Build Settings
    }
}