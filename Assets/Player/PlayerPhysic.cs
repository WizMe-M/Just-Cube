using UnityEngine;

public class PlayerPhysic
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private Quaternion _rotation = Quaternion.Euler(0f, 0f, 1.9f);
    [SerializeField] private Vector2 _targetPosition;
    public PlayerPhysic(Vector2 position)
    {
        _speed = 2f;
        _rotation = Quaternion.Euler(0f, 0f, 1.9f);
        _targetPosition = position;
    }
    public void SelectTarget(Vector2 targetPosition)
    {
        _targetPosition = targetPosition;
    }
    public Transform MoveToTarget(Transform playerTransform)
    {        
        playerTransform.position = Vector2.MoveTowards(playerTransform.position, _targetPosition, _speed * Time.deltaTime);
        playerTransform.rotation *= _rotation;
        return playerTransform;
    }
    public void InverseTarget()
    {
        _targetPosition *= -1;
        _rotation = Quaternion.Inverse(_rotation);
    }
}
