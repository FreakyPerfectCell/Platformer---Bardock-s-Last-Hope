using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KiManager : MonoBehaviour
{
    public int collectedKiCount = 0;
    public int targetKiCount = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Ki"))
            {
                Destroy(gameObject);

                collectedKiCount++;

                if (collectedKiCount >= targetKiCount)
                {
                    ChangeScene();
                }
            }
        }
    }


    void ChangeScene()
    {
        SceneManager.LoadScene("Ending");
    }
}