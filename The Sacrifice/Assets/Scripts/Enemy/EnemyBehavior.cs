using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private Animator animator;
    public float health;
    private float healthMax;
    public HealthbarBehavior healthbar;
    private bool attackReady;
    private TakeDamage playertd;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        healthMax = health;
        healthbar.SetHealth(health, healthMax);
        playertd = GameObject.Find("Player").GetComponent<TakeDamage>();
        attackReady = true;
    }

    public void TakeDamage(int v)
    {
        health -= v;
        healthbar.SetHealth(health, healthMax);
        if (health <= 0)
        {
            animator.SetTrigger("TriggerDeath");
            healthbar.slider.gameObject.SetActive(false);
            Destroy(gameObject.GetComponent<Rigidbody2D>());
            Destroy(gameObject.GetComponent<BoxCollider2D>());
        }
    }
    public bool Attack()
    {
        playertd.PlayerTakeDamage();
        StartCoroutine("AttackCoolDown", 2);
        return true;
    }
    private IEnumerator AttackCoolDown(float toWait)
    {
        attackReady = false;
        yield return new WaitForSeconds(toWait);
        attackReady = true;
    }
}
