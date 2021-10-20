using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{

    public bool flagged;

    MeshRenderer renderer;

    void Start(){

        renderer = GetComponent<MeshRenderer>();

    }

    void OnTriggerEnter(Collider other) {
        
        if(other.gameObject.tag == "Player"){

            flagged = true;
            renderer.enabled = false;
            gameObject.GetComponentInParent<DetectLap>().CheckTriggerCount();

        }

    }
}
