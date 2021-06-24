using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private List<Transform> target = new List<Transform>();
    private List<GameObject> enemyList = new List<GameObject>();

    public float smoothTime = 0.2f;

    private Vector3 lastMovingVelocity;
    private Vector3 targetPosition;

    private Camera cam;
    private float targetZoomSize = 5f;

    private const float roundReadyZoomSize = 14.5f;
    private const float readyShotZoomSize = 5f;
    private const float trackingZoomSize = 10f;

    private float lastZoomSpeed;

    public enum State
    {
        // 3가지 상황을 줌
        Idle, Ready, Tracking
    }

    // 프로퍼티 사용
    private State state
    {
        set
        {
            switch (value)
            {
                case State.Idle:
                    targetZoomSize = roundReadyZoomSize; //추가
                    break;
                case State.Ready:
                    targetZoomSize = readyShotZoomSize; //추가
                    break;
                case State.Tracking:
                    targetZoomSize = trackingZoomSize; //추가
                    break;
            }
        }
    }

    void Awake()
    {
        cam = GetComponentInChildren<Camera>(); //추가
        state = State.Idle;
    }

    void Start()
    {
		for (int i = 0; i < enemyList.Count; i++)
		{
            target[i] = enemyList[i].GetComponent<Enemy>().transform;
        }
        //target = GameObject.Find("Enemy").GetComponent<Transform>();
    }

    //카메라가 추적 대상으로 이동
    private void Move()
    {
		//for (int i = 0; i < enemyList.Count; i++)
		//{
		//	if ((!enemyList[i].GetComponent<Enemy>().isDead))
		//	{
            //targetPosition = target[i].position;
        //  }
		//	if (true)
		//	{

		//	}
		//}
        targetPosition = target[1].position;

        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, targetPosition,
                                            ref lastMovingVelocity, smoothTime);

        transform.position = smoothPosition;

        state = State.Tracking;
    }

    private void Zoom()
    {
        float smoothZoomSize = Mathf.SmoothDamp(cam.orthographicSize, targetZoomSize,
                                            ref lastZoomSpeed, smoothTime);

        cam.orthographicSize = smoothZoomSize;
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            Move();
            Zoom();
        }
    }
}
