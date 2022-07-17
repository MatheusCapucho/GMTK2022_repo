using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class DisablePanel : MonoBehaviour
{
    private void Start()
    {
        DisablePanelDelay();
    }

    private async void DisablePanelDelay()
    {
        await Task.Delay(100);
        gameObject.SetActive(false);
    }
}
