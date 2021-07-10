using UnityEngine;

public class Goal : MonoBehaviour
{
    private GoalLogic _goalLogic;
    private void Awake()
    {
        _goalLogic = new GoalLogic();
        Switch();
    }
    public void Switch()
    {
        Debug.Log("Goal switching");
        transform.position = _goalLogic.GetNewPosition();
    }
}
