using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    

private float target;
    // Start is called before the first frame update
    void Start()
    {
        target = transform.position.y;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        target = 8;
        LevelManager.Instance.LoadNewScene("Level 2");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, Mathf.MoveTowards(transform.position.y, target, Time.deltaTime));
    }
    
}
