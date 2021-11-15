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

    //ObjectIDs
    //Bomb is 0
    //Plane is 1
    public List<GameObject> objs = new List<GameObject>();

    //[0][3][6]
    //[1][4][7]
    //[2][5][8]
    public List<string> patterns = new List<string>();

    //Distance between spawns
    public float unitLength = 10;


    public int[] difficultySpikes = new int[2];
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
            
            SpawnPatterns();

            spawnTime /= difficulty;
            bulletSpeed *= difficulty;

            difficulty += difficultyRate;

            if(spawnTime < minSpawnTime){

                spawnTime = minSpawnTime;

            }

        }

    }

    void SpawnPatterns(){

        Vector3 center = new Vector3(0,0,Random.Range(-range,range));
        Vector3 spawnPos = new Vector3(0,0,0);
        char[] pattern;
        
        int pos = 0;
    
        int index = 0;

        for(int i = 0;i < difficultySpikes.Length;i++){

            if(scoreManager.currentScore >= difficultySpikes[i]){

                index = i;

            }

        } 

        //Debug.Log(index);

        patternNum = Random.Range(0,index + 1);

        pattern = patterns[patternNum].ToCharArray();

        for(int x = 0;x < 3;x++){

            for(int y = 0;y < 3;y++){

                int objIndex = (int)(pattern[pos]-'0') - 1;

                if(objIndex > -1){

                    spawnPos = new Vector3(x-1,0,y-1) * unitLength;
                    
                    GameObject alien = (GameObject)Instantiate(objs[objIndex],transform.position + spawnPos,Quaternion.identity);
        alien.GetComponent<Alien>().movSpeed = bulletSpeed;

                }

                pos++;

            }

        }

        //Debug.Log(pos);
                         
    }


    void SpawnPattern(string objects){



    }

}
