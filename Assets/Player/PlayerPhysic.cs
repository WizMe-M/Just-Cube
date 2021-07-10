using UnityEngine;

/// <summary>
/// Класс, отвечающий за физику игрока (скорость, направление движения, поворот)
/// </summary>
public class PlayerPhysic
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private Quaternion _rotation = Quaternion.Euler(0f, 0f, 1.9f);
    [SerializeField] private Vector2 _targetPosition;

    private GameObject _player;
    private PlayerSimulation _simulation;

    public PlayerPhysic(Vector2 position, GameObject player)
    {
        _speed = 2f;
        _rotation = Quaternion.Euler(0f, 0f, 1.9f);
        _targetPosition = position;
        _player = player;
        _simulation = new PlayerSimulation(_player);
    }
    public void MoveToTarget()
    {
        _simulation.Move(_targetPosition, _speed);
        _simulation.Rotate(_rotation);
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
    public void SetNewTargetPosition(Vector2 position)
    {
        _targetPosition = position;
    }

}
