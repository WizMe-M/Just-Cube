using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public static GameObject _panel;
    [SerializeField] private GameObject _goal;
    [SerializeField] private Text _score;
    private int score = 0;
    private int basePlus = 1;
    private readonly float speed = 2f;

    //игрок должен уметь управлять только собой
    [SerializeField] private GameObject _spawnerOne;
    [SerializeField] private GameObject _spawnerThree;

    private void Start()
    {
        _goal = GameObject.FindGameObjectWithTag("Goal");
    }
    private void FixedUpdate()
    {
        this.transform.position = Vector2.MoveTowards(transform.position, _goal.transform.position, speed * Time.deltaTime);
        this.transform.rotation *= Quaternion.Euler(0f, 0f, 1.9f);

        //вынести эту логику в спавнер
        if (score > 10 && basePlus < 2)
        {
            _spawnerThree.gameObject.SetActive(true);
            basePlus = 2;
        }
        if (score > 25 && basePlus < 3)
        {
            _spawnerOne.gameObject.SetActive(true);
            basePlus = 3;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Goal"))
        {
            collision.GetComponent<GoalController>().SwitchGoal();

            //мне не нравится. лучше инкрементирование вынести в отдельный скрипт
            // и привязать его к объекту (тексту) Score, 
            // чтобы здесь только вызывать инкрементирующий метод
            score += basePlus;
            _score.text = score.ToString();
        }
    }
}
