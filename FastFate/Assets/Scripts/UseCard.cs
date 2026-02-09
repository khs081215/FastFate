using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * 해당 카드를 사용하여 효과를 나타냅니다.
 */
public class UseCard : MonoBehaviour
{
    public GameObject bufficon;
    public bool isSkill = false;
    public GameObject darksphere;
    public Camera mcamera, camera2, uicamera;
    public GameObject GUI;

    #region private member

    private CharacterStatus status;
    private Mana mana;
    private CardList _cardList;
    private PlayerMovemnetController _playerMovemnetController;
    private float rfTimer = 0.0f;
    private float maxrf = 5.0f;
    private float skillTimer = 0.0f;
    private float maxskill = 3.0f;
    private bool reinforce = false;
    private Animator animator;
    private GameObject lat;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        status = GetComponent<CharacterStatus>();
        _playerMovemnetController = GetComponent<PlayerMovemnetController>();
        mana = GameObject.FindObjectOfType(typeof(Mana)) as Mana;
        _cardList = GameObject.FindObjectOfType(typeof(CardList)) as CardList;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            switch (_cardList.nowCardList[0])
            {
                case 1:
                    if (mana.manahave >= 5.0f)
                    {
                        mana.manahave -= 5.0f;
                        if (reinforce) rfTimer += 5.0f;
                        reinforce = true;
                        _cardList.nowCardList.RemoveAt(0);
                        _cardList.Card();
                    }

                    break;
                case 2:
                    if (mana.manahave >= 1.0f)
                    {
                        mana.manahave -= 1.0f;
                        status.HP -= 10;
                        if (status.HP <= 0)
                        {
                            status.HP = 0;
                        }

                        _cardList.nowCardList.RemoveAt(0);
                        _cardList.Card();
                    }

                    break;
                case 3:
                    if (mana.manahave >= 10.0f)
                    {
                        mana.manahave -= 10.0f;
                        isSkill = true;
                        _cardList.nowCardList.RemoveAt(0);
                        _cardList.Card();
                    }

                    break;
                default:
                    break;
            }
        }

        lat = darksphere.GetComponent<CharacterStatus>().lastAttackTarget;
        if (status.lastAttackTarget == null && lat != null) status.lastAttackTarget = lat;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            _cardList.nowCardList.RemoveAt(0);
            _cardList.Card();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (mana.manahave >= 2.0f)
            {
                status.HP += 20;
                if (status.HP > 100) status.HP = 100;
                mana.manahave -= 2.0f;
            }
        }


        if (reinforce)
        {
            bufficon.SetActive(true);
            rfTimer += Time.deltaTime;
            status.Power = 20;
            if (rfTimer > maxrf)
            {
                reinforce = false;
                rfTimer = 0.0f;
                status.Power = 10;
                bufficon.SetActive(false);
            }
        }

        if (isSkill)
        {
            if (mcamera.enabled)
            {
                mcamera.enabled = false;
                camera2.enabled = true;
                uicamera.enabled = false;
                GUI.SetActive(false);
            }

            skillTimer += Time.deltaTime;
            animator.SetBool("isSkill", true);
            camera2.transform.RotateAround(transform.position, Vector3.up, 70.0f * Time.deltaTime);


            if (skillTimer > maxskill * 0.8f && darksphere.transform.position.y < 0)
            {
                darksphere.transform.position = transform.position + new Vector3(0f, 1.05f, 0f) +
                                                transform.TransformDirection(Vector3.forward);
                darksphere.transform.rotation = transform.rotation;
                darksphere.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward) * 10f;
            }

            if (skillTimer > maxskill)
            {
                isSkill = false;
                animator.SetBool("isSkill", false);
                skillTimer = 0.0f;
                camera2.transform.localPosition = new Vector3(0.127f, 1.622f, 0.763f);
                camera2.transform.localRotation = Quaternion.Euler(5.554f, -164.11f, -5.27f);
                camera2.enabled = false;
                mcamera.enabled = true;
                uicamera.enabled = true;
                GUI.SetActive(true);
            }
        }
    }
}