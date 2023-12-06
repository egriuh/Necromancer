using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Variables
    public GameObject[] ingrediantPrefabs;

    private float spawnRangeX = 103;
    private float spawnRangeZ = 113;
    private float startDelay = 1;
    private float spawnInterval = 1;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomAnimal()
    {
        float spawnX = Random.Range(-spawnRangeX, spawnRangeX);
        float spawnY = 0.18f;
        float spawnZ = Random.Range(-spawnRangeZ, spawnRangeZ);

        Vector3 spawnPos = new Vector3(spawnX, spawnY, spawnZ);
        int ingrediantIndex = Random.Range(0, ingrediantPrefabs.Length);
        Instantiate(ingrediantPrefabs[ingrediantIndex], spawnPos, ingrediantPrefabs[ingrediantIndex].transform.rotation);
    }
}
