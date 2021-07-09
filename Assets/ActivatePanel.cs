using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivatePanel : MonoBehaviour
{
    public static void Active()
    {
        GameObject panel = GameObject.FindWithTag("Panel");
        panel.SetActive(true);
    }

    public void Again()
    {
        Debug.Log("OK");
        SceneManager.LoadScene(0);
    }
}
