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

    private void Awake()
    {
        radialProgressBar = GetComponent<Image>();
    }

    // Update is called once per frame
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
        else
        {
            radialProgressBar.fillAmount = 1f;
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
}
