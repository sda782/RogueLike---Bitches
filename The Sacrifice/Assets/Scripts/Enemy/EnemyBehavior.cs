using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private Animator animator;
    public float health;
    private float healthMax;
    public HealthbarBehavior healthbar;
    private bool attackReady;
    private TakeDamage playertd;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        healthMax = health;
        healthbar.SetHealth(health, healthMax);
        player = GameObject.Find("Player");
        playertd = player.GetComponent<TakeDamage>();
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
            LootManager lm = GameObject.Find("LootContainer").GetComponent<LootManager>();
            switch(gameObject.tag) {
                case "EnemyMelee1": lm.GenEnemy1Loot(transform); break;
                case "EnemyMelee2": lm.GenEnemy2Loot(transform); break;
                case "EnemyMelee3": lm.GenEnemy3Loot(transform); break;
                case "NpcMerchant": lm.GenNpcMerchantLoot(transform); break;
            }
            Destroy(gameObject.GetComponent<Rigidbody2D>());
            Destroy(gameObject.GetComponent<BoxCollider2D>());
        }
    }
    public void Attack()
    {
        if (Vector2.Distance(transform.position, player.transform.position) <= 1)
        {
            playertd.PlayerTakeDamage();
            StartCoroutine("AttackCoolDown", 2);
        }
    }
    private IEnumerator AttackCoolDown(float toWait)
    {
        attackReady = false;
        yield return new WaitForSeconds(toWait);
        attackReady = true;
    }
}
