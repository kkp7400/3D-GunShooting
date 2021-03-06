using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // AI, 내비게이션 시스템 관련 코드를 가져오기


public class Hostage : LivingEntity
{
    //private LivingEntity targetEntity; // 추적할 대상
    private NavMeshAgent pathFinder; // 경로계산 AI 에이전트
    public GameObject gameMgr;
    public ParticleSystem hitEffect; // 피격시 재생할 파티클 효과
    public AudioClip deathSound; // 사망시 재생할 소리
    public AudioClip hitSound; // 피격시 재생할 소리
    public AutoDissolve[] dissolve = new AutoDissolve[3];
    private Animator enemyAnimator; // 애니메이터 컴포넌트
    private AudioSource enemyAudioPlayer; // 오디오 소스 컴포넌트
    private Renderer enemyRenderer; // 렌더러 컴포넌트    
    public GameObject player;
    public string myTag;
    public bool isDead = false;
    public float damage = 20f; // 공격력
    public float timeBetAttack = 0.5f; // 공격 간격
    private float lastAttackTime; // 마지막 공격 시점
    public ObjectPool objPool;
    private PlayerHp playerHp;
    public ParticleSystem HitFx;
    public GameObject fx;
    public GameObject[] skin = new GameObject[3];
    private void Awake()
    {
        // 초기화
        isDead = false;
        enemyAnimator = GetComponent<Animator>();
        base.health = 2;
        gameMgr = GameObject.FindGameObjectWithTag("GameController");
        player = GameObject.FindGameObjectWithTag("Player");
        playerHp = FindObjectOfType<PlayerHp>();
        objPool = gameMgr.GetComponent<ObjectPool>();
        fx = transform.FindChild("HitFx").gameObject;
        HitFx = fx.GetComponent<ParticleSystem>();
        //HitFx.Pause();
        fx.SetActive(false);
        skin[1] = transform.FindChild("Character_Woman_01").gameObject;
        skin[0] = transform.FindChild("Character_Cowgirl_01").gameObject;
        skin[2] = transform.FindChild("Character_WorkingGirl_01").gameObject;
        //dissolve[0] = transform.FindChild("Character_Woman_01").gameObject.GetComponent<AutoDissolve>();
        //dissolve[1] = transform.FindChild("Character_Cowgirl_01").gameObject.GetComponent<AutoDissolve>();
        //dissolve[2] = transform.FindChild("Character_WorkingGirl_01").gameObject.GetComponent<AutoDissolve>();

        StartCoroutine(Return());

    }


    // 적 AI의 초기 스펙을 결정하는 셋업 메서드
    public void Setup(float newHealth, float newDamage, float newSpeed, Color skinColor)
    {
    }

    private void Start()
    {
        int skimNum = Random.Range(0, 3);
        skin[skimNum].SetActive(true);
        // 게임 오브젝트 활성화와 동시에 AI의 추적 루틴 시작
        // StartCoroutine(UpdatePath());        
        myTag = this.gameObject.name;
    }

    private void Update()
    {
        StartCoroutine(Return());
        //transform.LookAt(player.transform);
        // 추적 대상의 존재 여부에 따라 다른 애니메이션을 재생
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

    // 주기적으로 추적할 대상의 위치를 찾아 경로를 갱신
    private IEnumerator UpdatePath()
    {
        // 살아있는 동안 무한 루프
        //while (!dead)
        {
            // 0.25초 주기로 처리 반복
            yield return new WaitForSeconds(0.25f);
        }
    }

    // 데미지를 입었을때 실행할 처리
    public override void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal)
    {
        // LivingEntity의 OnDamage()를 실행하여 데미지 적용
        base.OnDamage(damage, hitPoint, hitNormal);
        //fx.SetActive(true);
        //this.gameObject.GetComponent<Collider>().enabled = false;
    }

    //사망 처리
    public override void Die()
    {
        // LivingEntity의 Die()를 실행하여 기본 사망 처리 실행
        base.Die();
        //HitFx.Play();
        enemyAnimator.SetTrigger("Dead");
        isDead = true;
        playerHp.hp--;
        fx.SetActive(true);
        //HitFx.Play();
        this.gameObject.GetComponent<Collider>().enabled = false;
        StartCoroutine(Return());
    }

    private void OnTriggerStay(Collider other)
    {
        // 트리거 충돌한 상대방 게임 오브젝트가 추적 대상이라면 공격 실행   

    }

    public void Attack()
    {
    }
    IEnumerator Return()
    {

        yield return new WaitForSeconds(10f);
        //dissolve[0].isDissolve = true;
        //dissolve[1].isDissolve = true;
        //dissolve[2].isDissolve = true;
        myTag.Remove(myTag.Length - 7, 7);
        string test = myTag;
        objPool.ReturnToPool(myTag, this.gameObject);
    }
}
