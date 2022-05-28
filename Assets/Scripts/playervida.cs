using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playervida : MonoBehaviour
{
    public int maxHealth = 100;
    public int playercurrentHealth;
    public PlayerAttack attack;
    public healthbar healthBar;
    public otherbar otherbar;
    public AnimatorSwaper swaper;
    private bool isActive = false;

    public float cooldownTime = 15;
    private float nextFireTime;
    // Start is called before the first frame update
    void Start()
    {
        nextFireTime = Time.time;
        playercurrentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        otherbar.SetMaxPower(cooldownTime);
    }



    // Update is called once per frame

    private void Update()
    {
        otherbar.SetPower(-1*(nextFireTime - Time.time)+15);
        //Debug.Log (-1*(nextFireTime - Time.time) + 15);
        if (playercurrentHealth <= 0 && !isActive)
        {
            if (Time.time > nextFireTime)
            {
                playercurrentHealth = 1000;
                isActive = true;
                swaper.Swap();
                attack.enabled = true;
                nextFireTime = Time.time + cooldownTime;
                StartCoroutine(Timer());
            }
        }
        if (playercurrentHealth == 0 && !isActive)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       
        if(other.tag == "Enemy")
        {
            playercurrentHealth -= 10;
            healthBar.SetHealth(playercurrentHealth);

        }
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(5);
        swaper.Swap();
        attack.enabled = false;
        playercurrentHealth = maxHealth;
        healthBar.SetHealth(playercurrentHealth);
        isActive = false;
    }


}
