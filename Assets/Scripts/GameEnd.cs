using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    public GameObject player;
    void Update()
    {
        if (player.transform.position.y <= -14f)
        {
            Debug.Log("Player fell below -14. Changing to 'BadEnding2' scene.");
            ChangeToBadEndingScene();
        }
    }

    private void ChangeToBadEndingScene()
    {
        SceneManager.LoadScene("BadEnding2");
    }
}