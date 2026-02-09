using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * 플레이어의 공격시에만 Attackarea를 활성화하고, Roll할때만 HitBox를 없앱니다.
 */
public class PlayerCombatarea : MonoBehaviour
{
	private Collider[] attackAreaColliders;
	private Collider[] hitAreaColliders;

	void Start()
	{
		AttackArea[] attackAreas = GetComponentsInChildren<AttackArea>();
		attackAreaColliders = new Collider[attackAreas.Length];

		HitArea[] hitAreas = GetComponentsInChildren<HitArea>();
		hitAreaColliders = new Collider[hitAreas.Length];

		for (int attackAreaCnt = 0; attackAreaCnt < attackAreas.Length; attackAreaCnt++)
		{
			attackAreaColliders[attackAreaCnt] = attackAreas[attackAreaCnt].GetComponent<Collider>();
			attackAreaColliders[attackAreaCnt].enabled = false;  // 초깃값은 false로 한다.
		}
		for (int attackAreaCnt = 0; attackAreaCnt < hitAreas.Length; attackAreaCnt++)
		{
			hitAreaColliders[attackAreaCnt] = hitAreas[attackAreaCnt].GetComponent<Collider>();
			Debug.Log(hitAreaColliders[0].name);
		}
	}
	
	void StartAttackHit()
	{
		Debug.Log("StartAttack");
		foreach (Collider attackAreaCollider in attackAreaColliders)
			attackAreaCollider.enabled = true;
	}
	
	void EndAttackHit()
	{
		foreach (Collider attackAreaCollider in attackAreaColliders)
			attackAreaCollider.enabled = false;
	}

	void RollStart()
    {
		Debug.Log("roll");
		foreach (Collider attackAreaCollider in hitAreaColliders)
			attackAreaCollider.enabled =false;
	}
	void RollEnd()
	{
		Debug.Log("rollend");
		foreach (Collider attackAreaCollider in hitAreaColliders)
			attackAreaCollider.enabled = true;
	}


}
