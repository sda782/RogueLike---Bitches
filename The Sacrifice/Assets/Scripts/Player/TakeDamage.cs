using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            PlayerTakeDamage();
        }
    }


    public void PlayerTakeDamage()
    {
        Player.Health -= 1;
        animator.SetTrigger("TakeDamage");
        //decrease UI healthbar

        if (Player.Health <= 0)
        {
            //Stop Player movement
            animator.SetTrigger("Death");
            //Game Over Screen
        }
    }
}
