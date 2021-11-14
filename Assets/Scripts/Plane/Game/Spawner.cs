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
    public List<GameObject> patterns = new List<GameObject>();
    public int[] difficultySpikes = new int[2];
    public bool  patternMode;
    public bool gameStarted;

    ScoreManager scoreManager;
    int objNum;
    int patternNum;

    // Start is called before the first frame update
    // Update is called once per frame
    void Start(){

        #if UNITY_WEBGL
        Application.targetFrameRate = 60;
        #endif
        
        scoreManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ScoreManager>();

        SpawnPatterns();
        
    }

    public void StartGame(){

        gameStarted = true;

    }

    void Update() {

        if(gameStarted){

            StartCoroutine(SpawnTimer());
            gameStarted = false;

        }
        
    }

    public IEnumerator SpawnTimer(){

        while(true){

            yield return new WaitForSeconds(spawnTime);
            
            if(!patternMode){

                SpawnObstacles();

            } else {

                SpawnPatterns();

            }


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

        //Debug.Log(index);

        objNum = Random.Range(0,index + 1);

        GameObject bull = (GameObject)Instantiate(objs[objNum],transform.position + spawnPos,Quaternion.identity);

        bull.GetComponent<Alien>().movSpeed = bulletSpeed;

    }

    void SpawnPatterns(){

        Vector3 spawnPos = new Vector3(0,0,Random.Range(-range,range));
        
        List<Alien> aliens = new List<Alien>();

        int index = 0;

        for(int i = 0;i < difficultySpikes.Length;i++){

            if(scoreManager.currentScore >= difficultySpikes[i]){

                index = i;

            }

        }

        //Debug.Log(index);

        patternNum = Random.Range(0,index + 1);



        GameObject bull = (GameObject)Instantiate(patterns[patternNum],transform.position + spawnPos,Quaternion.identity);
    
        aliens = aliens.AddRange( bull.GetComponentsInChildren<Alien>() );

    }

}
