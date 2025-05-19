using System.Collections.Generic;
using UnityEngine;

public class EnemyPooler : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int poolSize = 10;  
    private Queue<GameObject> enemyPool;

    private void Start()
    {
        enemyPool = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false);
            enemyPool.Enqueue(enemy);
        }
    }
    public GameObject GetEnemyFromPool()
    {
        if (enemyPool.Count > 0)
        {
            GameObject enemy = enemyPool.Dequeue();
            enemy.SetActive(true);  
            return enemy;
        }
        else
        {
            GameObject enemy = Instantiate(enemyPrefab);
            return enemy;
        }
    }
    public void ReturnEnemyToPool(GameObject enemy)
    {
        enemy.SetActive(false);  
        enemyPool.Enqueue(enemy);  
    }
}
