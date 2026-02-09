using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Behavior Tree의 각 노드가 참조가능한 블랙보드입니다.
 */
public class BlackBoard
{
    public GameObject Enemy{get; set;}
    public CharacterStatus status { get; set; }
    public CharacterAnimation _characterAnimation{ get; set; }
    public CharacterMove characterMove{ get; set; }
    public Transform attackTarget{ get; set; }
    public Mana mana { get; set; }
    public bool isdiedactivate{ get; set; } = false;
    public float waitBaseTime{ get; set; } = 1.5f;
    public float waitTime{ get; set; }
    public float walkRange{ get; set; } = 5.0f;
    public Vector3 basePosition{ get; set; }=Vector3.zero;
    public CharacterMove CharacterMove;
    public float attackDelayTime=0.0f;
}
