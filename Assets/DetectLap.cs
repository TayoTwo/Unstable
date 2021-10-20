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

        int triggersFlagged = 0;

        for(int i = 0;i <= 3;i++){

            if(triggers[i].flagged){

                triggersFlagged++;

            }

        }

        if(triggersFlagged == 4){

            Debug.Log("FULL LAP");
            scoreManager.UpdateScore();
            Destroy(gameObject);

        } else {

            Debug.Log("Triggers flagged: " + triggersFlagged );

        }

    }
}
