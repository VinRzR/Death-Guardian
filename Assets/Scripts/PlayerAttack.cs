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

   
    // Update is called once per frame
    void Update()
    {
           
        
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger("Attack"); // animação do ataque

                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers); // detectar

                foreach (Collider2D enemy in hitEnemies) // dano
                {
                    enemy.GetComponent<enemyVida>().TakeDamage(attackDamage);
                    if (enemy.GetComponent<enemyVida>().currentHealth > 0) StartCoroutine(DisableEnemy(enemy));
                }

                nextAttackTime = Time.time + 1f / attackRate;
            }
            else
            {
                attackPoint.transform.localPosition = new Vector3(0.001f, -0.257f, attackPoint.transform.localPosition.z);
            }
        }
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

        enemy.GetComponentInParent<Enemy>().moveSpeed = startvalue;
    }
}
