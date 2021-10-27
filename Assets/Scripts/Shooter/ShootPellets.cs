using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPellets : MonoBehaviour
{

    public GameObject bullet;
    public Transform spawnpoint;
    public int ammo;
    public float fireDelay;
    public bool fullAuto;
    public float startForce;
    public float destroyTime;


    float time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){

        bool fire = Input.GetButtonDown("Fire1");

        if(time > fireDelay  && fire && ammo > 0){

            time = 0;
            ammo--;
            Spawn();

        }

        time += Time.deltaTime;
        
    }

    void Spawn(){

        GameObject obj = (GameObject)Instantiate(bullet,spawnpoint.position,spawnpoint.rotation);

        obj.GetComponent<Rigidbody>().AddForce(transform.forward * startForce,ForceMode.Impulse);

        Destroy(obj,destroyTime);

    }

}
