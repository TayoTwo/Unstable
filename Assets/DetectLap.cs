using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectLap : MonoBehaviour
{

    public ScoreManager scoreManager;
    public Trigger[] triggers = new Trigger[4];


    // Start is called before the first frame update
    void Start()
    {

        scoreManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ScoreManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckTriggerCount(){

        bool allTriggered = true;

        for(int i = 0;i <= 3;i++){

            if(!triggers[i].flagged){

                allTriggered = false;

            }

        }

        if(allTriggered){

            Debug.Log("FULL LAP");
            scoreManager.UpdateScore();
            Destroy(gameObject);

        }

    }
}
