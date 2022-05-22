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
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z));
    }
    private void spawnEnemy()
    {
        GameObject a = Instantiate(enemyPrefab) as GameObject;
        a.transform.position = new Vector2(Random.Range(screenBounds.x - 5f, screenBounds.x + 5f), Random.Range(screenBounds.y - 5f, screenBounds.y + 5f));
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
