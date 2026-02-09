using UnityEngine;
using System.Collections;
/**
 * 플레이어 캐릭터, 적 캐릭터의 스테이터스 정보를 저장한다.
 */
public class CharacterStatus : MonoBehaviour {
	
	public int HP = 100;
	public int MaxHP = 100;
	
	public int Power = 10;
	
	public GameObject lastAttackTarget = null;
	
	public string characterName = "Player";
	
	public bool attacking = false;
	public bool died = false;
}
