using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBox : MonoBehaviour
{

    public Spawner spawner;

    public AudioSource audioSource;

    public AudioClip explosionClip;

    public GameObject explosionEffect;
    public GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {

        if(other.tag == "Player"){

            
            text.SetActive(false);
            spawner.StartGame();
            Instantiate(explosionEffect,transform.position,Quaternion.Euler(-90,0,0));
            audioSource.PlayOneShot(explosionClip);
            GetComponent<MeshRenderer>().enabled = false;
            Destroy(gameObject,explosionClip.length);

        }
        
    }
}
