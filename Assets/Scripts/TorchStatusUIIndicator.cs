using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TorchStatusUIIndicator : MonoBehaviour
{
    private Image TorchStatus;

    public TorchControls torchControls;

    private bool flashRed = false;
    private float flashSpeed = 0.33f;

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
        if (!flashRed)
        {        
            flashRed = true;
            TorchStatus.GetComponent<Image>().color = new Color(255, 0, 0, 0.5f);
            StartCoroutine(OverheatFlash(flashSpeed));
        }
    }

    IEnumerator OverheatFlash(float delay)
    {
        yield return new WaitForSeconds(delay);
        TorchStatus.GetComponent<Image>().color = new Color(0, 0, 0, 0.5f);
        yield return new WaitForSeconds(delay);
        flashRed = false;
    }
}
