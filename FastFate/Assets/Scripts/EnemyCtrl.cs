using UnityEngine;
using System.Collections;

/**
 * 적 캐릭터의 상태를 Walking, Chasing, Attacking, Died 4개의 enum으로 나타내는 FSM 입니다.
 */
public class EnemyCtrl : MonoBehaviour
{
    CharacterStatus status;
    CharacterAnimation _characterAnimation;
    CharacterMove characterMove;
    Transform attackTarget;
    Mana mana;
    public bool isdiedactivate = false;

    public float waitBaseTime = 0.2f;
    float waitTime;
    public float walkRange = 5.0f;
    public Vector3 basePosition;

    enum State
    {
        Walking,
        Chasing,
        Attacking,
        Died,
    };

    State state = State.Walking;
    State nextState = State.Walking;


    // Use this for initialization
    void Start()
    {
        status = GetComponent<CharacterStatus>();
        _characterAnimation = GetComponent<CharacterAnimation>();
        characterMove = GetComponent<CharacterMove>();
        basePosition = transform.position;
        waitTime = waitBaseTime;
        mana = GameObject.FindObjectOfType(typeof(Mana)) as Mana;
    }

    void Update()
    {
        switch (state)
        {
            case State.Walking:
                Walking();
                break;
            case State.Chasing:
                Chasing();
                break;
            case State.Attacking:
                Attacking();
                break;
        }

        if (state != nextState)
        {
            state = nextState;
            switch (state)
            {
                case State.Walking:
                    WalkStart();
                    break;
                case State.Chasing:
                    ChaseStart();
                    break;
                case State.Attacking:
                    AttackStart();
                    break;
                case State.Died:
                    Died();
                    break;
            }
        }
    }


    void ChangeState(State nextState)
    {
        this.nextState = nextState;
    }

    void WalkStart()
    {
        StateStartCommon();
    }

    void Walking()
    {
        if (waitTime > 0.0f)
        {
            waitTime -= Time.deltaTime;
            if (waitTime <= 0.0f)
            {
                Vector2 randomValue = Random.insideUnitCircle * walkRange;
                Vector3 destinationPosition = basePosition + new Vector3(randomValue.x, 0.0f, randomValue.y);
                SendMessage("SetDestination", destinationPosition);
            }
        }
        else
        {
            if (characterMove.Arrived())
            {
                waitTime = Random.Range(waitBaseTime, waitBaseTime * 2.0f);
            }

            if (attackTarget)
            {
                ChangeState(State.Chasing);
            }
        }
    }

    void ChaseStart()
    {
        StateStartCommon();
    }

    void Chasing()
    {
        SendMessage("SetDestination", attackTarget.position);
        if (Vector3.Distance(attackTarget.position, transform.position) <= 2.0f)
        {
            ChangeState(State.Attacking);
        }
    }

    void AttackStart()
    {
        StateStartCommon();
        status.attacking = true;

        Vector3 targetDirection = (attackTarget.position - transform.position).normalized;
        SendMessage("SetDirection", targetDirection);

        SendMessage("StopMove");
    }

    void Attacking()
    {
        if (_characterAnimation.IsAttacked())
            ChangeState(State.Walking);
        waitTime = Random.Range(waitBaseTime, waitBaseTime * 2.0f);
        attackTarget = null;
    }

    void dropItem()
    {
        mana.moneyhave += 10.0f;
    }

    void Died()
    {
        status.died = true;
        dropItem();
        if (!isdiedactivate) Destroy(gameObject);
    }

    void Damage(AttackArea.AttackInfo attackInfo)
    {
        status.HP -= attackInfo.attackPower;
        if (status.HP <= 0)
        {
            status.HP = 0;
            ChangeState(State.Died);
        }
    }

    void StateStartCommon()
    {
        status.attacking = false;
        status.died = false;
    }

    public void SetAttackTarget(Transform target)
    {
        attackTarget = target;
    }
}