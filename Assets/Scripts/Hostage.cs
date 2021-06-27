using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // AI, ������̼� �ý��� ���� �ڵ带 ��������


public class Hostage : LivingEntity
{
    //private LivingEntity targetEntity; // ������ ���
    private NavMeshAgent pathFinder; // ��ΰ�� AI ������Ʈ
    public GameObject gameMgr;
    public ParticleSystem hitEffect; // �ǰݽ� ����� ��ƼŬ ȿ��
    public AudioClip deathSound; // ����� ����� �Ҹ�
    public AudioClip hitSound; // �ǰݽ� ����� �Ҹ�
    public AutoDissolve[] dissolve = new AutoDissolve[3];
    private Animator enemyAnimator; // �ִϸ����� ������Ʈ
    private AudioSource enemyAudioPlayer; // ����� �ҽ� ������Ʈ
    private Renderer enemyRenderer; // ������ ������Ʈ    
    public GameObject player;
    public string myTag;
    public bool isDead = false;
    public float damage = 20f; // ���ݷ�
    public float timeBetAttack = 0.5f; // ���� ����
    private float lastAttackTime; // ������ ���� ����
    public ObjectPool objPool;
    public ParticleSystem HitFx;
    public GameObject fx;
    public GameObject[] skin = new GameObject[3];
    private void Awake()
    {
        // �ʱ�ȭ
        isDead = false;
        enemyAnimator = GetComponent<Animator>();
        base.health = 2;
        gameMgr = GameObject.FindGameObjectWithTag("GameController");
        player = GameObject.FindGameObjectWithTag("Player");
        objPool = gameMgr.GetComponent<ObjectPool>();
        fx = transform.FindChild("HitFx").gameObject;
        HitFx = fx.GetComponent<ParticleSystem>();

        skin[1] = transform.FindChild("Character_Woman_01").gameObject;
        skin[0] = transform.FindChild("Character_Cowgirl_01").gameObject;
        skin[2] = transform.FindChild("Character_WorkingGirl_01").gameObject;
       //dissolve[0] = transform.FindChild("Character_Woman_01").gameObject.GetComponent<AutoDissolve>();
       //dissolve[1] = transform.FindChild("Character_Cowgirl_01").gameObject.GetComponent<AutoDissolve>();
       //dissolve[2] = transform.FindChild("Character_WorkingGirl_01").gameObject.GetComponent<AutoDissolve>();

        StartCoroutine(Return());

    }


    // �� AI�� �ʱ� ������ �����ϴ� �¾� �޼���
    public void Setup(float newHealth, float newDamage, float newSpeed, Color skinColor)
    {
    }

    private void Start()
    {
        int skimNum = Random.Range(0, 3);
        skin[skimNum].SetActive(true);
        // ���� ������Ʈ Ȱ��ȭ�� ���ÿ� AI�� ���� ��ƾ ����
        // StartCoroutine(UpdatePath());        
        myTag = this.gameObject.name;
    }

    private void Update()
    {
        StartCoroutine(Return());
        //transform.LookAt(player.transform);
        // ���� ����� ���� ���ο� ���� �ٸ� �ִϸ��̼��� ���
        //enemyAnimator.SetBool("HasTarget", hasTarget);

        //if (enemyAnimator.GetAnimatorTransitionInfo(0).IsName("Gunplay")&& enemyAnimator.GetAnimatorTransitionInfo(0).normalizedTime<1f)
        //{
        //    enemyAnimator.SetBool("Shot", true);
        //}
        //if(enemyAnimator.GetAnimatorTransitionInfo(0).IsName("IDle"))
        //{

        //    enemyAnimator.SetBool("Shot", false);
        //}
    }

    // �ֱ������� ������ ����� ��ġ�� ã�� ��θ� ����
    private IEnumerator UpdatePath()
    {
        // ����ִ� ���� ���� ����
        //while (!dead)
        {
            // 0.25�� �ֱ�� ó�� �ݺ�
            yield return new WaitForSeconds(0.25f);
        }
    }

    // �������� �Ծ����� ������ ó��
    public override void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal)
    {
        // LivingEntity�� OnDamage()�� �����Ͽ� ������ ����
        base.OnDamage(damage, hitPoint, hitNormal);

    }

    //��� ó��
    public override void Die()
    {
        // LivingEntity�� Die()�� �����Ͽ� �⺻ ��� ó�� ����
        base.Die();
        HitFx.Play();
        enemyAnimator.SetTrigger("Dead");
        isDead = true;
        StartCoroutine(Return());
    }

    private void OnTriggerStay(Collider other)
    {
        // Ʈ���� �浹�� ���� ���� ������Ʈ�� ���� ����̶�� ���� ����   

    }

    public void Attack()
    {  
    }
    IEnumerator Return()
    {
       
        yield return new WaitForSeconds(5f);
       //dissolve[0].isDissolve = true;
       //dissolve[1].isDissolve = true;
       //dissolve[2].isDissolve = true;
        myTag.Remove(myTag.Length - 7, 7);
        string test = myTag;
        objPool.ReturnToPool(myTag, this.gameObject);
    }
}
