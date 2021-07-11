using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;

    private void Update()
    {
        transform.rotation *= Quaternion.Euler(0f, 0f, 1f);
        transform.position = new Vector2(transform.position.x + _speed * Time.deltaTime, transform.position.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            var panel = GameObject.FindGameObjectWithTag("RestartButton");
            panel.GetComponent<RestartPanel>().Activate();
        }
    }
}
