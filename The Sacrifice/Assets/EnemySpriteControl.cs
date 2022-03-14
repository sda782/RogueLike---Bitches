using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpriteControl : MonoBehaviour
{
    public Transform playerCharacter;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
        this.animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("isChasing") == true || animator.GetBool("isAttacking") == true)
        {
            if (playerCharacter.transform.position.x < this.transform.position.x) {
                this.spriteRenderer.flipX = true;
            } else {
                this.spriteRenderer.flipX = false;
            }

        }
    }
}
