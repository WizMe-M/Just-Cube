using UnityEngine;

/// <summary>
/// Класс, отвечающий за перерисовку объекта (игрока)
/// </summary>
public class Simulation
{
    private GameObject _simulatedObject;
    private Physic _physic;

    public Simulation(GameObject simulatedObject, Physic physic)
    {
        _simulatedObject = simulatedObject;
        _physic = physic;
    }
    public void RedrawObject()
    {
        Move(_physic.TargetPosition, _physic.Speed);
        Rotate(_physic.Rotation);
    }
    private void Move(Vector2 targetPosition, float speed)
    {
        _simulatedObject.transform.position = Vector2.MoveTowards(_simulatedObject.transform.position, targetPosition, speed * Time.deltaTime);
    }
    private void Rotate(Quaternion rotation)
    {
        _simulatedObject.transform.rotation *= rotation;
    }    
}
