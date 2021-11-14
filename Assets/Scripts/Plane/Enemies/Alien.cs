using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Alien : MonoBehaviour
{

    public int id;
    public float movSpeed = 5;

    public float maxSpeed = 15;

    public ScoreManager scoreManager;
    public Trigger[] triggers = new Trigger[4];

    public bool randomTriggAmount = false;

    public GameObject expolsionEffect;
    public AudioClip explosionClip;
    public AudioSource audioSource;

    public GameObject model;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start(){

        rb = GetComponent<Rigidbody>();

        scoreManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ScoreManager>();
        
    }

    // FixedUpdate is ran 60 times in a second
    void FixedUpdate()
    {

        if(movSpeed > maxSpeed){

            movSpeed = maxSpeed;

        }

        rb.velocity = Vector3.left * movSpeed;
        
    }

    public void DestroySelf(){

        gameObject.GetComponent<Collider>().enabled = false;
        model.SetActive(false);
        audioSource.PlayOneShot(explosionClip);
        Instantiate(expolsionEffect,transform.position,Quaternion.Euler(-90,0,0));
        Destroy(gameObject,explosionClip.length);

    }

    public void CheckTriggerCount(){

        bool allTriggered = true;

        for(int i = 0;i < triggers.Length;i++){

            if(!triggers[i].flagged){

                allTriggered = false;

            }

        }

        if(allTriggered){

            scoreManager.UpdateScore();

            DestroySelf();

        }

    }

    void OnCollisionEnter(Collision other) {

        if(other.gameObject.tag == "Player"){

            other.gameObject.GetComponent<Health>().LoseHealth();

        }

    }
}
