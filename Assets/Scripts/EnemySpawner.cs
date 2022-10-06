using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] enemyPrefabs;

    [SerializeField]
    private Transform[] enemySpawns;

    [SerializeField]
    private float enemyInterval = 4f;

    public int enemiesSpawned = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(enemyInterval, enemyPrefabs[0]));
    }

    // Update is called once per frame
    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        enemy = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], enemySpawns[Random.Range(0, enemySpawns.Length)].position, Quaternion.identity);
        
        if (enemiesSpawned < 8)
        {
            StartCoroutine(spawnEnemy(enemyInterval, enemy));
            enemiesSpawned += 1;
        }
    }
}
