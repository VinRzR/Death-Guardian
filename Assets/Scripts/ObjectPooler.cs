using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float respawnTime = 1f;
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        
        //screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(enemyWave());
    }

    // Update is called once per frame
    void Update()
    {
        //screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z));
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height/2, Camera.main.transform.position.z));
    }
    private void spawnEnemy()
    {
        GameObject a = Instantiate(enemyPrefab) as GameObject;
        a.transform.position = new Vector2(Random.Range(screenBounds.x - 10f, screenBounds.x + 10f), Random.Range(screenBounds.y - 10f, screenBounds.y + 10f));
    }
    IEnumerator enemyWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }
}
