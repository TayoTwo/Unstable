using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlockMovement : MonoBehaviour
{

    public float movSpeed;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        

        
    }

    // FixedUpdate is ran 60 times in a second
    void FixedUpdate()
    {

        rb.velocity = Vector3.left * movSpeed;
        
    }

    void OnCollisionEnter(Collision collider){

        if(collider.gameObject.tag == "Player"){

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }


    }
}
