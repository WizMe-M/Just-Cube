using UnityEngine;

public class GoalLogic
{
    private enum GoalSwitcher
    {
        Up,
        Down
    }
    [SerializeField] private GoalSwitcher _switcher = GoalSwitcher.Up;

    public GoalLogic()
    {
        if (Random.value >= 0.5f)
        {
            _switcher = GoalSwitcher.Down;
        }
    }

    public Vector2 GetNewPosition()
    {
        Vector2 newPosition;

        float x = Random.Range(-2f, 2f);
        if (_switcher == GoalSwitcher.Up)
        {
            newPosition = new Vector2(x, 2.65f);
            _switcher = GoalSwitcher.Down;
        }
        else
        {
            newPosition = new Vector2(x, -2.65f);
            _switcher = GoalSwitcher.Up;
        }

        return newPosition;
    }
}
