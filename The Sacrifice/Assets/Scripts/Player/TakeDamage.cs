using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class TakeDamage : MonoBehaviour
{
    //public HealthbarBehavior healthbar;
    private Animator animator;
    private Player player;
    private PlayerHeartsManager heartUI;

    private void Awake()
    {
        //healthbar.SetHealth(Player.Health, Player.MaxHealth);
        animator = GetComponent<Animator>();
        heartUI = GetComponent<PlayerHeartsManager>();
    }
    private void Start()
    {
        player = GetComponent<Player>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            //PlayerStats.Currency += 1;
            PlayerTakeDamage();
        }
    }


    public void PlayerTakeDamage()
    {
        //Lower health
        player.Health -= 1;
        //Play animation
        animator.SetTrigger("TakeDamage");
        //decrease UI healthbar
        heartUI.DecreaseHearts();
        //healthbar.SetHealth(Player.Health, Player.MaxHealth);

        if (player.Health <= 0)
        {
            GetComponent<Movement>().enabled = false;
            animator.SetTrigger("Death");
            GameController.GameOver(false);
        }
    }
}
