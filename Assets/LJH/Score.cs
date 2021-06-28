using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text myScore;
    public int minute = 0;
    public int second = 0;
    public int tic = 0;
    // Start is called before the first frame update
    void Start()
    {
        myScore = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        minute = GameManager.instance.minute;
        second = GameManager.instance.second;
        tic = GameManager.instance.tic;
        myScore.text = "Rec : " + minute + " : " + second + " : " + tic;
    }
}
