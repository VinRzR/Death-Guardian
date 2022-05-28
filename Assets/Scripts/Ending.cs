using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("asdasdasdsd");
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(3);
        }
    }
}
