using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public List<GameObject> enemies;
    public int count;
    public float rate;

    public GameObject GetRandomEnemy()
    {
       
        int randomIndex = Random.Range(0, enemies.Count);
        return enemies[randomIndex];
    }
}
