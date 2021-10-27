using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCursor : MonoBehaviour
{

    Vector3 cursorPos;

    // Update is called once per frame
    void Update()
    {

        cursorPos = Input.mousePosition;
        cursorPos.z = Mathf.Abs(Camera.main.transform.position.z);
        cursorPos = Camera.main.ScreenToWorldPoint(cursorPos);

        transform.LookAt(cursorPos);
        
    }
}
