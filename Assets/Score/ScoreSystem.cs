using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem
{    
    [SerializeField] private int _score;
    [SerializeField] private Text _scoreUI;
    private SpawnerActivator _activator;
    public ScoreSystem()
    {
        _score = 0;
        _scoreUI = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        _scoreUI.text = $"Score: {_score}";
        _activator = new SpawnerActivator();
    }
    public void IncrementScore()
    {
        _score++;
        _scoreUI.text = $"Score: {_score}";
        if (_score == 5 || _score == 10)
        {
            _activator.ActivateNewSpawner();
        }
    }
}
