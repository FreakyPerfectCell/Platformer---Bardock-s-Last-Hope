using System.Collections;
using UnityEngine;

public class Ending : MonoBehaviour
{
    public float moveSpeed = 1f;
    private Vector3 targetPosition = new Vector3(0, 0, 0);
    private Vector3 startPosition = new Vector3(0, -10, 0);

    private void Start()
    {
        transform.position = startPosition;

        StartCoroutine(MoveSprite());
    }

    private IEnumerator MoveSprite()
    {
        float journeyLength = Vector3.Distance(startPosition, targetPosition);
        float startTime = Time.time;

        while (transform.position != targetPosition)
        {
            float distanceCovered = (Time.time - startTime) * moveSpeed;
            float fractionOfJourney = distanceCovered / journeyLength;

            transform.position = Vector3.Lerp(startPosition, targetPosition, fractionOfJourney);

            yield return null;
        }

        transform.position = targetPosition;
    }
}