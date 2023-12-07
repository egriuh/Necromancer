using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Variables
    public GameObject[] ingrediantPrefabs;
    public GameObject zombie;

    private float spawnRangeX = 103;
    private float spawnRangeXZombie = 3;
    private float spawnRangeZ = 113;
    private float spawnRangeZZombie = 3;
    private float startDelay = 1;
    private float startDelayZombie = 5;
    private float spawnInterval = 1;
    private float spawnIntervalZombie = 10;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomIngrediant", startDelay, spawnInterval);
        InvokeRepeating("SpawnRandomZombie", startDelayZombie, spawnIntervalZombie);
        //zombie = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomZombie()
    {
        float spawnXZombie = Random.Range(-spawnRangeXZombie, spawnRangeXZombie);
        float spawnZZombie = Random.Range(-spawnRangeZZombie, spawnRangeZZombie);

        Vector3 spawnPosZombie = new Vector3(spawnXZombie, 0, spawnZZombie);
        Instantiate(zombie, spawnPosZombie, transform.rotation);
    }

    void SpawnRandomIngrediant()
    {
        float spawnX = Random.Range(-spawnRangeX, spawnRangeX);
        float spawnY = 0.18f;
        float spawnZ = Random.Range(-spawnRangeZ, spawnRangeZ);

        Vector3 spawnPos = new Vector3(spawnX, spawnY, spawnZ);
        int ingrediantIndex = Random.Range(0, ingrediantPrefabs.Length);
        Instantiate(ingrediantPrefabs[ingrediantIndex], spawnPos, ingrediantPrefabs[ingrediantIndex].transform.rotation);
    }
}
