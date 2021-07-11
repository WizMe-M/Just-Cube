using UnityEngine;

/// <summary>
/// Скрипт с логикой игрока
/// </summary>
public class Player : MonoBehaviour
{
    private Physic _physic;
    private Simulation _simulation;
    [SerializeField] private GameObject _goal;
    private void Start()
    {
        _goal = GameObject.FindGameObjectWithTag(nameof(Goal));
        _physic = new Physic(2f, Quaternion.Euler(0f, 0f, 1.9f), _goal.transform.position);
        _simulation = new Simulation(gameObject, _physic);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _physic.InverseVector();
        }
        _simulation.RedrawObject();
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
