using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * 플레이어가 SearchArea에 들어오면 플레이어를 추적합니다.
 */
public class ChasingNode : BTNode
{
    private BlackBoard blackBoard;
    public ChasingNode(BlackBoard blackBoard)
    {
        this.blackBoard = blackBoard;
    }
    //SearchArea에서 범위내에 플레이어가 들어오면 attackTarget으로 넘겨주어 true를 반환합니다.
    private bool CheckCanChase()
    {
        if (blackBoard.attackTarget)
        {
            return true;
        }
        return false;
    }
    
    public override NodeState Evaluate()
    {
        if (CheckCanChase())
        {
            blackBoard.characterMove.SetDestination(blackBoard.attackTarget.position);
            return NodeState.Success;
        }
        return NodeState.Failure;
    }

}