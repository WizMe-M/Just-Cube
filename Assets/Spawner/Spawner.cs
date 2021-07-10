using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool IsActivated => _isActivated;
    [SerializeField] private GameObject _prefab;
    private const float _cooldown = 7.4f;
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
                Instantiate(_prefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            }
        }
    }
    public void Activate()
    {
        _isActivated = true;
    }
}