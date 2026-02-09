using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * (사망UI에서 버튼 입력시) 초기 화면으로 이동합니다.
 */
public class DeadReset : MonoBehaviour
{
    // Update is called once per frame
    public void OnClickButton()
    {
        Application.LoadLevel("cgs initScene");
    }
}
