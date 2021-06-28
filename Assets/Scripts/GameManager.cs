using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerHp playerHp;
    public int nowStage = 0;
    public int nowWave = 0;

    public bool gameEnd;



    public float MoveSpeed { get; set; }
    public float MovedValue { get; set; }



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
        if (playerHp.isDead)
        {
            SceneManager.LoadScene("Ending");
        }
    }
}
