using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInOut : MonoBehaviour
{
    [SerializeField]
    private List<Transform> target = new List<Transform>();
    public Transform headPosition;
    EnemySpawner es;
    Playertrig trig;
    public GameObject crossHair;
    public GameObject[] point;
    public Vector3 posit;
    public Vector3 rot;
    public float zoom;
    private Transform tr;
    private int num;
    public bool isFight = true;
    public PlayerDestination playerDestination;

    void Start()
    {
        num = 0;
        tr = GetComponent<Transform>();
        es = FindObjectOfType<EnemySpawner>();
        trig = FindObjectOfType<Playertrig>();
    }

    void Update()
    {
        for (int i = 0; i < es.enemyList.Count; i++)
        {
            target[i].position = es.enemyList[i].GetComponent<Enemy>().transform.position;
        }
        if (isFight)
        {
            if (es.enemyList[0].GetComponent<Enemy>().isDead == true)
            {
                CameraZoomOut();
                num += 1;
                
                if (num == 10 || num == 20 || num == 30 || num == 40)
                {
                    isFight = false;
                    playerDestination.destNum += 1;
                    playerDestination.isMove = true;
                }
            }
            else if (es.enemyList[0].GetComponent<Enemy>().isDead == false) CameraZoomIn();
        }
        else if(!isFight)
        {
            tr.position = headPosition.position - posit;
            tr.rotation = /*headPosition.rotation + */Quaternion.LookRotation(rot);
            if (trig.start == true)
            {
                isFight = true;
                playerDestination.isMove = false;
            }
        }    
    }
    void CameraZoomIn()
    {
        Vector3 targetDist = tr.position - (target[0].position + new Vector3(0, 1.5f, 0));
        targetDist = Vector3.Normalize(targetDist);
        Vector3 TargetMax = tr.position - (target[0].position + new Vector3(3, 1.5f, 3));
        TargetMax = Vector3.Normalize(TargetMax);
        Quaternion.LookRotation(target[0].position + new Vector3(0, 1.5f, 0));
        transform.LookAt(target[0].position + new Vector3(0, 1.5f, 0));
        Vector3 distance = (targetDist * 1f * zoom ) * Time.deltaTime;

        if (distance.x <= TargetMax.x && distance.z <= TargetMax.z) tr.position -= (distance * Time.deltaTime);

        //Vector3 pos;
        //pos.x = targetDist.x;
        //pos.y = targetDist.y;
        //pos.z = 1;
    }
    void CameraZoomOut()
    {
        Vector3 targetDist = tr.position - (target[0].position + new Vector3(0, 1.5f, 0));
        targetDist = Vector3.Normalize(targetDist);
        Quaternion.LookRotation(target[0].position + new Vector3(0, 1.5f, 0));
        transform.LookAt(target[0].position + new Vector3(0, 1.5f, 0));
        tr.position -= (targetDist * -1.0f * zoom ) * Time.deltaTime;
    }
}