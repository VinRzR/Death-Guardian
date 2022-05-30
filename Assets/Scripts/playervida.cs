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

    private bool IsEnemyReady = true;
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
        if (Input.GetKeyDown(KeyCode.E))
        {
            playercurrentHealth = 0;
            healthBar.SetHealth(playercurrentHealth);
        }
        otherbar.SetPower(-1*(nextFireTime - Time.time)+15);
        //Debug.Log (-1*(nextFireTime - Time.time) + 15);
        if (playercurrentHealth <= 0 && !isActive)
        {
            if (Time.time > nextFireTime)
            {
                FindObjectOfType<AudioManager>().Play("Summon");
                playercurrentHealth = 1000;
                healthBar.SetHealth(playercurrentHealth);
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


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" && IsEnemyReady)
        {
            playercurrentHealth -= 25;
            healthBar.SetHealth(playercurrentHealth);
            StartCoroutine(EnemyCooldown());
        }

    }
    IEnumerator EnemyCooldown()
    {
        IsEnemyReady = false;
        yield return new WaitForSeconds(1);
        IsEnemyReady = true;

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
