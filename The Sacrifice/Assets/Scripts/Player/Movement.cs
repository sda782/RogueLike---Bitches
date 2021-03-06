using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Player player;

    private float speed = 3f;

    [SerializeField]
    private Vector2 movement;
    private Rigidbody2D rb;

    //Prevents faster movement when going diagonally
    private float speedLimiter = 0.75f;

    private Animator animator;
    private SpriteRenderer sprite;

    private float lastDirection = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        player = GetComponent<Player>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x != 0 && movement.y != 0)
        {
            movement.x *= speedLimiter;
            movement.y *= speedLimiter;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = player.RunSpeed;
        }
        else
        {
            speed = player.Speed;
        }

        AnimateSprite();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
    }

    private void AnimateSprite()
    {
        if (movement.x != 0)
        {
            lastDirection = movement.x;
        }

        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (lastDirection >= 0)
        {
            sprite.flipX = false;
        }
        else if (lastDirection < 0)
        {
            sprite.flipX = true;
        }
    }
}
