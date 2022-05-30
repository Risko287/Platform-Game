using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorControl : MonoBehaviour
{
    
    private float target;
    public static int scene = 1;

    public TextMeshProUGUI minScore;
    // Start is called before the first frame update
    void Start()
    {
        target = transform.position.y;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Score.ScoreValue >= 15)
        {                                                   
            
            switch (scene)
            {
                case 1 :
                    target = 8;
                    Score.Level1Score = Score.ScoreValue;
                    break;
                case 2 :
                    target = 8;
                    Score.Level2Score = Score.ScoreValue;
                    break;
                case 3 :
                    target = 14;
                    Score.Level3Score = Score.ScoreValue;
                    break;
            }
            
            Score.ScoreValue = 0;
            scene++;
            LevelManager.Instance.LoadNewScene(scene);      
            //SceneManager.LoadScene(scene);
            Debug.Log(scene);
            
        }
        else
        {
            minScore.text = "Minimum is 15!!!";
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        minScore.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, Mathf.MoveTowards(transform.position.y, target, Time.deltaTime * 3));
    }
    
}
