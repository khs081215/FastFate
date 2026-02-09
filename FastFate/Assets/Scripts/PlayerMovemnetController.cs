using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * 플레이어의 움직임과 전투를 관리합니다.
 */
public class PlayerMovemnetController : MonoBehaviour
{
    Vector3 recentMousePosition = new Vector3(0, 0, 0);
    Animator animator;
    float accel = 1.0f;
    bool isBackwalking = false;
    bool getSpace = false;
    bool istalking = false;
    bool isLeft = false;
    bool isRight = false;
    bool isAttack = false;
    CharacterStatus status;
    UseCard _useCard;
    MerchantDialog npcchara;

    Mana mana;


    // Start is called before the first frame update
    public void isDialog(bool istalk)
    {
        istalking = istalk;
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        status = GetComponent<CharacterStatus>();
        mana = GameObject.FindObjectOfType(typeof(Mana)) as Mana;
       _useCard = GameObject.FindObjectOfType(typeof(UseCard)) as UseCard;
        npcchara= GameObject.FindObjectOfType(typeof(MerchantDialog)) as MerchantDialog;
    }

    // Update is called once per frame
    void Update()
    {
        if (!npcchara.isdialog)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(0, 0, 2f * accel * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-2f * accel * Time.deltaTime, 0, 0);
                isLeft = true;
            }
            else isLeft = false;
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(0, 0, -2f * accel * Time.deltaTime);
                isBackwalking = true;
            }
            else isBackwalking = false;
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(2f * accel * Time.deltaTime, 0, 0);
                isRight = true;
            }
            else isRight = false;


            if (Input.GetKeyDown(KeyCode.Space) && mana.manahave > 2.0f)
            {
                if (animator.GetCurrentAnimatorStateInfo(0).IsName("RollForward") || animator.GetCurrentAnimatorStateInfo(0).IsName("RollLeft") || animator.GetCurrentAnimatorStateInfo(0).IsName("RollRight") || animator.GetCurrentAnimatorStateInfo(0).IsName("RollBackward"))
                {

                }
                else mana.manahave -= 2.0f;
                getSpace = true;
            }
            else getSpace = false;

            if (Input.GetButtonDown("Fire1"))
            {
                animator.SetBool("isAttack", true);
            }
            else animator.SetBool("isAttack", false);

            if (!_useCard.isSkill)
            {
                transform.Rotate(0, (Input.mousePosition.x - recentMousePosition.x) * 0.2f, 0, Space.World);
                recentMousePosition = Input.mousePosition;
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                accel = 2f;
            }
            else accel = 1.0f;

            if (animator.GetCurrentAnimatorStateInfo(0).IsName("RollForward") || animator.GetCurrentAnimatorStateInfo(0).IsName("RollLeft") || animator.GetCurrentAnimatorStateInfo(0).IsName("RollRight") || animator.GetCurrentAnimatorStateInfo(0).IsName("RollBackward"))
            {
                accel = 1.5f;
            }

            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Punchright") || _useCard.isSkill)
            {
                accel = 0f;
            }


            if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
            {
                animator.SetFloat("speed", 0);
            }
            else animator.SetFloat("speed", accel);





            if (isBackwalking)
            {
                animator.SetBool("isBackwalking", true);
            }
            else animator.SetBool("isBackwalking", false);

            if (getSpace && isRight)
            {
                animator.SetBool("getSpace1", true);
            }
            else if (getSpace && isLeft)
            {
                animator.SetBool("getSpace2", true);
            }
            else if (getSpace)
            {
                animator.SetBool("getSpace", true);
            }
            else
            {
                animator.SetBool("getSpace", false);
                animator.SetBool("getSpace1", false);
                animator.SetBool("getSpace2", false);
            }




        }
    }

       void Damage(AttackArea.AttackInfo attackInfo)
       {
            status.HP -= attackInfo.attackPower;
            if (status.HP <= 0)
            {
                status.HP = 0;
            }
        }
    

}
