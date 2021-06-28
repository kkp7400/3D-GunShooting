using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;//네비게이션

public class PlayerDestination : MonoBehaviour
{
    public float runSpeed;
    public ZoomInOut camera;
    NavMeshAgent nav;
    public bool isMove;
    public int destNum;
    public List<GameObject> destObj = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        destNum = -1;
        nav = GetComponent<NavMeshAgent>();
        //camera = FindObjectOfType<ZoomInOut>();
        nav.speed = runSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        if (isMove == true)
        {
            nav.SetDestination(destObj[destNum].transform.position);
            transform.LookAt(destObj[destNum].transform);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Stage4")
        {
            other.gameObject.SetActive(false);
            isMove = false;
            this.gameObject.transform.rotation = Quaternion.identity;
            nav.enabled = false;
        }
    }
}
