using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 상인과 대화하여 카드를 구매할 수 있습니다.
 */
public class MerchantDialog : MonoBehaviour
{
    #region 
    public Transform player;
    float distance = 0;
    bool talkposs = false;
    int count = 0;
    public bool isdialog = false;
    public GameObject other;
    Animator animator;
    public Transform talkparent;
    GameObject talk;
    public GameObject cg;
    public GameObject name;
    public Transform dialog;
    public GameObject canvas3;
    #endregion
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(new Vector2(transform.position.x, transform.position.z),
            new Vector2(player.position.x, player.position.z));
        if (distance < 1) talkposs = true;
        if (talkposs)
        {
            talk = talkparent.GetChild(0).gameObject;
            talk.SetActive(true);
        }

        if (talkposs && distance >= 1)
        {
            talk = talkparent.GetChild(0).gameObject;
            talk.SetActive(false);
            talkposs = false;
        }

        if (talkposs && Input.GetKeyDown(KeyCode.F))
        {
            talk.SetActive(false);
            talkposs = false;
            isdialog = true;
        }

        if (isdialog)
        {
            talk.SetActive(false);
            other.GetComponent<PlayerMovemnetController>().isDialog(isdialog);
            animator.SetBool("isDialog", isdialog);
            GameObject dialogbar = GameObject.Find("Canvas").transform.Find("dialogbar").gameObject;
            if (dialogbar == null) return;
            dialogbar.SetActive(true);
            cg.SetActive(true);
            name.SetActive(true);
            if (count == 0) dialog.GetChild(count).gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                dialog.GetChild(count).gameObject.SetActive(false);
                count++;
                //Debug.Log("count :"+ count+" dialog.childcount : "+dialog.childCount);
                if (count >= dialog.childCount)
                {
                    canvas3.SetActive(true);
                    count = 0;
                    dialogbar.SetActive(false);
                    cg.SetActive(false);
                    name.SetActive(false);
                    isdialog = false;
                    other.GetComponent<PlayerMovemnetController>().isDialog(isdialog);
                    animator.SetBool("isDialog", isdialog);
                }
                else dialog.GetChild(count).gameObject.SetActive(true);
            }
        }
    }
}