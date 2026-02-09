
using UnityEngine;
using System.Collections;
/**
 * 충돌판정을 만드는 공격 콜리전입니다.
 */
public class AttackArea : MonoBehaviour {
	private CharacterStatus status;
	private Coroutine damageCoroutine;
	
	private void Start()
	{
		status = transform.root.GetComponent<CharacterStatus>();
	}
	
	public class AttackInfo
	{
		public int attackPower; 
		public Transform attacker;
	}
	
	private AttackInfo GetAttackInfo()
	{			
		AttackInfo attackInfo = new AttackInfo();
		attackInfo.attackPower = status.Power;
		attackInfo.attacker = transform.root;
		return attackInfo;
	}
	
	private void OnTriggerEnter(Collider other)
	{
		other.SendMessage("Damage",GetAttackInfo());
		status.lastAttackTarget = other.transform.root.gameObject;
	}
	private void OnTriggerExit(Collider other)
    {
		HitArea hitarea = other.gameObject.GetComponent<HitArea>();
		if (damageCoroutine != null)
		{
			StopCoroutine(damageCoroutine);
			damageCoroutine = null;
		}
	}
	
	private void OnAttack()
	{
		GetComponent<Collider>().enabled = true;
	}
	
	private void OnAttackTermination()
	{
		GetComponent<Collider>().enabled = false;
		
		if (damageCoroutine != null)
		{
			StopCoroutine(damageCoroutine);
			damageCoroutine = null;
		}
	}
}
