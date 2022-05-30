using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialText : MonoBehaviour
{
    public GameObject UIObject;
    private void Start()
    {
        UIObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            UIObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            UIObject.SetActive(false);
        }
    }
}
