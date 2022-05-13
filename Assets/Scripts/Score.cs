using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int ScoreValue = 0;
    public Text _score;
    
    void Start()
    {
        _score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _score.text = "Score: " + ScoreValue;
    }
}
