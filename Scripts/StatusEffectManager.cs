using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectManager : MonoBehaviour
{
    public GameObject torchUI;
    public TorchControls torchControls;
    public Coroutine startCoroutine;
    public TorchStatusUIIndicator torchStatus;

    public void StartTorchUI(float duration)
    {
        if (!torchControls.torchOn)
        {
            torchControls.torchOn = true;
        }
        if (torchControls.torchOn)
        {        
            torchUI.transform.Find("RadialProgressBar").GetComponent<CircularProgressBar>().ActiveCountdown(duration);
            torchUI.transform.Find("TorchStatus").GetComponent<TorchStatusUIIndicator>();
        }
    }

}
