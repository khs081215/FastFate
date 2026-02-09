using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * 커서가 화면 밖으로 나가지 못하도록 합니다.
 */
public class Confinedcursor : MonoBehaviour
{
    // Start is called before the first frame update
  
    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Confined;
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
    }
}
