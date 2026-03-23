using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;

    public float spawnInterval = 2f;
    public int maxEnemies = 5;
    float timer;
 
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= spawnInterval && GameObject.FindGameObjectsWithTag("pushable").Length<maxEnemies)
        {
            SpawnEnemy();
            timer = 0f; 
        }
    }
    void SpawnEnemy()
    {
    if(spawnPoints.Length == 0) return;
    
    int index = Random.Range(0, spawnPoints.Length);
    Transform point = spawnPoints[index];

    Instantiate(enemyPrefab, point.position, Quaternion.identity);
    }
}
