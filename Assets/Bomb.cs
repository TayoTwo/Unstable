using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bomb : MonoBehaviour
{
    public float torque;
    public int dir;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();

        dir = Random.Range(0,2);
        Debug.Log(torque);

        
    }

    // FixedUpdate is ran 60 times in a second
    void FixedUpdate()
    {

        if(dir == 0){

            rb.AddTorque(torque * Vector3.up);

        } else {

            rb.AddTorque(torque * Vector3.down);

        }

        
    }

}
