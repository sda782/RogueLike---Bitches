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

    // Start is called before the first frame update
    void Start()
    {
        lastHitDirection = new Vector2(1, 0);
        attackPoint = GetComponentInChildren<Transform>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        hitDirection.x = Input.GetAxisRaw("Horizontal");
        hitDirection.y = Input.GetAxisRaw("Vertical");

        if (hitDirection.x != 0 || hitDirection.y != 0)
        {
            lastHitDirection = hitDirection;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Hit();
        }
    }


    private void Hit()
    {
        animator.SetTrigger("Attack");

        GameObject a = Instantiate(ball, transform.position, transform.rotation);

        if (hitDirection.x <= 0 && hitDirection.y <= 0)
        {
            hitDirection = lastHitDirection;
        }

        a.GetComponent<Rigidbody2D>().AddForce(hitDirection * 1000f * Time.deltaTime, ForceMode2D.Impulse);

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        //Foreach Collider2d enemies (take dmg)
    }

    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null) { return; }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
