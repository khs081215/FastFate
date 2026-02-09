using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * 실제 적용한 BT로, 4개의 노드를 셀렉터의 자식 노드로 배치하였습니다.
 */
public class EnemyBehaviorTree : BehaviorTree
{
    public override void SetupBT(BlackBoard blackBoard)
    {
        nodeInTree = new List<BTNode>
        {
            new DiedNode(blackBoard),
            new AttackingNode(blackBoard),
            new ChasingNode(blackBoard),
            new WalkingNode(blackBoard)
        };
    }
    public override NodeState Evaluate()
    {
        return base.Evaluate();
    }
}
