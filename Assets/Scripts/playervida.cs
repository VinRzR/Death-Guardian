using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playervida : MonoBehaviour
{
    public int maxHealth = 100;
    public int playercurrentHealth;

    public healthbar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        playercurrentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
     
    }



    // Update is called once per frame

    private void Update()
    {
        if (playercurrentHealth == 0){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       
        if(other.tag == "Enemy")
        {
            playercurrentHealth -= 10;
            healthBar.SetHealth(playercurrentHealth);
            //colocar aqui um if para menos de 50% da vida ficar mais forte e trocar anima��es
        }
    }


}
