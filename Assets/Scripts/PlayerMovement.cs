using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    
    [SerializeField]
    private float force;

    private Rigidbody2D _rb;
    private Animator _animator;
    private BoxCollider2D _bc;
    private SpriteRenderer _sr;
    private bool _grounded;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2( horizontalInput * speed, _rb.velocity.y);

        if (Input.GetKey("left"))
        {
            _sr.flipX = true;
        }
        if (Input.GetKey("right"))
        {
            _sr.flipX = false;
        }

        if ((Input.GetButtonDown("Jump") || Input.GetKey("up")) && _grounded)
        {
            Jump();
        }
        
        _animator.SetBool("run", horizontalInput != 0);
        _animator.SetBool("grounded", _grounded);
    }

    private void Jump()
    {
        _rb.AddForce((Vector2.up * force), ForceMode2D.Impulse);
        //_rb.velocity = new Vector2(_rb.velocity.x, speed);
        _grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Health"))
        {
            Destroy(col.gameObject);
            Score.ScoreValue += 1;
        }

        if (col.gameObject.CompareTag("Ground"))
        {
            _grounded = true;
        }
    }
}
