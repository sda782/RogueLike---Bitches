using System.Collections;
using System.Collections.Generic;
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
            health -= 1;
            healthbar.SetHealth(health, healthMax);
        }
        if (health <= 0) {
            animator.SetBool("isDead", true);
        }
    }
}
