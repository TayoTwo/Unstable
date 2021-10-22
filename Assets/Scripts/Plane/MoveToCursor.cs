using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToCursor : MonoBehaviour
{

    public float thrust;
    public float rotSpeed;

    
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

    void Update() {

        cursorPos = Input.mousePosition;
        cursorPos.z = Mathf.Abs(Camera.main.transform.position.z);
        cursorPos = Camera.main.ScreenToWorldPoint(cursorPos);
        
    }

    void FixedUpdate() {
        
        Move();
        RotateToCursor();

    }

    void RotateToCursor(){

        // // The step size is equal to speed times frame time.


        // // Draw a ray pointing at our target in
        // Debug.DrawRay(transform.position, dir, Color.red);

        // // // Calculate a rotation a step closer to the target and applies rotation to this object
        // // transform.rotation = Quaternion.LookRotation(dir);

    }

    void Move(){


        //
        targetPos = new Vector3(cursorPos.x,transform.position.y,cursorPos.z);
        forceDir = (targetPos - transform.position).normalized;

        float strength;
        float dis = Vector3.Distance(targetPos,transform.position);
        float singleStep = rotSpeed * Time.fixedDeltaTime;

        if(dis < idealDis){

            strength = Vector3.Distance(targetPos,transform.position) / idealDis;
            Debug.DrawLine(transform.position,cursorPos,Color.green);

        } else {

            strength = 1f;
            Debug.DrawLine(transform.position,cursorPos,Color.red);

        }
        
        Debug.Log(strength);


        Vector3 dir = Vector3.RotateTowards(transform.forward,target.forward,singleStep,0.0f);

        rb.AddForce(dir * thrust * strength,ForceMode.VelocityChange);

    }
}
