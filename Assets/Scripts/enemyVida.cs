using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyVida : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //hurt animation
        

        if (currentHealth <= 0)
        {
            //die animation

            this.enabled = false;
            GetComponent<Collider2D>().enabled = false; //disable enemy
            Destroy(gameObject);



        }
    }

}
