using UnityEngine;

/// <summary>
/// Скрипт с логикой игрока
/// </summary>
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerPhysic _physic;
    [SerializeField] private GameObject _goal;
    private void Start()
    {
        _goal = GameObject.FindGameObjectWithTag("Goal");
        _physic = new PlayerPhysic(_goal.transform.position, gameObject);
    }
    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _physic.InverseVector();
        }
        _physic.MoveToTarget();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Goal") == true)
        {
            _goal.GetComponent<Goal>().Switch();
            _physic.InverseRotation();
            _physic.SetNewTargetPosition(_goal.transform.position);
        }
    }
}
