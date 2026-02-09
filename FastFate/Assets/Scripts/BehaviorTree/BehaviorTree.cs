using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * 노드 평가의 종류입니다.
 */
public enum NodeState
{
    Success,
    Failure
}
/**
 * Behavior Tree 추상 클래스로, 루트 노드 아래에 Selector가 존재하는 형태입니다.
 */
public abstract class BehaviorTree
{
    protected List<BTNode> nodeInTree;
    
    public abstract void SetupBT(BlackBoard blackBoard);

    public virtual NodeState Evaluate()
    {
        foreach (BTNode node in nodeInTree)
        {
            //셀렉터 구현(자식 노드 중 1개라도 성공하면 즉시 성공 반환)
            if (node.Evaluate() == NodeState.Success) return NodeState.Success;
        }
        return NodeState.Failure;
    }
}
