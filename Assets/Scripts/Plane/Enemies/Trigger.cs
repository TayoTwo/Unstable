using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{

    public bool flagged;

    public GameObject fireEffect;
    public AudioClip audioClip;

    public AudioSource audioSource;

    MeshRenderer rend;

    void Start(){


    }


    void OnTriggerEnter(Collider other) {
        
        if(other.gameObject.tag == "Player"){

             OnTriggered();

        }

    }

    void OnTriggered(){

        flagged = true;
        audioSource.PlayOneShot(audioClip);
        gameObject.GetComponentInParent<Alien>().CheckTriggerCount();
        GameObject obj = (GameObject)Instantiate(fireEffect,transform.position,Quaternion.Euler(0,90,0));
        obj.transform.parent = transform.parent;
        gameObject.SetActive(false);

    }
}
