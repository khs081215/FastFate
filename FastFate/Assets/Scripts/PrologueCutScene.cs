using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/**
 * 프롤로그 컷씬을 재생합니다.
 */
public class PrologueCutScene : MonoBehaviour
{
    public Camera mcamera,camera2,camera3;
    public GameObject player;
    public GameObject dragon;
    public GameObject princess;
    public GameObject img,dasa1,dasa2;
    
    private float timer = 0.0f;
    private Animator playeranim, dragonanim;
    private int delcnt = 0;
    private Color color;
    
    // Start is called before the first frame update
    void Start()
    {
        playeranim = player.GetComponent<Animator>();
        dragonanim= dragon.GetComponent<Animator>();
        color = img.GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if(delcnt==0)
        {

            mcamera.transform.Rotate(0,-5.0f * Time.deltaTime,0);
            timer += Time.deltaTime;
            if (timer > 10)
            {
                timer = 0f;
                delcnt++;
            }
        }
        if (delcnt == 1)
        {
            if(mcamera.enabled) mcamera.enabled = false;
            camera2.transform.Translate(-1.2f * Time.deltaTime, 0, -4f*Time.deltaTime);
            if(camera2.transform.position.x<(-3.79f)&&camera2.transform.position.z<3.17f)
            {
                camera2.transform.position = new Vector3(-3.79f,2f,3.17f);
                timer = 0f;
                delcnt++;
            }
        }
        if(delcnt==2)
        {
            dragonanim.SetFloat("Speed", 0.2f);
            dragon.transform.Rotate(0, -60.0f * Time.deltaTime, 0);
            princess.transform.Rotate(0, -60.0f * Time.deltaTime, 0);
            if (dragon.transform.rotation.y < 0)
            {
                dragon.transform.rotation = Quaternion.Euler(0, 0, 0);
                princess.transform.rotation = Quaternion.Euler(0, 0, 0);
                dragon.transform.Translate(0, 0, 4f * Time.deltaTime);
                princess.transform.Translate(0, 0, 2f * Time.deltaTime);
            }
            if(dragon.transform.position.z>40)
            {
                timer = 0f;
                delcnt++;
            }
        }
        if(delcnt==3)
        {
            timer += Time.deltaTime;
            if (timer > 5.0f)
            {
                timer = 0f;
                camera2.transform.position = new Vector3(22.9f, 0.669f, 0.18f);
                camera2.transform.rotation = Quaternion.Euler(-64.43f,90f,-90f);
                dragonanim.SetFloat("Speed", 0.0f);
                delcnt++;
            }
                else {
                      color.a = timer / 5.0f;
                    img.GetComponent<Image>().color = color;
                camera2.transform.Rotate( -18.0f * Time.deltaTime, 0,0);
            }
            
        }

        if (delcnt == 4)
        {
            timer += Time.deltaTime;
            dasa1.SetActive(true);
            if (timer > 5.0f)
            {
                timer = 0f;
                dasa1.SetActive(false);
                delcnt++;
            }
        }

        if (delcnt==5)
        {
            timer += Time.deltaTime;
            if (timer > 5.0f)
            {

                timer = 0f;
                delcnt++;
            }
            else
            {
                color.a = 1.0f- (timer / 5.0f);
                img.GetComponent<Image>().color = color;
            }
            if(timer>3.0f) dasa2.SetActive(true);
        }

        if (delcnt == 6)
        {
            
            timer += Time.deltaTime;
            if(camera2.enabled)
            {
                camera2.enabled=false;

            }
            
            if (timer > 5.0f)
            {
                dasa2.SetActive(false);
                Application.LoadLevel("cgs initscene");
            }
        }

    }
}
