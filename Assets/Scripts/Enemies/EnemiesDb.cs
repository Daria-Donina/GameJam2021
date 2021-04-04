using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemiesDatabase", menuName = "EnemiesDatabase/EnemiesPool")]
public class EnemiesDb : ScriptableObject
{
    public Enemy[] EnemiesPool;
    public Dictionary<int, Enemy> GetById = new Dictionary<int, Enemy>();

    public Enemy GetEnemyData(int id)
    {
        return EnemiesPool[id];
    }
}


public abstract class Enemy : ScriptableObject
{
    public int id;
    public Type type;    
    public float health;
    public float damage;
    public float movespeed;
    public Sprite image;
    [TextArea(15, 20)] public string description;    

}

public enum Type
{
    Simple,
    LightArmored,
    HeavyArmored,
    Explosive
}



