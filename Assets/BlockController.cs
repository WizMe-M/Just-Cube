using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BlockController : MonoBehaviour
{
    [SerializeField] public static GameObject _panel;
    [SerializeField] private GameObject _upGoal;
    [SerializeField] private GameObject _downGoal;
    [SerializeField] private GameObject _spawnerOne;
    [SerializeField] private GameObject _spawnerThree;
    [SerializeField] private Text _score;
    [SerializeField] private Button _runButton;
    [SerializeField] private Text _runText;

    private readonly float maxRunTime = 4f;
    private readonly float maxSpeed = 4f;
    private readonly float baseSpeed = 2f;
    private float runTime = 4f;
    private float speed = 2f;
    private bool switcher = true;
    private int score = 0;
    private int basePlus = 1;
    private bool runAccept = false;

    private void Start()
    {
        _panel = GameObject.FindWithTag("Panel");
        _panel.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (switcher)
            this.transform.position = Vector3.MoveTowards(transform.position, _upGoal.transform.position, speed * Time.deltaTime);
        if (!switcher)
            this.transform.position = Vector3.MoveTowards(transform.position, _downGoal.transform.position, speed * Time.deltaTime);
        transform.rotation *= Quaternion.Euler(0f, 0f, 1.9f);

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

        _runText.text = runTime.ToString();
        ManageRunnig();
    }

    public void Spin()
    {
        switcher = !switcher;
    }

    //method for runButton
    public void Run()
    {
        runAccept = true;
    }

    //method to control run state behavior
    private void ManageRunnig()
    {
        if (runAccept && (runTime == maxRunTime || runTime > maxRunTime))
        {
            IncreaseSpeed(true);
            _runButton.enabled = false;
        }
        if (runAccept && (runTime < maxRunTime && runTime > 0f))
        {
            IncreaseSpeed(true);
        }
        if (runAccept && runTime < 0f)
        {
            runTime = 0f;
            runAccept = false;
        }
        if (!runAccept && (runTime == 0f || runTime < maxRunTime))
        {
            IncreaseSpeed(false);
        }
        if (!runAccept && (runTime == maxRunTime || runTime > maxRunTime))
        {
            _runButton.enabled = true;
            runTime = maxRunTime;
        }
    }

    public void IncreaseSpeed(bool destination)
    {
        if (!destination)
        {
            speed = baseSpeed;
            runTime += 0.1f;
        }
        else
        {
            speed = maxSpeed;
            runTime -= 0.1f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Goal")
        {
            switcher = !switcher;
            collision.gameObject.SetActive(false);
            _upGoal.transform.position = new Vector3(Random.Range(-1.893f, 1.901f), 1.648f, 0.0915f);
            collision.gameObject.SetActive(true);
            score += basePlus;
            _score.text = score.ToString();
        }

        if (collision.tag == "Goal2")
        {
            switcher = !switcher;
            collision.gameObject.SetActive(false);
            _downGoal.transform.position = new Vector3(Random.Range(-1.893f, 1.901f), -2.646f, 0.0915f);
            collision.gameObject.SetActive(true);
            score += basePlus;
            _score.text = score.ToString();
        }
    }
}
