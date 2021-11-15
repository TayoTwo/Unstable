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

    //A pattern is represented by 9 digits 
    //[1][4][7]
    //[2][5][8]
    //[3][6][9]
    //With their value corresponding to the ID of an object, -1 means blank
    //In this example the pattern is full of Bombs
    //[1][1][1]
    //[1][1][1]
    //[1][1][1]
    public List<string> patterns = new List<string>();

    //Distance between spawns
    public float unitLength = 10;
    public int[] difficultySpikes = new int[2];
    //Check if the game has started
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

        //Current position to spawn an object
        Vector3 spawnPos = new Vector3(0,0,0);
        //Current pattern
        char[] pattern;
        //Record how far along in the pattern we are
        int pos = 0;
        //The range of patterns we can spawn
        int range = 0;

        //Increase the pool of enemies we can spawn if the player reaches above a certain score
        for(int i = 0;i < difficultySpikes.Length;i++){

            if(scoreManager.currentScore >= difficultySpikes[i]){

                range = i;

            }

        } 
        //Randomly choose a pattern to generate
        patternNum = Random.Range(0,range + 1);
        pattern = patterns[patternNum].ToCharArray();

        //Move down the grid then move to the next column
        for(int x = 0;x < 3;x++){

            for(int y = 0;y < 3;y++){
                //Check what needs to be spawned in at this position in the pattern
                int objIndex = (int)(pattern[pos]-'0') - 1;

                //Spawn the an object if theres not a blank
                if(objIndex > -1){
                    //[1][4][7]
                    //[2][5][8]
                    //[3][6][9]
                    //Move the grid down so that object '5' is at the center
                    spawnPos = new Vector3(x-1,0,y-1) * unitLength;
                    //Spawn the pattern
                    GameObject parent = (GameObject)Instantiate(objs[objIndex],transform.position + spawnPos,Quaternion.identity);
                    //Set the speed of each object in the pattern
                    Alien[] aliens = parent.GetComponentsInChildren<Alien>();
                    for(int i = 0; i < aliens.Length;i++){

                        aliens[i].movSpeed = bulletSpeed;

                    }

                }

                //Increment our position along the pattern
                pos++;

            }

        }

                         
    }

}
