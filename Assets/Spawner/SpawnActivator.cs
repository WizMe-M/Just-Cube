using System.Collections.Generic;
using UnityEngine;

public class SpawnActivator : MonoBehaviour
{
    [SerializeField] private List<Spawner> _spawners;
    public SpawnActivator()
    {
        var gameObjectsArray = GameObject.FindGameObjectsWithTag(nameof(Spawner));
        if (gameObjectsArray.Length == 0 || gameObjectsArray == null)
            throw new System.NullReferenceException();

        foreach (var gameObject in gameObjectsArray)
        {
            _spawners.Add(gameObject.GetComponent<Spawner>());
        }
    }
    private void ActivateNewSpawner()
    {
        int index = _spawners.FindIndex(spawner => spawner.gameObject.GetComponent<Spawner>().IsActivated == true);
        _spawners[index].Activate();
    }
}
