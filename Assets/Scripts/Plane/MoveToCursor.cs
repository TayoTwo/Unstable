using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToCursor : MonoBehaviour
{

    public float thrust;
    public float torque;

    
    public float idealDis;
    public Transform target;
    Vector3 cursorPos;
    Vector3 targetPos;
    Vector3 forceDir;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        
    }

    void FixedUpdate() {
        
        Move();
        RotateToCursor();

    }

    void RotateToCursor(){

        // cursorPos = Input.mousePosition;
        // cursorPos.z = Mathf.Abs(Camera.main.transform.position.z);
        // cursorPos = Camera.main.ScreenToWorldPoint(cursorPos);

        // Vector3.AngleBetween(transform.for);

        // rb.AddTorque(transform.right * torque );
        // transform.LookAt(cursorPos);

    }

    void Move(){


        //
        targetPos = new Vector3(cursorPos.x,transform.position.y,cursorPos.z);
        forceDir = (targetPos - transform.position).normalized;

        float strength;
        float dis = Vector3.Distance(targetPos,transform.position);

        if(dis < idealDis){

            strength = Vector3.Distance(targetPos,transform.position) / idealDis;
            Debug.DrawLine(transform.position,cursorPos,Color.green);

        } else {

            strength = 1f;
            Debug.DrawLine(transform.position,cursorPos,Color.red);

        }
        
        Debug.Log(strength);

        rb.AddForce(transform.forward * thrust * strength,ForceMode.VelocityChange);

    }
}
