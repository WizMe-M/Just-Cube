using UnityEngine;

public class Goal : MonoBehaviour
{
    private GoalLogic _goalLogic;
    private void Awake()
    {
        _goalLogic = new GoalLogic();
        transform.position = _goalLogic.GetNewPosition();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            transform.position = _goalLogic.GetNewPosition();
        }
    }
}
