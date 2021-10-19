using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    void OnCollisionEnter(Collision other) {

        if(other.gameObject.tag == "Bullet"){

            Destroy(gameObject);

        }

        
    }
}
