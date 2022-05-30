using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int ScoreValue = 0;
    public static int Level1Score = 0;
    public static int Level2Score = 0;
    public static int Level3Score = 0;
    public int level;
    private TextMeshProUGUI _score;
    
    void Start()
    {
        _score = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (level)
        {
            case 1: 
                _score.text = "Level 1 Score: " + Level1Score;
                break;
            case 2:
                _score.text = "Level 2 Score: " + Level2Score;
                break;
            case 3:
                _score.text = "Level 3 Score: " + Level3Score;
                break;
            default:
                _score.text = "Score: " + ScoreValue;
                break;
        }
        
    }
}
