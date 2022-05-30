using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float force;
    [SerializeField] private LayerMask layer;

    [Header("Sound")] [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip deadSound;
    [SerializeField] private AudioClip pickSound;

    private Rigidbody2D _rb;
    private Animator _animator;
    private BoxCollider2D _bc;
    private SpriteRenderer _sr;
    private bool _grounded;
    public static Vector2 checkpoint;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _bc = GetComponent<BoxCollider2D>();
        _sr = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2(horizontalInput * speed, _rb.velocity.y);

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
        else if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }

        _animator.SetBool("run", horizontalInput != 0);
        _animator.SetBool("grounded", _grounded);
        
        
    }

    private void Jump()
    {
        SoundManager.instance.PlaySound(jumpSound);
        _rb.AddForce((Vector2.up * force), ForceMode2D.Impulse);
        //_rb.velocity = new Vector2(_rb.velocity.x, speed);
        _grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Health"))
        {
            SoundManager.instance.PlaySound(pickSound);
            Destroy(col.gameObject);
            Score.ScoreValue += 1;
        }

        if (col.transform.CompareTag("Trap"))
        {
            Destroy(col.gameObject, 0.2f);
            _grounded = true;
        }

        if (col.gameObject.CompareTag("Ground"))
        {
            _grounded = true;
        }

        if (col.gameObject.CompareTag("Respawn"))
        {
            SoundManager.instance.PlaySound(deadSound);
            transform.position = checkpoint;
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(_bc.bounds.center, Vector2.down, _bc.bounds.extents.y + 1f, layer);
        return raycastHit2D.collider != null;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (DoorControl.scene == 1)
        {
            checkpoint.Set(31,-7);
        }
        if (DoorControl.scene == 2)
        {
            checkpoint.Set(-17,20);
        }
        
        
    }
}
