using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody2D target;

    public float smoothSpeed = 5f;
    public Vector3 offSet;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        transform.position = target.position;
    }

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.transform.position - offSet;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
