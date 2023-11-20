using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TorchControls : MonoBehaviour
{
    public GameObject torchController;

    public StatusEffectManager statusEffectMgr;
    public CircularProgressBar circularProgressBar;

    public enum TorchStates
    {
        TorchOn,
        TorchOff,
        TorchOverHeat
    }

    public TorchStates _torchstate = TorchStates.TorchOff;

    public bool torchOn = false;
    public float duration = 10f;

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
            torchOn = true;
            statusEffectMgr.StartTorchUI(duration);
            torchController.SetActive(true);
        }
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("OFF");
            _torchstate = TorchStates.TorchOff;
        }
    }

    private void TorchPowerOff()
    {
        if (torchOn)
        {
            torchOn = false;
            circularProgressBar.isActive = false;
            torchController.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("ON");
            _torchstate = TorchStates.TorchOn;
        }
    }

    private void TorchOverHeat()
    {
        Debug.Log("Overheated");
    }
}
