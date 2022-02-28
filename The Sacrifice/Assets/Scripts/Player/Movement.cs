using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    private float sprintSpeed = 10f;
    private float normalSpeed = 5f;

    [SerializeField]
    private Vector2 movement;
    private Rigidbody2D rb;

    //Prevents faster movement when going diagonally
    private float speedLimiter = 0.75f;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(movement.x != 0 && movement.y != 0)
        {
            movement.x *= speedLimiter;
            movement.y *= speedLimiter;
        }

        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = sprintSpeed;
        }
        else
        {
            speed = normalSpeed;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
    }
}
