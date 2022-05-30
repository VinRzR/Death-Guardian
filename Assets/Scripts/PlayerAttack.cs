using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 1f;
    public int attackDamage = 50;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    public float thrust = 2f;

    public float hitstopduration = 0.05f;
    // Update is called once per frame
    void Update()
    {
           
        
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                Attack();
            }
        }
    }
    void Attack()
    {
        animator.SetTrigger("Attack"); // animação do ataque
        FindObjectOfType<AudioManager>().Play("Slash");
        GetComponent<PlayerMovement>().LockAttack();
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers); // detectar

        foreach (Collider2D enemy in hitEnemies) // dano
        {
            if (enemy != null)
            { 
                Vector2 difference = enemy.transform.position - transform.position;
                difference = difference.normalized * thrust;
                enemy.transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y);
                //enemy.GetComponent<Rigidbody2D>().AddForce(difference, ForceMode2D.Impulse);
                FindObjectOfType<HitStop>().Stop(hitstopduration);
                enemy.GetComponent<enemyVida>().TakeDamage(attackDamage);
                if(enemy.GetComponent<enemyVida>().currentHealth > 0) StartCoroutine(DisableEnemy(enemy));
                //GetComponent<playervida>().playercurrentHealth += 10;
                //GetComponent<playervida>().healthBar.SetHealth(GetComponent<playervida>().playercurrentHealth);
                FindObjectOfType<AudioManager>().Play("Hit");

            }
        }

        nextAttackTime = Time.time + 1f / attackRate;
    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    IEnumerator DisableEnemy(Collider2D enemy)
    {
        float startvalue = enemy.GetComponentInParent<Enemy>().moveSpeed;
        enemy.GetComponentInParent<Enemy>().moveSpeed = 0;

        yield return new WaitForSeconds(0.5f);

        if(enemy != null)enemy.GetComponentInParent<Enemy>().moveSpeed = startvalue;
    }
}
