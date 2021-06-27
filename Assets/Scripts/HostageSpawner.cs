using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostageSpawner : MonoBehaviour
{
    public int nowWave;
    public int lastWave;
    [Serializable]
    public class Wave
    {
        public bool HostageSpawn = true;
        public Transform HostagePos;
        public String HostageType;
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
    public List<GameObject> HostageList = new List<GameObject>();
    public ObjectPool objPool;

    public GameObject player;
    public float spawnTime = 0f;
    
        
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
    }

    public void LinkEnemy(int newStageArry, int nowWave)
    {
        stage[newStageArry].wave[nowWave].HostageSpawn = true;
        if (stage[newStageArry].wave[nowWave].HostageSpawn == true&&
            stage[newStageArry].wave[nowWave].HostagePos != null)
        {
            objPool.SpawnFromPool(stage[newStageArry].wave[nowWave].HostageType, new Vector3(stage[newStageArry].wave[nowWave].HostagePos.position.x, stage[newStageArry].wave[nowWave].HostagePos.position.y, stage[newStageArry].wave[nowWave].HostagePos.position.z),
            stage[newStageArry].wave[nowWave].HostagePos.localRotation);
            stage[newStageArry].wave[nowWave].HostageSpawn = false;
        }
    }
}
