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
    private TextMeshProUGUI _score;
    
    void Start()
    {
        _score = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _score.text = "Score: " + ScoreValue;
    }
}
