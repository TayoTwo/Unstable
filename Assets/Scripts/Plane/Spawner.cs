using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float range;
    public float spawnTime;

    public float rateOfDecrease;

    public List<GameObject> objs = new List<GameObject>();

    // Start is called before the first frame update
    // Update is called once per frame
    void Start(){

        StartCoroutine(SpawnTimer());
        
    }

    IEnumerator SpawnTimer(){

        while(true){

            yield return new WaitForSeconds(spawnTime);
            
            SpawnObstacles();

            spawnTime *= rateOfDecrease;

        }


    }

    void SpawnObstacles(){

        Vector3 spawnPos = new Vector3(0,0,Random.Range(-range,range));

        Instantiate(objs[0],transform.position + spawnPos,Quaternion.identity);

    }

}
