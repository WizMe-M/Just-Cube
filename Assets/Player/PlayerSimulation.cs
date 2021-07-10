using UnityEngine;

/// <summary>
/// Класс, отвечающий за перерисовку объекта (игрока)
/// </summary>
public class PlayerSimulation
{
    GameObject _player;
    public PlayerSimulation(GameObject player)
    {
        _player = player;
    }
    public void Move(Vector2 targetPosition, float speed)
    {
        _player.transform.position = Vector2.MoveTowards(_player.transform.position, targetPosition, speed * Time.deltaTime);
    }
    public void Rotate(Quaternion rotation)
    {
        _player.transform.rotation *= rotation;
    }    
}
