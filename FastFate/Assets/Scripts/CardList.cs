using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.Serialization;
/**
 * 플레이어의 전체 카드 리스트와, 손에 들고있는 3장의 카드 리스트를 관리합니다.
 */
public class CardList : MonoBehaviour
{ 
    public List<int> allCardList = new List<int>();
    public List<int> nowCardList = new List<int>();
    public RawImage firstCard;
    public RawImage secondCard;
    public RawImage lastCard;
    public Texture[] referenceImg;

    private int buffer1 = 0;
    private int buffer2 = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        allCardList.Add(1);
        allCardList.Add(2);
        allCardList.Add(3);
        nowCardList = Shuffle(allCardList).ToList();
        firstCard.texture = referenceImg[nowCardList[0] - 1];
        secondCard.texture = referenceImg[nowCardList[1] - 1];
        lastCard.texture = referenceImg[nowCardList[2] - 1];
    }

    // Update is called once per frame
    public void Card()
    {
        if (nowCardList.Count == 2)
        {
            buffer1 = nowCardList[0];
            buffer2 = nowCardList[1];
            nowCardList.AddRange(Shuffle(allCardList).ToList());
        }
        firstCard.texture = referenceImg[nowCardList[0]-1];
        secondCard.texture = referenceImg[nowCardList[1]-1];
        lastCard.texture = referenceImg[nowCardList[2]-1];
    }
    public static List<int> Shuffle(List<int> values)
    {
        System.Random rand = new System.Random();
        List<int> shuffled = values.OrderBy(_ => rand.Next()).ToList();
        Debug.Log(shuffled);

        return shuffled;
    }
}
