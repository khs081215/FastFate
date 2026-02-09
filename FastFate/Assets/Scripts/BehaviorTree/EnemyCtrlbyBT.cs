using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * BT를 통해 적의 AI를 컨트롤합니다.
 */
public class EnemyCtrlbyBT : MonoBehaviour
{
    private BlackBoard blackBoard;
    private EnemyBehaviorTree enemyBT;
    
    //노드가 다른 코드가 아닌 블랙보드만 볼 수 있게끔 블랙보드에 값을 넣어줍니다.
    void Awake()
    {
        blackBoard = new BlackBoard();
        enemyBT = new EnemyBehaviorTree();
        
        blackBoard.Enemy = gameObject;
        blackBoard.status = GetComponent<CharacterStatus>();
        blackBoard._characterAnimation = GetComponent<CharacterAnimation>();
        blackBoard.characterMove = GetComponent<CharacterMove>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        blackBoard.basePosition = transform.position;
        blackBoard.waitTime = blackBoard.waitBaseTime;
        blackBoard.mana = GameObject.FindObjectOfType(typeof(Mana)) as Mana;
        enemyBT.SetupBT(blackBoard);
    }

    // Update is called once per frame
    void Update()
    {
        enemyBT.Evaluate();
        
        if (blackBoard.status.died == true)
        {
            Destroy(gameObject);
        }
    }
    public void Damage(AttackArea.AttackInfo attackInfo)
    {
        if (blackBoard == null || blackBoard.status == null) 
        {
            return; 
        }
        blackBoard.status.HP -= attackInfo.attackPower;
        Debug.Log(blackBoard.status.HP);
    }
    public void SetAttackTarget(Transform target)
    {
        blackBoard.attackTarget = target;
    }
}
