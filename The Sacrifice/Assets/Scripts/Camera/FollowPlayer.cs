using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody2D target;

    public float deadzone = 1f;
    public float smoothSpeed = 15;
    public Vector3 offSet;

    private Vector3 damp = Vector3.zero;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        transform.position = (Vector3)target.position - offSet;
    }


    private void FixedUpdate()
    {
        if(Vector2.Distance(transform.position, target.position) >= deadzone)
        {
            Vector3 desiredPosition = target.transform.position - offSet;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = Vector3.SmoothDamp(transform.position, smoothedPosition, ref damp, 0.1f);
        }
    }
}
