using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Despawner : MonoBehaviour
{
    void OnCollisionEnter(Collision collider){

        if(collider.gameObject.tag != "Player"){

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }


    }
}
