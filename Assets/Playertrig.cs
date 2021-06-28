using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playertrig : MonoBehaviour
{
    public bool start = false;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Stage2" || other.tag == "Stage3" || other.tag == "Stage4") start = true;
    }
}
