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
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        healthMax = health;
        healthbar.SetHealth(health, healthMax);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("TriggerHit");
            health -= 1;
            healthbar.SetHealth(health, healthMax);
        }
        if (health <= 0) {
            animator.SetTrigger("TriggerDeath");
            healthbar.slider.gameObject.SetActive(false);
            //Loot drop
            LootManager lm = GameObject.Find("LootContainer").GetComponent<LootManager>();
            switch(gameObject.tag) {
                case "EnemyMelee1": lm.GenEnemy1Loot(transform); break;
                case "EnemyMelee2": lm.GenEnemy2Loot(transform); break;
                case "EnemyMelee3": lm.GenEnemy3Loot(transform); break;
                case "NpcMerchant": lm.GenNpcMerchantLoot(transform); break;
            }
            Destroy(this.gameObject);
        }
    }
}
