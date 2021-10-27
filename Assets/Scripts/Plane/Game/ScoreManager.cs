using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public int currentScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(){

        currentScore++;
        SetHighScore();

    }

    void SetHighScore(){

        if(PlayerPrefs.GetInt("highScore") < currentScore){

            PlayerPrefs.SetInt ("highScore", currentScore);

        }
        

    }
}
