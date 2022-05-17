using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    private float target;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        target = transform.position.y;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        target = 18;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, Mathf.MoveTowards(transform.position.y, target, Time.deltaTime * speed));

    }
}
