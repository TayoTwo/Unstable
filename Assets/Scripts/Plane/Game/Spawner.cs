using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float range;
    public float spawnTime;
    
    public float minSpawnTime = 1; 
    public float bulletSpeed = 10;

    public float difficulty;
    public float difficultyRate;


    public List<GameObject> objs = new List<GameObject>();
    public int[] difficultySpikes = new int[2];

    ScoreManager scoreManager;
    int objNum;

    // Start is called before the first frame update
    // Update is called once per frame
    void Start(){

        StartCoroutine(SpawnTimer());
        scoreManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ScoreManager>();
        
    }

    IEnumerator SpawnTimer(){

        while(true){

            yield return new WaitForSeconds(spawnTime);
            
            SpawnObstacles();

            spawnTime /= difficulty;
            bulletSpeed *= difficulty;

            difficulty += difficultyRate;

            if(spawnTime < minSpawnTime){

                spawnTime = minSpawnTime;

            }

        }


    }

    void SpawnObstacles(){

        Vector3 spawnPos = new Vector3(0,0,Random.Range(-range,range));

        int index = 0;

        for(int i = 0;i < difficultySpikes.Length;i++){

            if(scoreManager.currentScore >= difficultySpikes[i]){

                index = i;

            }

        }

        Debug.Log(index);

        objNum = Random.Range(0,index + 1);

        GameObject bull = (GameObject)Instantiate(objs[objNum],transform.position + spawnPos,Quaternion.identity);

        bull.GetComponent<Alien>().movSpeed = bulletSpeed;

    }

}
