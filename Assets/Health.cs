using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{

    public int health = 3;
    public float invulnTime = 1f;

    public Color fullHealth;

    public Color lowHealth;

    public MeshRenderer cape;
    public TrailRenderer capeTrail;
    public AudioClip hurtClip;
    public AudioSource audioSource;
    public GameObject model;

    // Start is called before the first frame update
    void Start(){

        UpdateColors(fullHealth);
        
    }

    // Update is called once per frame
    void UpdateColors(Color color){

        cape.material.color = color;
        capeTrail.startColor = color;
        capeTrail.endColor = color;
        
    }


    public void LoseHealth(){

        if(health > 1){

            health--;
            if(health == 1){

                UpdateColors(lowHealth);

            }
            audioSource.PlayOneShot(hurtClip);
            StartCoroutine(StartInvuln());

        } else {

            StartCoroutine(RestartGame());

        }



    }

    IEnumerator RestartGame(){

        audioSource.PlayOneShot(hurtClip);

        GetComponent<Collider>().isTrigger = true;
        GetComponent<MoveToCursor>().enabled = false;
        transform.localScale = Vector3.zero;

        yield return new WaitForSeconds(2);

        UpdateColors(fullHealth);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    IEnumerator StartInvuln(){

        GetComponent<Collider>().isTrigger = true;
  
        yield return new WaitForSeconds(invulnTime);

        GetComponent<Collider>().isTrigger = false;

    }
}
