using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToCursor : MonoBehaviour
{

    public float cursorPullStrength;
    Vector3 cursorPos;
    Vector3 targetPos;
    Vector3 forceDir;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update(){

        CursorLook();
        
    }

    void FixedUpdate() {
        
        Move();

    }

    void CursorLook(){

        cursorPos = Input.mousePosition;
        cursorPos.z = 10.0f;
        cursorPos = Camera.main.ScreenToWorldPoint(cursorPos);

        transform.LookAt(cursorPos);

    }

    void Move(){

        targetPos = new Vector3(0,cursorPos.y,0);
        forceDir = (targetPos - transform.position).normalized;

        rb.AddForce(transform.forward * cursorPullStrength);

    }
}
