using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpriteControl : MonoBehaviour
{
    public Transform playerCharacter;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    //Vector2 direction; 
    // Start is called before the first frame update
    void Start()
    {
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
        this.animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //direction = (target.position - transform.position).normalized;
        if (animator.GetBool("isChasing") == true)
        {
            if (playerCharacter.transform.position.x < this.transform.position.x) {
                this.spriteRenderer.flipX = true;
            } else if (playerCharacter.transform.position.x > this.transform.position.x) {
                this.spriteRenderer.flipX = false;
            }

        /* if (playerCharacter.transform.position.x  < this.transform.position.x) {
            // Flip Sprite on the X Axis
            transform.localScale = new Vector3 (-1f, 1f, 1f);
        }

        else if (playerCharacter.transform.position.x > this.transform.position.x) {
            // Flip Sprite back on the X Axis
            transform.localScale = new Vector3 (1f, 1f, 1f);
        } */

        }
    }
}
