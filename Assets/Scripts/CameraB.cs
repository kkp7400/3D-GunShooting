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
        if (Input.GetKeyDown(KeyCode.Space))    // ���콺 ������ ��ư���� ����/�ܾƿ� // Ű ���� ����
        { isZoomed = !isZoomed; }

        if(isZoomed)
        { GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime * smooth); }

        else 
        { GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, normal, Time.deltaTime * smooth); } 
    }
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))    // ���콺 ������ ��ư���� ����/�ܾƿ� // Ű ���� ����
        { isZoomed = !isZoomed; }

        if (isZoomed)
        { GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime * smooth); }

        else
        { GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, normal, Time.deltaTime * smooth); }
    }
}
