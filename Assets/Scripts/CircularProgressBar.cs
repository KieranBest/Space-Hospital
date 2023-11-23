using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircularProgressBar : MonoBehaviour
{
    private Image radialProgressBar;
    public TorchControls torchControls;

    private float indicatorTimer;
    private float maxIndicatorTimer;

    public bool isActive = false;
    public bool rechargeTorch = false;

    private void Awake()
    {
        radialProgressBar = GetComponent<Image>();
    }

    void Update()
    {
        if (isActive)
        {
            indicatorTimer -= Time.deltaTime;
            radialProgressBar.fillAmount = (indicatorTimer / maxIndicatorTimer);

            if (indicatorTimer <= 0)
            {
                torchControls.torchOverheated = true;
                StopCountdown();
                torchControls._torchstate = TorchControls.TorchStates.TorchOverHeat;
            }
        }
        if (rechargeTorch)
        {
            RechargeTorch(indicatorTimer);
        }
    }

    public void ActiveCountdown(float countdownTime)
    {
        isActive = true;
        maxIndicatorTimer = countdownTime;
        indicatorTimer = maxIndicatorTimer;
    }

    public void StopCountdown()
    {
        isActive = false;
    }

    public void RechargeTorch(float chargingTime)
    {
        chargingTime += Time.deltaTime;
        radialProgressBar.fillAmount = (chargingTime / maxIndicatorTimer);
    }
}
