using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectManager : MonoBehaviour
{
    public GameObject torchUI;
    public bool torchOn;

    public void StartTorchUI(float duration)
    {
        torchOn = true;
        torchUI.transform.Find("RadialProgressBar").GetComponent<CircularProgressBar>().ActiveCountdown(duration);

        StartCoroutine(EndTorchUI(duration));
    }

    IEnumerator EndTorchUI(float delay)
    {
        yield return new WaitForSeconds(delay);
        
        torchOn = false;
    }
}
