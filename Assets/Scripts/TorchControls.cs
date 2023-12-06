using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TorchControls : MonoBehaviour
{
    public GameObject torchController;
    public StatusEffectManager statusEffectMgr;
    public CircularProgressBar circularProgressBar;
    public TorchStatusUIIndicator torchStatus;

    public enum TorchStates
    {
        TorchOn,
        TorchOff,
        TorchOverHeat
    }

    public TorchStates _torchstate = TorchStates.TorchOff;

    public float duration = 10f;
    public float regenerateDuration = 5f;
    public bool torchOverheated = false;
    public bool torchOn = false;
    public bool batteryLow = false;

    void Update()
    {
        switch (_torchstate)
        {
            case TorchStates.TorchOn:
                TorchPowerOn();
                break;
            case TorchStates.TorchOff:
                TorchPowerOff();
                break;
            case TorchStates.TorchOverHeat:
                TorchOverHeat();
                break;
            default:
                break;
        }
    }

    private void TorchPowerOn()
    {
        if (!torchOn)
        {
            statusEffectMgr.StartTorchUI(duration);
            torchController.SetActive(true);
            torchStatus.TorchStatusOn();
        }
        if (torchOn && batteryLow)
        {
            BatteryLow(torchStatus.batteryFlashSpeed);
        }

        // Turn Torch Off
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _torchstate = TorchStates.TorchOff;
        }
    }

    private void TorchPowerOff()
    {
        if (torchOn)
        {
            torchOn = false;
            batteryLow = false;
            torchController.SetActive(false);
            torchStatus.TorchStatusOff();
        }

        // Turn Torch On
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _torchstate = TorchStates.TorchOn;
        }
    }

    private void TorchOverHeat()
    {
        // Torch Overheated
        if (torchOverheated)
        {
            torchOn = false;
            batteryLow = false;
            torchController.SetActive(false);
            torchStatus.TorchStatusOverheated();
        }
        // Torch Cooled Down
        else
        {
            _torchstate = TorchStates.TorchOff;
        }
    }

    void BatteryLow(float batteryFlashSpeed)
    {
        StartCoroutine(IndicateBatteryLow(batteryFlashSpeed));
    }

    public IEnumerator IndicateBatteryLow(float delay)
    {
        if (torchStatus.black)
        {
            torchController.SetActive(true);
        }
        else
        {
            torchController.SetActive(false);
        }
        yield return new WaitForSeconds(delay);
    }
}
