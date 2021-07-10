using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _goal;
    [SerializeField] private readonly float speed = 2f;
    [SerializeField] private Vector2 _targetPosition;
    [SerializeField] private Quaternion _rotation = Quaternion.Euler(0f, 0f, 1.9f);
    private void Start()
    {
        _goal = GameObject.FindGameObjectWithTag("Goal");
        GetGoalPosition();
    }
    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            InverseVector();
        }
        MoveToTarget();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Goal") == true)
        {
            GetGoalPosition();
            InverseRotation();
        }
    }
    public void MoveToTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, _targetPosition, speed * Time.deltaTime);
        transform.rotation *= _rotation;
    }
    public void InverseVector()
    {
        _targetPosition *= -1;
        InverseRotation();
    }
    public void InverseRotation()
    {
        _rotation = Quaternion.Inverse(_rotation);
    }
    public void GetGoalPosition()
    {
        _targetPosition = _goal.transform.position;
    }
}
