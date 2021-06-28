using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTrigger : MonoBehaviour
{
    public EnemySpawner enemySpawner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.nowStage++;
        enemySpawner.nowWave = 0;
        enemySpawner.lastWave = -1;
    }
}
