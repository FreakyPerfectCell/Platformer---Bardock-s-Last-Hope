using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Supernova : MonoBehaviour
{
    public float timeToGrow = 14f;
    public Vector3 targetScale = new Vector3(2f, 2f, 2f);
    public float growSpeed = 1f;

    public AudioClip supernovaAudio;
    private AudioSource audioSource;

    public string sceneToLoad = "Ending2";

    private void Start()
    {
        GameObject audioObject = new GameObject("AudioSourceObject");
        audioSource = audioObject.AddComponent<AudioSource>();
        DontDestroyOnLoad(audioObject);

        StartCoroutine(GrowSpriteAndPlayAudio());
    }

    private IEnumerator GrowSpriteAndPlayAudio()
    {
        yield return new WaitForSeconds(timeToGrow);

        if (supernovaAudio != null)
        {
            audioSource.PlayOneShot(supernovaAudio);
        }

        Vector3 initialScale = transform.localScale;
        float timeElapsed = 0f;

        while (timeElapsed < 1f)
        {
            transform.localScale = Vector3.Lerp(initialScale, targetScale, timeElapsed);
            timeElapsed += Time.deltaTime * growSpeed;
            yield return null;
        }

        transform.localScale = targetScale;

        ChangeScene();
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}