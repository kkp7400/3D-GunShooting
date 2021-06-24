using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public ParticleSystem hitEffect; // �ǰݽ� ����� ��ƼŬ ȿ��
    public AudioClip deathSound; // ����� ����� �Ҹ�
    public AudioClip hitSound; // �ǰݽ� ����� �Ҹ�
    public Gun gun;
    private Animator enemyAnimator; // �ִϸ����� ������Ʈ
    private AudioSource enemyAudioPlayer; // ����� �ҽ� ������Ʈ
    private Renderer enemyRenderer; // ������ ������Ʈ    
    public GameObject player;

    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
    }

    public void Attack()
    {
        Debug.Log("��");
        gun.Fire();
    }
    
}
