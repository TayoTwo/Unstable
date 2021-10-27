using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

    public TMP_Text score;
    public TMP_Text highScore;
    ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {

        scoreManager = GetComponent<ScoreManager>();
        
    }

    // Update is called once per frame
    void Update()
    {

        score.text = scoreManager.currentScore.ToString();
        highScore.text = "Best - " + PlayerPrefs.GetInt("highScore").ToString();
        
    }
}
