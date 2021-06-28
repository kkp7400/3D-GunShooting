using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTrigger : MonoBehaviour
{
    public GameObject ball1;
    public EnemySpawner enemySpawner;
    private AudioSource highNoonPlayer; // 醚 家府 犁积扁
    public AudioClip highNoon; // 惯荤 家府
    // Start is called before the first frame update
    void Start()
    {
        highNoonPlayer = FindObjectOfType<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.instance.nowStage++;
            enemySpawner.nowWave = 0;
            enemySpawner.lastWave = -1;
            this.transform.position = new Vector3(100, 100, 100);
            ball1.GetComponent<Rigidbody>().AddForce(new Vector3(-400f, -200));
            highNoonPlayer.PlayOneShot(highNoon);

        }
    }
}
