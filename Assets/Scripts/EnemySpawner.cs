using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 적 게임 오브젝트를 주기적으로 생성
public class EnemySpawner : MonoBehaviour
{
    public int nowWave;
    public int lastWave;
    [Serializable]
    public class Wave
    {
        public bool enemySpawn = true;
        public Transform enemyPos;
        public String enemyType = "Rifle";
    }

    [Serializable]
    public class Stage
    {
        public Wave[] wave;
        public bool waveStart = false;
        //public List<bool> waveStart = new List<bool>();

    }
    [SerializeField]
    public Stage[] stage;
    public List<bool> stageStart = new List<bool>();

    Vector3 lastCubePos;
    private int newStageArry;
    public bool isHole = true;

    float levelTime;
    public List<GameObject> enemyList = new List<GameObject>();
    public ObjectPool objPool;

    public GameObject player;
    public HostageSpawner hostageSpawner;
    // Start is called before the first frame update
    void Start()
    {
        nowWave = 0;
        lastWave = -1;
        for (int i = 0; i < stage.Length; i++)
        {
            stageStart.Add(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        newStageArry = GameManager.instance.nowStage;
        switch (GameManager.instance.nowStage)
        {
            case 1:
                stageStart[0] = true;
                GameManager.instance.nowStage = 0;
                break;
            case 2:
                stageStart[1] = true;
                GameManager.instance.nowStage = 0;
                break;
            case 3:
                stageStart[2] = true;
                GameManager.instance.nowStage = 0;
                break;

                //지금은 포문 계속 도는데 나우 스테이지로 바꿔야지 나중에
        }
        if (nowWave > lastWave)
        {
            stage[newStageArry].wave[nowWave].enemySpawn = true;
            hostageSpawner.LinkEnemy(newStageArry, nowWave);

        }
        // if (stage[newStageArry].waveStart)
        {
            //   for (int j = 0; j < stage[newStageArry].wave.Length; j++)
            {
                if (stage[newStageArry].wave[nowWave].enemySpawn == true)
                {
                    enemyList.Add(objPool.SpawnFromPool(stage[newStageArry].wave[nowWave].enemyType, new Vector3(stage[newStageArry].wave[nowWave].enemyPos.position.x, stage[newStageArry].wave[nowWave].enemyPos.position.y, stage[newStageArry].wave[nowWave].enemyPos.position.z),
                       Quaternion.identity));
                    stage[newStageArry].wave[nowWave].enemySpawn = false;
                }
            }
            //stage[i].waveStart = false;

        }


        lastWave = nowWave;

        NextStage();
    }

    void NextStage()
    {

        for (int i = 0; i < enemyList.Count; i++)
        {
            if (enemyList[i].GetComponent<Enemy>().isDead == false) return;
        }
        if (nowWave < stage[newStageArry].wave.Length)
            nowWave++;
        enemyList.Clear();
    }
    void PhaseFloor()
    {


    }
}