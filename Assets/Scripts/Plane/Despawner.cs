using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Despawner : MonoBehaviour
{
    void OnTriggerEnter(Collider collider){

        if(collider.tag == "Player"){

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        } else {

            Destroy(collider.gameObject);
            
        }


    }
}
