using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToCursor : MonoBehaviour
{

    //Forward force put on the player
    public float thrust;
    //How fast the player will rotate towards the cursor
    public float rotSpeed;

    public float idealDis;

    //public Transform target;
    Vector3 cursorPos;
    Vector3 targetPos;

    Vector3 dir;

    Rigidbody rb;

    float mousePressed;

    // Start is called before the first frame update
    void Start(){

        rb = GetComponent<Rigidbody>();
        
    }
    
    void Update() {
        //Find the cursor’s position/ Receive mouse inputs
        cursorPos = Input.mousePosition;
        cursorPos.z = Camera.main.transform.position.y;
        cursorPos = Camera.main.ScreenToWorldPoint(cursorPos);
        targetPos = new Vector3(cursorPos.x,transform.position.y,cursorPos.z);

        mousePressed = Input.GetAxisRaw("Fire1"); 
    }

    void FixedUpdate() {
        //Whilst the LMB is being pressed move and rotate the player
        if(mousePressed == 1){
            Move();
            RotateToCursor();
        }

    }

    void RotateToCursor(){
            
        //Calculate the vector between the two positions
        dir = targetPos - transform.position;
            
        //Calculate the Quaternion for the rotation
        Quaternion rot = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), rotSpeed * Time.fixedDeltaTime);
    
        //Apply the rotation
        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0,transform.eulerAngles.y,0);

    }

    void Move(){
        //What percentage of our thrust to use
        float strength;
        //Distance between the player and the cursor
        float dis = Vector3.Distance(targetPos,transform.position);

        //Check if the player is "out of range" of the cursor
        //If the player is outside of our ideal distance then use 100% of the thrust...
        //...otherwise apply a percent based on the distance from the mouse.
        if(dis < idealDis){

            strength = Vector3.Distance(targetPos,transform.position) / idealDis;
            Debug.DrawLine(transform.position,targetPos,Color.green);

        } else {

            strength = 1f;
            Debug.DrawLine(transform.position,targetPos,Color.red);

        }
        //Change our velocity based on our previous calculations
        rb.AddForce(transform.forward * thrust * strength,ForceMode.VelocityChange);
    }

}
