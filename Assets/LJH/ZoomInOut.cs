using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInOut : MonoBehaviour
{
    [SerializeField]
    public List<Transform> target = new List<Transform>();
    EnemySpawner es;
    public List<GameObject> enemyList = new List<GameObject>();
    public float zoom;
    private Transform tr;
    int num = 0;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        es = FindObjectOfType<EnemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
       while(true)
        {
            if (es.enemyList[num].GetComponent<Enemy>().isDead == false)
            {
                Vector3 TargetDist = tr.position - target[num].position;
                TargetDist = Vector3.Normalize(TargetDist);
                tr.position -= (TargetDist * 1 * zoom);
                Quaternion q = Quaternion.LookRotation(target[num].position);
                transform.LookAt(target[num].position);
            }
            if (es.enemyList[num].GetComponent<Enemy>().isDead == true)
            {
                num += 1;
                Vector3 TargetDist = tr.position + target[num].position;
                TargetDist = Vector3.Normalize(TargetDist);
                tr.position += (TargetDist * 2 * zoom);
                transform.LookAt(tr.position);
            }
        }
       
    }
}
