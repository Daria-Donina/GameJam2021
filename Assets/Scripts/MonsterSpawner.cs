using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public EnemiesDb enemiesDb;
    public GameObject enemyPrefab;

    public int[] Enemies;
    Enemy current;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Enemies.Length; i++)
        {
            var obj = Instantiate(enemyPrefab, Vector3.zero, Quaternion.identity, transform);
            current = enemiesDb.GetEnemyData(1);
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
