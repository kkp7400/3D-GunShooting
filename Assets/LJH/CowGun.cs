using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class CowGun : MonoBehaviour
{
	public Transform target;
	public enum State
	{ // enum flag�� ����ϸ� �ϳ��� enum ������ 2�� �̻��� ���� ���� �� ����.
		Ready, // �߻� �غ��
		Empty, // źâ�� ��
		Reloading // ������ ��
	}
	public State state { get; private set; } // ���� ���� ����

	public Transform fireTransform; // �Ѿ��� �߻�� ��ġ

	public ParticleSystem muzzleFlashEffect; // �ѱ� ȭ�� ȿ��
	public ParticleSystem shellEjectEffect; // ź�� ���� ȿ��

	private LineRenderer bulletLineRenderer; // �Ѿ� ������ �׸��� ���� ������

	private AudioSource gunAudioPlayer; // �� �Ҹ� �����
	public AudioClip shotClip; // �߻� �Ҹ�
	public AudioClip reloadClip; // ������ �Ҹ�

	public float damage = 25; // ���ݷ�
	private float fireDistance = 50f; // �����Ÿ�

	public int ammoRemain = 100; // ���� ��ü ź��
	public int magCapacity = 6; // źâ �뷮
	public int magAmmo; // ���� źâ�� �����ִ� ź��


	public float timeBetFire = 0.12f; // �Ѿ� �߻� ����
	public float reloadTime = 1.8f; // ������ �ҿ� �ð�
	private float lastFireTime; // ���� ���������� �߻��� ����
	private void Awake()
	{
		// ����� ������Ʈ���� ������ ��������
		gunAudioPlayer = GetComponent<AudioSource>();
		bulletLineRenderer = GetComponent<LineRenderer>();

		bulletLineRenderer.positionCount = 2;
		bulletLineRenderer.enabled = false;
	}
	private void OnEnable()
	{
		// �� ���� �ʱ�ȭ
		magAmmo = magCapacity;
		state = State.Ready;
		lastFireTime = 0;
	}
	public void Fire()
	{
		if (state == State.Ready && Time.time >= lastFireTime + timeBetFire)
		{
			lastFireTime = Time.time;
			Shot();
		}
	}

	private void Shot()
	{
		RaycastHit hit;
		//Vector3 MousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
		Vector3 hitPosition = Vector3.zero;

		Vector3 mos = Input.mousePosition;
		mos.z = Camera.main.farClipPlane; // ī�޶� ���� �����, �þ߸� �����´�.

		Vector3 dir = Camera.main.ScreenToWorldPoint(mos);

		if (Physics.Raycast(Camera.main.transform.position, dir, out hit, fireDistance)) ///fireTransform.position
		{
			IDamageable target = hit.collider.GetComponent<IDamageable>();
			if (target != null)
			{
				target.OnDamage(damage, hit.point, hit.normal);
			}
			hitPosition = hit.point;
		}
		else
		{
			hitPosition = fireTransform.position + fireTransform.forward * fireDistance;
		}

		StartCoroutine(ShotEffect(hitPosition));

		magAmmo--;

		if (magAmmo <= 0)
		{
			state = State.Empty;
		}
	}

	private IEnumerator ShotEffect(Vector3 hitPosition)
	{
		muzzleFlashEffect.Play();
		shellEjectEffect.Play();
		// gunAudioPlayer.PlayOneShot(shotClip);
		bulletLineRenderer.SetPosition(0, fireTransform.position);
		bulletLineRenderer.SetPosition(1, hitPosition);
		// ���� �������� Ȱ��ȭ�Ͽ� �Ѿ� ������ �׸���
		bulletLineRenderer.enabled = true;

		// 0.03�� ���� ��� ó���� ���
		yield return new WaitForSeconds(0.03f);

		// ���� �������� ��Ȱ��ȭ�Ͽ� �Ѿ� ������ �����
		bulletLineRenderer.enabled = false;
	}
	public bool Reload()
	{
		if (state == State.Reloading || ammoRemain <= 0 || magAmmo >= magCapacity)
		{
			// �̹� ������ ���̰ų� ���� ź���� ���ų�
			// źâ�� ź���� �̹� ������ ��� �������� �� ����
			return false;
		}
		StartCoroutine(ReloadRoutine());
		return true;
	}
	private IEnumerator ReloadRoutine()
	{
		// ���� ���¸� ������ �� ���·� ��ȯ
		state = State.Reloading;

		//gunAudioPlayer.PlayOneShot(reloadClip);

		// ������ �ҿ� �ð� ��ŭ ó���� ����
		yield return new WaitForSeconds(reloadTime);

		int ammoToFill = magCapacity - magAmmo;

		if (ammoRemain < ammoToFill)
		{
			ammoToFill = ammoRemain;
		}

		magAmmo += ammoToFill;
		ammoRemain -= ammoToFill;
		// ���� ���� ���¸� �߻� �غ�� ���·� ����
		state = State.Ready;
	}

}
