using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    [SerializeField]
    Camera m_Cam;
    [SerializeField]
    List<GameObject> m_Targets;
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject canterObj;
    //[SerializeField]
    //GameObject pivot;


    private float m_CamSpeed = 50f;
    private float m_CamMax;
    private float m_CamMin;
    private float m_CamPreviousLocation = 0f;
    private float time;

    public int index { get; private set; }

	private void Awake()
	{
        //���ӿ�����Ʈ�� �����ö�

        //���� ������Ʈ �̸����� �����ö�
        //player = GameObject.Find("Player");

        //���� ������Ʈ Ÿ������ �����ö�
        //player = GameObject.FindGameObjectsWithTag("Player");

        //�ڽ� ������Ʈ���� �θ� ������Ʈ�� �����ö�
        player = transform.parent.gameObject;
	}
	// Start is called before the first frame update
	void Start()
    {
        m_Cam.fieldOfView = 100;
    }

    // Update is called once per frame
    void Update()
    {
        m_Cam.transform.position = (canterObj.transform.position + new Vector3(0.0f, 2f, 0f));
        //cam.transform.rotation = Quaternion.Euler(target.transform.position.x, target.transform.position.y, target.transform.position.z) //target.transform.rotation; //canterObj.transform.rotation;
       
        if (Input.GetMouseButton(1))
        {
            if (m_Targets != null)
            {
                time = Time.time * 0.3f;
                ZoomIn();
                TargetRotate();
                //m_Cam.transform.LookAt(m_Targets[index].transform.position);
                //Debug.Log(target.name);
                //m_Cam.transform.rotation = Quaternion.Slerp(pivot.transform.rotation, m_Targets[index].transform.rotation, time);
            }
        }

        else
        {
            time = Time.time * 0.3f;
            ZoomOut();
            PivotRotate();
            //m_Cam.transform.LookAt(pivot.transform.position);
            //Debug.Log(m_Cam.name);
            //m_Cams.transform.rotation = Quaternion.Slerp(pivot.transform.rotation, m_Targets[index].transform.rotation, time);
        }

        if(Input.GetMouseButtonDown(0))
		{
            if(m_Targets.Count - 1 > index)
			{
                index++;
            }
		}
        time = 0;
    }

    private void ZoomIn()
	{
        //cam.transform.rotation = Quaternion.Lerp(pivot.transform.rotation, target.transform.rotation, 3f);
        m_Cam.fieldOfView = m_Cam.fieldOfView - (Time.deltaTime * m_CamSpeed);

        if(m_Cam.fieldOfView <= 10)
		{
            m_Cam.fieldOfView = 10;
		}
    }

    private void ZoomOut()
	{
        //cam.transform.rotation = Quaternion.Lerp(target.transform.rotation, pivot.transform.rotation, m_CamSpeed);
        m_Cam.fieldOfView = m_Cam.fieldOfView + (Time.deltaTime * m_CamSpeed);

        if (m_Cam.fieldOfView >= 100)
        {
            m_Cam.fieldOfView = 100;
        }
    }

    private void TargetRotate()
	{
        //m_Cam.transform.rotation = Vector3.Lerp(pivot.transform.position, m_Targets[index].transform.position, Time.deltaTime * 5f);

        //float currYAngle = Mathf.LerpAngle(m_Targets[index].transform.eulerAngles.y, m_Cam.transform.eulerAngles.y,
        //    5.0f * Time.deltaTime);
        //
        //Quaternion rot = Quaternion.Euler(0, currYAngle, 0);
        //
        //m_Cam.transform.position = m_Targets[index].transform.position - (rot * Vector3.forward * 10f)
        //    + (Vector3.up * 5.0f);



        //Quaternion targetRotation = Quaternion.Euler(m_Targets[index].transform.position.x, 0, m_Targets[index].transform.position.y);
        //
        //m_Cam.transform.rotation = Quaternion.Slerp(m_Cam.transform.rotation, targetRotation,  Time.deltaTime * 0.3f);

        //              ����ġ - ī�޶���ġ�� ���� ���� �� ��ġ���� ����ġ�� ������ ��Ÿ����.
        Vector3 dir = m_Targets[index].transform.position - m_Cam.transform.position;

        //Quaternion.Lerp�Լ��� ����ϸ� �ε巴�� ȸ���� �Ѵ� �׸��� Quaternion.LookRotation(dir)�� dir���࿡ ���� ���ʹϾ� ��ȸ���� �ϰ� ���ش�
        m_Cam.transform.rotation = Quaternion.Lerp(m_Cam.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * 5f);
    }

    private void PivotRotate()
    {
        //Quaternion.Lerp�Լ��� ����ϸ� �ε巴�� ȸ���� �Ѵ� �׸��� Quaternion.LookRotation(dir)�� dir���࿡ ���� ���ʹϾ� ��ȸ���� �ϰ� ���ش�
        m_Cam.transform.rotation = Quaternion.Lerp(m_Cam.transform.rotation, player.transform.rotation, Time.deltaTime * 5f);
    }

    public void AddTarget(GameObject target)
	{
        if(target != null)
		{
            m_Targets.Add(target);
		}
        else
		{
            Debug.Log("Ÿ���� �����...");
		}
	}
}
