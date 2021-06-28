using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject ball1;
    public DoorScript door;
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {        
        obj = transform.parent.gameObject;
        door = obj.GetComponent<DoorScript>();

    }

    // Update is called once per frame
    void Update()
    {
                
    }      

    private void OnCollisionEnter(Collision collision)
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy"|| other.tag == "Player")
        door.ChangeDoorState();
        //this.GetComponent<Collider>().enabled = false;
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
            ball1.GetComponent<Rigidbody>().AddForce(new Vector3(-400f, 200));
    }
}
