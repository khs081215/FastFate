using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * 플레이어와 적과의 거리가 5.0 보다 가까우면 공격합니다. 
 */
public class AttackingNode : BTNode
{
    private BlackBoard blackBoard;
    public AttackingNode(BlackBoard blackBoard)
    {
        this.blackBoard = blackBoard;
    }

    private bool CheckCanAttack()
    {
        if (!blackBoard.attackTarget)
        {
            return false;
        }
        if (Vector3.Distance(blackBoard.attackTarget.position, blackBoard.Enemy.transform.position) <= 5.0f)
        {
            return true;
        }
        return false;
    }
    
    private bool CheckDelay()
    {
        blackBoard.attackDelayTime += Time.deltaTime;
        if (blackBoard.attackDelayTime > blackBoard.waitBaseTime)
        {
            blackBoard.attackDelayTime = 0.0f;
            return true;
        }
        else return false;
    }
    
    
    public override NodeState Evaluate()
    {
        //공격 가능한 경우
        if (CheckCanAttack())
        {
            //이미 공격을 진행한 경우 누적 1.5초동안 대기합니다.
            if (blackBoard._characterAnimation.IsAttacked())
            {
                if (CheckDelay())
                {
                    blackBoard.status.attacking = false;
                }
            }
            //공격을 하지 않은 경우 즉시 공격합니다.
            else
            {
                blackBoard.status.attacking = true;
                Vector3 targetDirection = (blackBoard.attackTarget.position - blackBoard.Enemy.transform.position).normalized;
                blackBoard.characterMove.SetDirection(targetDirection);
                blackBoard.characterMove.StopMove();
            }
            return NodeState.Success;
        }
        //공격을 이미 하였으면, 플레이어가 멀어지더라도 누적 1.5초동안 대기 후 Behavior를 전환합니다.
        if (blackBoard.attackDelayTime > 0.0f&&!CheckDelay())
        {
            return NodeState.Success;
        }
        return NodeState.Failure;
    }

}
