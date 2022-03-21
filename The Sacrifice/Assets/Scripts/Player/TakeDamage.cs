using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public Image[] heartImages;
    //public HealthbarBehavior healthbar;
    private Animator animator;

    private void Awake()
    {
        //healthbar.SetHealth(Player.Health, Player.MaxHealth);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            PlayerStats.Currency += 1;
            PlayerTakeDamage();
        }
    }


    public void PlayerTakeDamage()
    {
        //Lower health
        Player.Health -= 1;
        //Play animation
        animator.SetTrigger("TakeDamage");
        //decrease UI healthbar
        heartImages[Player.Health].enabled = false;
        //healthbar.SetHealth(Player.Health, Player.MaxHealth);

        if (Player.Health <= 0)
        {
            GetComponent<Movement>().enabled = false;
            animator.SetTrigger("Death");
            GameController.GameOver(false);
        }
    }
}
