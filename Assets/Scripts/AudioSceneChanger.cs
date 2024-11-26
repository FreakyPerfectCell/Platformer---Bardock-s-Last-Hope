using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioSceneChanger : MonoBehaviour
{
    public AudioSource audioSource;
    public string nextSceneName = "Pre-Game";

    private bool isPlaying = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isPlaying)
        {
            PlayAudioAndChangeScene();
        }
    }

    void PlayAudioAndChangeScene()
    {
        if (audioSource != null && audioSource.clip != null)
        {
            isPlaying = true;
            audioSource.Play();

            Invoke(nameof(ChangeScene), audioSource.clip.length);
        }
        else
        {
            Debug.LogError("AudioSource or AudioClip is missing!");
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}