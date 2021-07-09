using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    private enum GoalSwitcher
    {
        Up = 0,
        Down = 1
    }
    [SerializeField]
    private GoalSwitcher _goalSwitcher;

    private void Start()
    {
        if (Random.value >= 0.5f)
            _goalSwitcher = GoalSwitcher.Up;
        else
            _goalSwitcher = GoalSwitcher.Down;
        SwitchGoal();
    }

    public void SwitchGoal()
    {
        float positionX = Random.Range(-2f, 2f);
        if (_goalSwitcher == GoalSwitcher.Up)
        {
            this.transform.position = new Vector2(positionX, 1.65f);
            _goalSwitcher = GoalSwitcher.Down;
        }
        else
        {
            this.transform.position = new Vector2(positionX, -2.65f);
            _goalSwitcher = GoalSwitcher.Up;
        }
    }
}
