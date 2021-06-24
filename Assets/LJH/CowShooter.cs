using UnityEngine;

// �־��� Gun ������Ʈ�� ��ų� ������
// �˸��� �ִϸ��̼��� ����ϰ� IK�� ����� ĳ���� ����� �ѿ� ��ġ�ϵ��� ����
public class CowShooter : MonoBehaviour
{
	public CowGun gun; // ����� ��
	public Transform gunPivot; // �� ��ġ�� ������
	public Transform leftHandMount; // ���� ���� ������, �޼��� ��ġ�� ����
	public Transform rightHandMount; // ���� ������ ������, �������� ��ġ�� ����

	private CowPlayerInput playerInput; // �÷��̾��� �Է�
	private Animator playerAnimator; // �ִϸ����� ������Ʈ

	private void Start()
	{
		// ����� ������Ʈ���� ��������
		playerInput = GetComponent<CowPlayerInput>();
		playerAnimator = GetComponent<Animator>();
	}

	private void OnEnable()
	{
		// ���Ͱ� Ȱ��ȭ�� �� �ѵ� �Բ� Ȱ��ȭ
		gun.gameObject.SetActive(true);
	}

	private void OnDisable()
	{
		// ���Ͱ� ��Ȱ��ȭ�� �� �ѵ� �Բ� ��Ȱ��ȭ
		gun.gameObject.SetActive(false);
	}

	private void Update()
	{
		// �Է��� �����ϰ� �� �߻��ϰų� ������
		if (playerInput.fire)
		{
			gun.Fire();
		}
		else if (playerInput.Reload)
		{
			if (gun.Reload())
			{
				playerAnimator.SetTrigger("Reload");
			}
		}
		//UpdateUI();
	}

	// ź�� UI ����
	//private void UpdateUI()
	//{
	//    if (gun != null && UIManager.instance != null)
	//    {
	//        // UI �Ŵ����� ź�� �ؽ�Ʈ�� źâ�� ź��� ���� ��ü ź���� ǥ��
	//        UIManager.instance.UpdateAmmoText(gun.magAmmo, gun.ammoRemain);
	//    }
	//}

	// �ִϸ������� IK ����
	private void OnAnimatorIK(int layerIndex)
	{
		gunPivot.position = playerAnimator.GetIKHintPosition(AvatarIKHint.RightElbow);

		playerAnimator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1.0f);
		playerAnimator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1.0f);

		playerAnimator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandMount.position);
		playerAnimator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandMount.position);

		playerAnimator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1.0f);
		playerAnimator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1.0f);

		playerAnimator.SetIKPosition(AvatarIKGoal.RightHand, rightHandMount.position);
		playerAnimator.SetIKPosition(AvatarIKGoal.RightHand, rightHandMount.position);

	}
}

