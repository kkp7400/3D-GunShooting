using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text timer;
    public PlayerHp playerHp;
    public int nowStage = 0;
    public int nowWave = 0;

    public bool gameEnd;

    public float MoveSpeed { get; set; }
    public float MovedValue { get; set; }

    public bool timerOn = true;
    public float totalTime = 0f;

    public int minute = 0;
    public int second = 0;
    public int tic = 0;

    private void Awake()
    {
        gameEnd = false;
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(timer);
        MoveSpeed = 4f;
        MovedValue = 0f;
        nowStage = 0;
}

    // Update is called once per frame
    void Update()
    {
        MovedValue += MoveSpeed * Time.deltaTime;
        if (gameEnd)
        {
            if (Input.GetMouseButtonDown(0))
                SceneManager.LoadScene(0);
        }
        if(nowStage == 4)
        {

        }
        if (playerHp.isDead)
        {
            SceneManager.LoadScene("Ending");
        }
        if (timerOn)
        {
            totalTime += Time.deltaTime;
        }
        timer.GetComponent<Text>().text = "Time : " + TimerCalc();
    }

    private string TimerCalc()
    {
        tic = (int)((totalTime % 1) * 100);

        second = (int)totalTime % 60;

        minute = (int)totalTime / 60;

        return minute + " : " + second + " : " + tic;
    }
}
