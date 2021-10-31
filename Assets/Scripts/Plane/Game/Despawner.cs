using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Despawner : MonoBehaviour
{
    void OnCollisionEnter(Collision collider){

        if(collider.gameObject.tag != "Player"){

            GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().LoseHealth();
            collider.gameObject.GetComponent<Alien>().DestroySelf();

        }


    }
}
