using UnityEngine;

/// <summary>
/// Класс, отвечающий за физику игрока (скорость, направление движения, поворот)
/// </summary>
public class Physic
{
    public float Speed => _speed;
    public Quaternion Rotation => _rotation;
    public Vector2 TargetPosition => _targetPosition;

    [SerializeField] private float _speed;
    [SerializeField] private Quaternion _rotation;
    [SerializeField] private Vector2 _targetPosition;

    public Physic(float speed, Quaternion rotation, Vector2 targetPosition)
    {
        _speed = speed;
        _rotation = rotation;
        _targetPosition = targetPosition;
    }
    public void InverseVector()
    {
        _speed *= -1;
        InverseRotation();
    }
    public void InverseRotation()
    {
        _rotation = Quaternion.Inverse(_rotation);
    }
    public void SetNewTargetPosition(Vector2 position)
    {
        _targetPosition = position;
    }

}
