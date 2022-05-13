using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    
    [SerializeField]
    private float _force;

    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private SpriteRenderer sr;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);

        if (Input.GetKey("left"))
        {
            sr.flipX = true;
        }
        if (Input.GetKey("right"))
        {
            sr.flipX = false;
        }

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.AddForce((Vector2.up * _force), ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycast = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down * .1f);
        return raycast.collider != null;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "Health")
        {
            Destroy(col.gameObject);
            Score.ScoreValue += 1;
        }
    }
}
