using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Player의 애니메이션을 관리합니다.
 */
public class PlayerAnimation : MonoBehaviour
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

		if (attacked)
		{
			attacked = false;
		}

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

	void StartAttackHit()
	{
		Debug.Log("StartAttackHit");
	}

	void EndAttackHit()
	{
		Debug.Log("EndAttackHit");
	}

	void EndAttack()
	{
		attacked = true;
	}


}
