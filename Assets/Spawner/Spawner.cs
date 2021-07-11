using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool IsActivated => _isActivated;
    [SerializeField] private GameObject _spawnObject;

    private const float _cooldown = 10f;
    [SerializeField] private float _spawnTimer = _cooldown;
    [SerializeField] private bool _isActivated;    
    private void FixedUpdate()
    {
        if (IsActivated == true)
        {
            _spawnTimer -= 0.1f;
            if (_spawnTimer <= 0f)
            {
                _spawnTimer = _cooldown;
                Instantiate(_spawnObject, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            }
        }
    }
    public void Activate()
    {
        _isActivated = true;
    }
    public void Deactivate()
    {
        _isActivated = false;
    }
}