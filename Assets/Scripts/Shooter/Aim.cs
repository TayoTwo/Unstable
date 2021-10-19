using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    
    Vector3 cursorPos;

    void Update() {

        CursorLook();
        
    }
    
    void CursorLook(){

        cursorPos = Input.mousePosition;
        cursorPos.z = 10.0f;
        cursorPos = Camera.main.ScreenToWorldPoint(cursorPos);
        cursorPos = new Vector3(cursorPos.x,transform.position.y,cursorPos.z);

        transform.LookAt(cursorPos);

    }

}
