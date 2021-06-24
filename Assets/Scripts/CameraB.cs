using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class CameraB : MonoBehaviour
{
    public int zoom = 20; 
    public int normal = 60; 
    public float smooth = 5;
    private bool isZoomed = false;
    public List<Transform> zoomPoint = new List<Transform>();

	private void Awake()
	{
		for (int i = 0; i < enemyList.Count; i++)
		{
            zoomPoint[i] = 
        }
        

    }
	void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))    // 마우스 오른쪽 버튼으로 줌인/줌아웃 // 키 변경 가능
        { isZoomed = !isZoomed; }

        if(isZoomed)
        { GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime * smooth); }

        else 
        { GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, normal, Time.deltaTime * smooth); } 
    }
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))    // 마우스 오른쪽 버튼으로 줌인/줌아웃 // 키 변경 가능
        { isZoomed = !isZoomed; }

        if (isZoomed)
        { GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime * smooth); }

        else
        { GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, normal, Time.deltaTime * smooth); }
    }
}
