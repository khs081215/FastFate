using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/**
 * 플레이어가 가지는 전체 카드 목록을 표시합니다.
 */
public class CardListView : MonoBehaviour
{
    public GameObject canvas;
    public Transform contview;
    public Texture[] referenceimg;

    private CardList cardList;
    private bool isActivated = false;
    private int i;

    // Start is called before the first frame update
    void Start()
    {
        cardList = GameObject.FindObjectOfType(typeof(CardList)) as CardList;
    }

    // Update is called once per frame
    public void ToggleViewAllCardList()
    {
        Debug.Log("card");
        if (isActivated)
        {
            canvas.SetActive(false);
            isActivated = false;
        }
        else
        {
            canvas.SetActive(true);
            isActivated = true;
            for (i = 0; i < cardList.allCardList.Count; i++)
            {
                contview.GetChild(i).gameObject.SetActive(true);
                contview.GetChild(i).gameObject.GetComponent<RawImage>().texture =
                    referenceimg[cardList.allCardList[i] - 1];
            }
        }
    }
}