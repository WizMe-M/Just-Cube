using UnityEngine;

public class Goal : MonoBehaviour
{
    private ScoreSystem _scoring;
    private GoalLogic _goalLogic;
    private void Awake()
    {
        _scoring = new ScoreSystem();
        _goalLogic = new GoalLogic();
        transform.position = _goalLogic.GetNewPosition();
    }
    public void Switch()
    {
        _scoring.IncrementScore();
        transform.position = _goalLogic.GetNewPosition();
    }
}
