using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchControls : MonoBehaviour
{
    public Light torch;


    void Start()
    {
        torch = GetComponent<Light>();
    }
    public enum TorchStates
    {
        TorchOn,
        TorchOff,
        TorchOverHeat
    }

    TorchStates _torchstate = TorchStates.TorchOff;

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
        torch.enabled = true;

        if (Input.GetKey(KeyCode.Mouse0))
        {
            Debug.Log("OFF");
            _torchstate = TorchStates.TorchOff;
        }
    }

    private void TorchPowerOff()
    {
        torch.enabled = false;

        if (Input.GetKey(KeyCode.Mouse0))
        {
            Debug.Log("ON");
            _torchstate = TorchStates.TorchOff;
        }
    }

    private void TorchOverHeat()
    {

    }
}
