using UnityEngine;
using System.Collections;
/**
 * 자식 컴포넌트의 AttackArea를 공격시에만 유효로 만듭니다.
 */
public class AttackAreaActivator : MonoBehaviour {
	Collider[] attackAreaColliders;
	
	void Start () {
		AttackArea[] attackAreas = GetComponentsInChildren<AttackArea>();
		attackAreaColliders = new Collider[attackAreas.Length];
		//자식 컴포넌트의 모든 AttackArea를 수집합니다.
		for (int attackAreaCnt = 0; attackAreaCnt < attackAreas.Length; attackAreaCnt++) {
			attackAreaColliders[attackAreaCnt] = attackAreas[attackAreaCnt].GetComponent<Collider>();
			attackAreaColliders[attackAreaCnt].enabled = false;
		}
	}
	
	/// StartAttackHit로 콜리전을 유효로 합니다.
	void StartAttackHit()
	{
		Debug.Log("StartAttack");
		foreach (Collider attackAreaCollider in attackAreaColliders)
			attackAreaCollider.enabled = true;
	}
	
	/// EndAttackHit로 콜리전을 무효로 합니다..
	void EndAttackHit()
	{
		foreach (Collider attackAreaCollider in attackAreaColliders)
			attackAreaCollider.enabled = false;
	}
}
