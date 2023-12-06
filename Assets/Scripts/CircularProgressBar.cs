using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircularProgressBar : MonoBehaviour
{
    private Image radialProgressBar;
    public TorchControls torchControls;
    public TorchStatusUIIndicator torchStatus;

    private float indicatorTimer = 0f;
    private float maxIndicatorTimer;

    private void Awake()
    {
        radialProgressBar = GetComponent<Image>();
    }

    void Update()
    {
        // Torch on makes the timer decrease
        if (torchControls.torchOn)
        {
            indicatorTimer -= Time.deltaTime;
            radialProgressBar.fillAmount = (indicatorTimer / maxIndicatorTimer);

            // When timer reaches 0, torch overheats
            if (indicatorTimer <= 0)
            {
                torchControls.torchOverheated = true;
                torchControls._torchstate = TorchControls.TorchStates.TorchOverHeat;
            }
            // When timer reaches 10% make flicker
            if (indicatorTimer < (maxIndicatorTimer * 0.25))
            {
                torchControls.batteryLow = true;
                torchStatus.TorchBatteryLow();
            }
        }
        // Torch Off
        else
        {
            // Torch off makes the timer increase by (time * 2)
            if (indicatorTimer < maxIndicatorTimer)
            {
                indicatorTimer = indicatorTimer + (2 * Time.deltaTime);
                radialProgressBar.fillAmount = (indicatorTimer / maxIndicatorTimer);
            }
            // When timer equals max time, torch is no longer overheated
            else
            {
                torchStatus.flashRed = false;
                torchControls.torchOverheated = false;

            }
        }
    }

    public void ActiveCountdown(float countdownTime)
    {
        // Defines timer every time torch is turned on
        maxIndicatorTimer = countdownTime;
        // If timer has not been defined
        if (indicatorTimer == 0f)
        {
            indicatorTimer = maxIndicatorTimer;
        }
    }
}
