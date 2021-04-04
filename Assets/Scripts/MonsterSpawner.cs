using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public EnemiesDb enemiesDb;
    public GameObject enemyPrefab;
    public GameObject playerObject;

    public int[] Enemies;
    

    Enemy current;
    

    
    void Start()
    {        
        
    }    

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnWaveOfEnemies(int waveIndex)
    {
        for (int w = 0; w < waveIndex; w++)
        {
            for (int i = 0; i < Enemies.Length; i++)
            {
                current = enemiesDb.GetEnemyData(i);
                for (int j = 0; j < Enemies[i]; j++)
                {
                    var obj = Instantiate(enemyPrefab, transform.position, Quaternion.identity, transform);
                    obj.GetComponent<SpriteRenderer>().sprite = current.image;
                    obj.GetComponent<AIPath>().maxSpeed = current.movespeed;
                    obj.GetComponent<AIDestinationSetter>().target = playerObject.transform;
                }
            }
        }
        if (waveIndex%3==0)
        {
            current = enemiesDb.GetEnemyData(7);
            var obj = Instantiate(enemyPrefab, transform.position, Quaternion.identity, transform);
            obj.GetComponent<SpriteRenderer>().sprite = current.image;
            obj.GetComponent<AIPath>().maxSpeed = current.movespeed;
            obj.GetComponent<AIDestinationSetter>().target = playerObject.transform;
        }
    }

    //public void TestSpawnButton()
    //{
    //    SpawnWaveOfEnemies(1, spawnerPosition);
    //}
}
