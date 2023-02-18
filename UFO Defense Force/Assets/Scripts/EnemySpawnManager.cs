using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject[] ufoPrefabs; // array to store ufo ships
    private float spawnRangeX = 20f;
    private float spawnPosZ = 20f;

    private float startDelay = 2f;
    private float spawnInterval = 1.5f;

    void Start()
    {
        InvokeRepeating("SpawnRandomUFO", startDelay, spawnInterval);
    }
   
    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomUFO()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        int ufoIndex = Random.Range(0,ufoPrefabs.Length); // picks a random ufo from the array
        Instantiate(ufoPrefabs[ufoIndex],spawnPos, ufoPrefabs[ufoIndex].transform.rotation); // spawns a indexed ufo from the array a rondom location on the x axis
    }
}
