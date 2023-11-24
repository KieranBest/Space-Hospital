using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectManager : MonoBehaviour
{
    public GameObject torchUI;
    public TorchControls torchControls;
    public Coroutine startCoroutine;

    public void StartTorchUI(float duration)
    {
        if (!torchControls.torchOn)
        {
            //StopAllCoroutines();
            torchControls.torchOn = true;
        }
        if (torchControls.torchOn)
        {        
            torchUI.transform.Find("RadialProgressBar").GetComponent<CircularProgressBar>().ActiveCountdown(duration);
            torchUI.transform.Find("TorchStatus").GetComponent<TorchStatusUIIndicator>();
            startCoroutine = StartCoroutine(EndTorchUI(duration));
        }
    }

    IEnumerator EndTorchUI(float delay)
    {
        yield return new WaitForSeconds(delay);

        torchControls.torchOn = false;
    }

    public void stopCoroutine()
    {
        StopCoroutine(startCoroutine);
    }
}
