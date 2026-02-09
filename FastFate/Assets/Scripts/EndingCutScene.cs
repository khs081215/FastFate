using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * 엔딩 컷씬을 재생합니다.
 */
public class EndingCutScene : MonoBehaviour
{
    public Camera mcamera;
    public GameObject dasa1, dasa2, dasa3, dasa4, dasa5, dasa6,img2;
    int delcnt = 0;
    float timer = 0.0f;
    
    // Update is called once per frame
    void Update()
    {
        if(delcnt==0)
        {
            dasa1.SetActive(true);
            timer += Time.deltaTime;
            if (timer > 4)
            {
                timer = 0f;
                dasa1.SetActive(false);
                delcnt++;
            }
        }
        if (delcnt == 1)
        {
            dasa2.SetActive(true);
            timer += Time.deltaTime;
            if (timer > 4)
            {
                timer = 0f;
                dasa2.SetActive(false);
                delcnt++;
            }
        }
        if (delcnt == 2)
        {
            dasa3.SetActive(true);
            timer += Time.deltaTime;
            if (timer > 4)
            {
                timer = 0f;
                dasa3.SetActive(false);
                delcnt++;
            }
        }
        if (delcnt == 3)
        {
            dasa4.SetActive(true);
            timer += Time.deltaTime;
            if (timer > 4)
            {
                timer = 0f;
                dasa4.SetActive(false);
                delcnt++;
            }
        }
        if (delcnt == 4)
        {
            dasa5.SetActive(true);
            timer += Time.deltaTime;
            if (timer > 4)
            {
                dasa5.SetActive(false);
                timer = 0f;
                delcnt++;
            }
        }

        if (delcnt == 5)
        {
            dasa6.SetActive(true);
            timer += Time.deltaTime;
            if (timer > 4)
            {
                timer = 0f;
                delcnt++;
            }
        }



        if (delcnt == 6)
        {
            mcamera.enabled = false;
            img2.SetActive(true);
        }

    }
}
