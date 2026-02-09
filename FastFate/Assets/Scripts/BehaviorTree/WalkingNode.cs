using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * 1.5초마다 주위 범위 walkRange 이내의 랜덤한 공간으로 이동합니다.
 */
public class WalkingNode : BTNode
{
    private BlackBoard blackBoard;
    public WalkingNode(BlackBoard blackBoard)
    {
        this.blackBoard = blackBoard;
    }
    public override NodeState Evaluate()
    {
        if (blackBoard.waitTime > 0.0f)
        {
            blackBoard.waitTime -= Time.deltaTime;
            if (blackBoard.waitTime <= 0.0f)
            {
                Vector2 randomValue = Random.insideUnitCircle * blackBoard.walkRange;
                Vector3 destinationPosition = blackBoard.basePosition + new Vector3(randomValue.x, 0.0f, randomValue.y);
                blackBoard.characterMove.SetDestination(destinationPosition);
            }
        }
        else
        {
            if (blackBoard.characterMove.Arrived())
            {
                blackBoard.waitTime = Random.Range(blackBoard.waitBaseTime, blackBoard.waitBaseTime * 2.0f);
            }
            
        }
        return NodeState.Success;
    }

}
