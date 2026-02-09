using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/**
 * 보스 몬스터의 2번째 페이즈를 관리합니다.
 */
public class SecondPhase : MonoBehaviour
{
    public GameObject dragon, sam, dragon4, sam4;
    public GameObject GUI1, GUI2;
    public Camera mcamera, camera2, skillcamera, dragoncamera, samcamera;
    public GameObject img, dasa1, dasa2;
    public GameObject player;

    private int delcnt = 0;
    private float timer = 0.0f;
    private Color color;
    private bool isnextphase = false;

    // Start is called before the first frame update
    void Start()
    {
        color = img.GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<CharacterStatus>().HP == 0)
        {
            Application.LoadLevel("dead");
        }
        if (!isnextphase && dragon.GetComponent<CharacterStatus>().HP < 300)
        {
            if (delcnt == 0)
            {
                mcamera.enabled = false;
                camera2.enabled = false;
                skillcamera.enabled = false;
                GUI1.SetActive(false);
                GUI2.SetActive(false);
                GameObject.Find("Dragon").SetActive(false);
                dragon4.SetActive(true);
                delcnt++;
            }

            if (delcnt == 1)
            {
                timer += Time.deltaTime;
                if (timer > 3.0f)
                {
                    timer = 0f;
                    delcnt++;
                }
                else
                {
                    color.a = (timer / 3.0f);
                    img.GetComponent<Image>().color = color;
                }

                if (timer > 0.5f) dasa1.SetActive(true);
            }

            if (delcnt == 2)
            {
                dragoncamera.enabled = false;
                sam4.SetActive(true);
                dragon4.SetActive(false);


                delcnt++;
            }

            if (delcnt == 3)
            {
                timer += Time.deltaTime;
                if (timer > 5.0f)
                {
                    timer = 0f;
                    delcnt++;
                }
                else
                {
                    color.a = 1.0f - (timer / 5.0f);
                    img.GetComponent<Image>().color = color;
                }

                if (timer > 3.0f) dasa1.SetActive(false);
            }

            if (delcnt == 4)
            {
                sam4.SetActive(false);
                sam.SetActive(true);
                mcamera.enabled = true;
                camera2.enabled = true;
                skillcamera.enabled = true;
                GUI1.SetActive(true);
                isnextphase = true;
                GUI2.SetActive(true);
                delcnt++;
            }
        }

        if (isnextphase && sam.GetComponent<CharacterStatus>().HP == 0)
        {
            if (delcnt == 5)
            {
                timer += Time.deltaTime;
                if (timer > 1.0f)
                {
                    timer = 0f;
                    delcnt++;
                }
                else
                {
                    color.a = (timer / 1.0f);
                    img.GetComponent<Image>().color = color;
                }
            }

            if (delcnt == 6)
            {
                GUI1.SetActive(false);
                GUI2.SetActive(false);
                camera2.enabled = false;
                dasa2.SetActive(true);
                timer += Time.deltaTime;
                if (timer > 5.0f)
                {
                    timer = 0f;
                    delcnt++;
                }
            }

            if (delcnt == 7)
            {
                Application.LoadLevel("cgs final");
            }
        }
    }
}