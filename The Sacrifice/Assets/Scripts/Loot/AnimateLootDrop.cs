using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateLootDrop : MonoBehaviour
{
    private Vector2 endpoint;
    void Start()
    {
        endpoint = (Vector2)transform.position + new Vector2(Random.Range(-1f, 1.1f), Random.Range(-1f, 1.1f));
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, endpoint, Time.deltaTime * 50);
        if ((endpoint - (Vector2)transform.position).magnitude <= 0.2f)
        {
            Destroy(this);
        }
    }
}
