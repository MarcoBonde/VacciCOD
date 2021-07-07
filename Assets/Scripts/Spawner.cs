using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private int waveNumber = 0;
    private int enemySpawnAmount = 0;
    private int enemiesKilled = 0;


    public GameObject[] spawners;
    public GameObject enemy;
        
    private void Start()
    {
        spawners = new GameObject[5];
        for(int i = 0; i<spawners.Length; i++)  
        {
            spawners[i] = transform.GetChild(i).gameObject;
        }

        StartWave();
    }

    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) //testing
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        int spawnerID = Random.Range(0, spawners.Length);
        Instantiate(enemy, spawners[spawnerID].transform.position, spawners[spawnerID].transform.rotation);
    }

    private void StartWave()
    {
        waveNumber = 1;
        enemySpawnAmount = 2;
        enemiesKilled = 0;

        for(int i =0; i<enemySpawnAmount; i++)
        {
            SpawnEnemy();
        }
    }

    private void NextWave()
    {
        waveNumber++;
        enemySpawnAmount += 2;
        enemiesKilled = 0;

        for (int i = 0; i < enemySpawnAmount; i++)
        {
            SpawnEnemy();
        }
    }
        
}
