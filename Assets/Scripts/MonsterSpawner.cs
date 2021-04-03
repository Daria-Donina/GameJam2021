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
    Vector3 spawnerPosition;

    // Start is called before the first frame update
    void Start()
    {
        spawnerPosition = transform.position;
        SpawnWaveOfEnemies(1, spawnerPosition);
        
    }    

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnWaveOfEnemies(int wavesCount, Vector3 place)
    {
        for (int k = 0; k < wavesCount; k++)
        {
            for (int i = 0; i < Enemies.Length; i++)
            {
                current = enemiesDb.GetEnemyData(i);
                for (int j = 0; j < Enemies[i]; j++)
                {
                    var obj = Instantiate(enemyPrefab, place, Quaternion.identity, transform);
                    obj.GetComponent<SpriteRenderer>().sprite = current.image;
                    obj.GetComponent<AIPath>().maxSpeed = current.movespeed;
                    obj.GetComponent<AIDestinationSetter>().target = playerObject.transform;
                }
            }
        }
    }

    public void TestSpawnButton()
    {
        SpawnWaveOfEnemies(1, spawnerPosition);
    }
}
