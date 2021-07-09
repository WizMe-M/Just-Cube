using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    private float timer = 5f;

    private void FixedUpdate()
    {
        timer += 0.1f;
        if (timer > 10f)
        {
            timer = 0f;
            Instantiate(_prefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        }
    }
}