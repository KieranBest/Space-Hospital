using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TorchStatusUIIndicator : MonoBehaviour
{
    private Image TorchStatus;
    public TorchControls torchControls;

    private float flashSpeed = 0.33f;

    public bool flashRed = false;

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
}
