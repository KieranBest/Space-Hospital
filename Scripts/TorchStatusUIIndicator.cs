using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TorchStatusUIIndicator : MonoBehaviour
{
    private Image TorchStatus;
    public TorchControls torchControls;

    private float flashSpeed = 0.33f;
    private bool batteryFlash = false;

    public bool flashRed = false;
    public float batteryFlashSpeed;
    public bool black = false;

    private void Awake()
    {
        TorchStatus = GetComponent<Image>();
    }

    public void TorchStatusOn()
    {
        TorchStatus.GetComponent<Image>().color = new Color(255, 252, 189, 0.5f);
    }

    public void TorchStatusOff()
    {
        TorchStatus.GetComponent<Image>().color = new Color(0, 0, 0, 0.5f);
    }

    public void TorchStatusOverheated()
    {
        // If overheat flashing is not active, set active
        if (!flashRed)
        {
            flashRed = true;
            StartCoroutine(OverheatFlash(flashSpeed));
        }
    }

    IEnumerator OverheatFlash(float delay)
    {
        TorchStatus.GetComponent<Image>().color = new Color(255, 0, 0, 0.5f);
        yield return new WaitForSeconds(delay);
        TorchStatus.GetComponent<Image>().color = new Color(0, 0, 0, 0.5f);
        yield return new WaitForSeconds(delay);
        flashRed = false;
    }

    public void TorchBatteryLow()
    {
        // If battery flashing is not active, set active
        if (!batteryFlash)
        {
            // Define flash speed
            batteryFlashSpeed = Random.Range(1, 10) / 10;

            batteryFlash = true;
            StartCoroutine(BatteryFlash(batteryFlashSpeed));
        }
}

    IEnumerator BatteryFlash(float delay)
    {
        if (black)
        {
            TorchStatus.GetComponent<Image>().color = new Color(255, 252, 189, 0.5f);
            black = false;
        }
        else
        {
            TorchStatus.GetComponent<Image>().color = new Color(0, 0, 0, 0.5f);
            black = true;
        }
        yield return new WaitForSeconds(delay);
        batteryFlash = false;
    }
}
