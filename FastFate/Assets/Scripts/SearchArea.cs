using UnityEngine;
using System.Collections;
/**
 * 적 캐릭터가 감지가능한 범위를 표시합니다.
 */
public class SearchArea : MonoBehaviour {
	//private EnemyCtrl enemyCtrl;
	private EnemyCtrlbyBT enemyCtrlbyBT;
	void Awake()
	{
		enemyCtrlbyBT = GetComponentInParent<EnemyCtrlbyBT>();
	}
	
	void OnTriggerStay( Collider other )
	{
		if (other.tag == "Player")
		{
			enemyCtrlbyBT.SetAttackTarget(other.transform);
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			enemyCtrlbyBT.SetAttackTarget(null);
		}
	}
}
