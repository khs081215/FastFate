using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    public float manahave = 0f;
    public float manarecover = 0.8f;
    public float moneyhave = 0f;
    CardList _cardList;
    public GameObject canvas3;

    // Start is called before the first frame update
    void Start()
    {
        _cardList = GameObject.FindObjectOfType(typeof(CardList)) as CardList;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (manahave > 10) manahave = 10;
        else manahave += Time.deltaTime*manarecover;


    }
    //purchase하나로 바꾸기
    public void purchase1()
    { 
        if(moneyhave>=10.0f)
        {
            moneyhave -= 10.0f;
            _cardList.allCardList.Add(1);
        }
    }
    public void purchase2()
    {
            moneyhave += 10.0f;
            _cardList.allCardList.Add(2);
    }
    public void purchase3()
    {
        if (moneyhave >= 50.0f)
        {
            moneyhave -= 50.0f;
            _cardList.allCardList.Add(3);
        }
    }
    
    public void return1()
    {
        canvas3.SetActive(false);
    }
}
