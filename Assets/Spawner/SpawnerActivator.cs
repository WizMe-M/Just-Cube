using System.Collections.Generic;
using UnityEngine;

public class SpawnerActivator
{
    [SerializeField] private List<GameObject> _spawners = new List<GameObject>();
    public SpawnerActivator()
    {
        _spawners.AddRange(GameObject.FindGameObjectsWithTag(nameof(Spawner)));
        if (_spawners.Count == 0 || _spawners == null)
            throw new System.NullReferenceException();
        int randomIndex = Random.Range(0, _spawners.Count - 1);
        _spawners[randomIndex].GetComponent<Spawner>().Activate();
    }
    public void ActivateNewSpawner()
    {
        int index = _spawners.FindIndex(spawner => spawner.gameObject.GetComponent<Spawner>().IsActivated == false);
        _spawners[index].GetComponent<Spawner>().Activate();
    }
}
