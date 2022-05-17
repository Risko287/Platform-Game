using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private float position;
    private float target;
    private float current;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        target = transform.position.y;
        current = transform.position.y;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        target = position;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        target = current;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, Mathf.MoveTowards(transform.position.y, target, Time.deltaTime * speed));

    }
}
