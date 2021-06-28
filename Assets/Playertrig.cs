using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playertrig : MonoBehaviour
{
    public bool start;
    public ZoomInOut zoomInOut;
    void Start()
    {
        start = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Stage2" || other.tag == "Stage3" || other.tag == "Stage4")
        {
            if (other.tag == "Stage4")
            {
                start = false;
                zoomInOut.isFight = false;
            }
            else start = true;
        }
    }
}
