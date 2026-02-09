using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * 적의 HP가 0 이하일 경우 골드를 10원 드랍하고 죽습니다.
 */
public class DiedNode : BTNode
{
    private BlackBoard blackBoard;
    public DiedNode(BlackBoard blackBoard)
    {
        this.blackBoard = blackBoard;
    }

    private bool CheckDied()
    {
        if (blackBoard.status.HP <= 0)
        {
            return true;
        }
        return false;
    }
    private void DropItem()
    {
        blackBoard.mana.moneyhave += 10.0f;
    }
    private void Died()
    {
        blackBoard.status.died=true;
        DropItem();
    }
    
    public override NodeState Evaluate()
    {
        if (CheckDied())
        {
            Died();
            Debug.Log("Died Success");
            return NodeState.Success;
        }
        return NodeState.Failure;
    }

}
