using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToCursor : MonoBehaviour
{

    public float thrust;
    public float rotSpeed;

    
    public float idealDis;
    //public Transform target;
    Vector3 cursorPos;
    Vector3 targetPos;

    Vector3 dir;

    Rigidbody rb;

    float mousePressed;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        
    }

    void Update() {

        cursorPos = Input.mousePosition;
        cursorPos.z = Camera.main.transform.position.y;
        cursorPos = Camera.main.ScreenToWorldPoint(cursorPos);
        targetPos = new Vector3(cursorPos.x,transform.position.y,cursorPos.z);

        mousePressed = Input.GetAxisRaw("Fire1");
        
    }

    void FixedUpdate() {

        if(mousePressed == 1){
         
            Move();
            RotateToCursor();

        }


    }

    void RotateToCursor(){

        // // The step size is equal to speed times frame time.
        
        // float singleStep = rotSpeed * Time.fixedDeltaTime;
        // Vector3 dir = Vector3.RotateTowards(transform.forward,target.forward,singleStep,0.0f);

        // Draw a ray pointing at our target in
        //Debug.DrawRay(transform.position, dir, Color.red);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        
        dir = targetPos - transform.position;

        //Debug.Log(targetPos);
        
        // calculate the Quaternion for the rotation
        Quaternion rot = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), rotSpeed * Time.fixedDeltaTime);
 
        //Apply the rotation 
        transform.rotation = rot; 

        transform.eulerAngles = new Vector3(0,transform.eulerAngles.y,0);

    }

    void Move(){

        float strength;
        float dis = Vector3.Distance(targetPos,transform.position);

        if(dis < idealDis){

            strength = Vector3.Distance(targetPos,transform.position) / idealDis;
            // strength = 1f;
            Debug.DrawLine(transform.position,targetPos,Color.green);

        } else {

            strength = 1f;
            Debug.DrawLine(transform.position,targetPos,Color.red);

        }
        
        //Debug.Log(strength);

        rb.AddForce(transform.forward * thrust * strength,ForceMode.VelocityChange);

    }
}
