using System.Collections;
using UnityEngine;

public class Ending2 : MonoBehaviour
{
    public GameObject spriteToControl;
    public float enableTime = 2f;
    public float disableTime = 2f;

    private void Start()
    {
        spriteToControl.SetActive(false);

        StartCoroutine(EnableDisableSprite());
    }

    private IEnumerator EnableDisableSprite()
    {
        yield return new WaitForSeconds(enableTime);

        spriteToControl.SetActive(true);

        yield return new WaitForSeconds(disableTime);

        spriteToControl.SetActive(false);
    }
}