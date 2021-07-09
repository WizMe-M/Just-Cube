using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }

    //?????
    public void Again()
    {
        Debug.Log("Что происходит? Где? Когда? РЕСТАРТ ИГРЫ!");
        SceneManager.LoadScene(0);
    }
}
