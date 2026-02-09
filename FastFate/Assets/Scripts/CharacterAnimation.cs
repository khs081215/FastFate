using UnityEngine;
/**
 * 적 캐릭터의 애니메이션을 표시합니다.
 */
public class CharacterAnimation : MonoBehaviour
{
	private Animator animator;
	private CharacterStatus status;
	private Vector3 prePosition;
	private bool isDown = false;
	private bool attacked = false;
	
	void Start()
	{
		animator = GetComponent<Animator>();
		status = GetComponent<CharacterStatus>();

		prePosition = transform.position;
	}
	
	void Update()
	{
		Vector3 delta_position = transform.position - prePosition;
		animator.SetFloat("Speed", delta_position.magnitude / Time.deltaTime);

		if (attacked && !status.attacking)
		{
			attacked = false;
		}
		animator.SetBool("Attacking", (!attacked && status.attacking));

		if (!isDown && status.died)
		{
			isDown = true;
			animator.SetTrigger("Down");
		}

		prePosition = transform.position;
	}
	
	public bool IsAttacked()
	{
		return attacked;
	}
	
	void EndAttack()
	{
		attacked = true;
	}



	
}