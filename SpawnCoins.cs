using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoins : MonoBehaviour
{
    private float spawnRangeX = 19.0f;
    private float spawnRangeZ = 24.0f;
    private float startDelay = 0.5f;
    private float spawnInterval = 1.5f;

    public GameObject[] coinPrefabs; 
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomCoin", startDelay, spawnInterval);
    }   

    // Update is called once per frame
    void Update()
    {
        
    }
     void SpawnRandomCoin() 
    {
        int coinIndex = Random.Range(0, coinPrefabs.Length);
        float spawnX = Random.Range(-spawnRangeX, spawnRangeX);
        float spawnZ = Random.Range(-spawnRangeZ, spawnRangeZ);
        Debug.Log("Point: " + spawnX + ", " + spawnZ);
        Vector3 spawnpos = new Vector3(spawnX, 1, spawnZ);
        Instantiate(coinPrefabs[coinIndex], spawnpos, coinPrefabs[coinIndex].transform.rotation);
    }
}
