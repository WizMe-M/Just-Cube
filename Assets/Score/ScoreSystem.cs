using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{    
    [SerializeField] private int _score;
    [SerializeField] private Text _scoreUI;

    public void IncrementScore()
    {
        _score++;
        _scoreUI.text = $"Score: {_score}";
    }
}
