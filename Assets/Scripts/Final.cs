using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final : MonoBehaviour
{
    public float moveDuration = 5f;
    private Vector3 startPosition = new Vector3(0, -13, 0);
    private Vector3 endPosition = new Vector3(0, 0, 0);
    private float timeElapsed = 0f;

    void Start()
    {
        transform.position = startPosition;
        StartCoroutine(MoveToPosition());
    }

    private IEnumerator MoveToPosition()
    {
        while (timeElapsed < moveDuration)
        {
            timeElapsed += Time.deltaTime;
            
            transform.position = Vector3.Lerp(startPosition, endPosition, timeElapsed / moveDuration);
            yield return null;
        }
        
        transform.position = endPosition;

        yield return new WaitForSeconds(7f);

        EndGame();
    }

    private void EndGame()
    {
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}