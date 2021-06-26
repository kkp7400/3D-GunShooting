using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInOut : MonoBehaviour
{
    [SerializeField]
    private List<Transform> target = new List<Transform>();
    EnemySpawner es;
    //public List<GameObject> enemyList = new List<GameObject>();
    public float zoom;
    private Transform tr;
    private int num;
    
    // Start is called before the first frame update
    void Awake()
    {
        tr = GetComponent<Transform>();
        es = FindObjectOfType<EnemySpawner>();
        num = 0;

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < es.enemyList.Count; i++)
        {
            target[i].position = es.enemyList[i].GetComponent<Enemy>().transform.position;
        }
        int scase = 0;
        if (es.enemyList[scase].GetComponent<Enemy>().isDead == false) CameraZoomIn(num);
        if (es.enemyList[scase].GetComponent<Enemy>().isDead == true) CameraZoomOut(num);
    }
    void CameraZoomIn(int num)
    {
        Vector3 TargetDist = tr.position - (target[num].position + new Vector3(0, 1.5f, 0));
        TargetDist = Vector3.Normalize(TargetDist);
        Vector3 TargetMax = tr.position - (target[num].position + new Vector3(3, 1.5f, 3));
        TargetMax = Vector3.Normalize(TargetMax);
        Quaternion q = Quaternion.LookRotation(target[num].position + new Vector3(0, 1.5f, 0));
        transform.LookAt(target[num].position + new Vector3(0, 1.5f, 0));
        Vector3 distance = (TargetDist * 1f * zoom);
        if (distance.x <= TargetMax.x && distance.z <= TargetMax.z )
        {
            tr.position -= distance;
        }
       
            

        //if (es.enemyList[num].GetComponent<Enemy>().isDead == false)
        //{  
        //}

        //else if (es.enemyList[num].GetComponent<Enemy>().isDead == true)
        //{
        //    Vector3 TargetDist = tr.position - (target[num].position + new Vector3(0, +1.5f, 0));
        //    TargetDist = Vector3.Normalize(TargetDist);
        //    Quaternion q = Quaternion.LookRotation(target[num].position + new Vector3(0, +1.5f, 0));
        //    transform.LookAt(target[num].position + new Vector3(0 + 1.5f, 0));
        //    tr.position -= (TargetDist * -1 * zoom);
        //    num++;
        //}
    }
    void CameraZoomOut(int num)
    {
        Vector3 TargetDist = tr.position - (target[num].position + new Vector3(0, 1.5f, 0));
        TargetDist = Vector3.Normalize(TargetDist);
        Quaternion q = Quaternion.LookRotation(target[num].position + new Vector3(0, 1.5f, 0));
        transform.LookAt(target[num].position + new Vector3(0, 1.5f, 0));
        tr.position -= (TargetDist * -1 * zoom);
        num++;
    }
}
