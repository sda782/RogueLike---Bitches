using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject ball;

    private Vector2 hitDirection;
    private Vector2 lastHitDirection;

    public Transform attackPoint;
    public float attackRange = 0.5f;

    public LayerMask enemyLayer;

    private Animator animator;

    private bool attackReady = true;
    private float attackCoolDown = 1f;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        lastHitDirection = new Vector2(1, 0);
        attackPoint = GetComponentInChildren<Transform>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.Health <= 0) { return; }
        hitDirection.x = Input.GetAxisRaw("Horizontal");
        hitDirection.y = Input.GetAxisRaw("Vertical");

        if (hitDirection.x != 0 || hitDirection.y != 0)
        {
            lastHitDirection = hitDirection;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (attackReady)
            {
                Hit();
            }
        }
    }


    private void Hit()
    {
        animator.SetTrigger("Attack");
        StartCoroutine("Delay", 0.1f);
        if (hitDirection.x <= 0 && hitDirection.y <= 0)
        {
            hitDirection = lastHitDirection;
        }

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        //Foreach Collider2d enemies (take dmg)
        foreach (Collider2D col in hitEnemies)
        {
            col.GetComponent<EnemyBehavior>().TakeDamage(3);
            Debug.Log("attack");
        }

        StartCoroutine("AttackCoolDown", attackCoolDown);
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) { return; }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    private IEnumerator Delay(float toWait)
    {
        yield return new WaitForSeconds(toWait);
    }
    private IEnumerator AttackCoolDown(float toWait)
    {
        attackReady = false;
        yield return new WaitForSeconds(toWait);
        attackReady = true;
    }
}
