using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * 검은 구체 스킬을 사용합니다.
 */
public class DarksphereSkill : MonoBehaviour
{
    private float remain = 5.0f;
    private float timeBuff = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 0)
        {
            timeBuff += Time.deltaTime;
            if(timeBuff>remain)
            {
                transform.position = new Vector3(0.8f, -1.05f, 0f);
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                timeBuff = 0.0f;
            }
        }
    }
}
