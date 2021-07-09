using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartPanel : MonoBehaviour
{
    private void Start()
    {
        Deactivate();
    }
    public void Deactivate()
    {
        this.GetComponent<CanvasGroup>().alpha = 0;
        this.GetComponent<CanvasGroup>().interactable = false;
        this.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    public void Activate()
    {
        this.GetComponent<CanvasGroup>().alpha = 1;
        this.GetComponent<CanvasGroup>().interactable = true;
        this.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
