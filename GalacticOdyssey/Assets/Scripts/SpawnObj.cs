using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObj : MonoBehaviour
{
    public float minY;
    public float maxY;
    public float spawnInterval = 5f, randomPosY;
    private float timeSinceLastSpawn;
    public GameObject objectsToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= spawnInterval)
        {
            randomPosY = Random.Range(minY, maxY);
            transform.position = new Vector3(transform.position.x, randomPosY, 0f);

            timeSinceLastSpawn = 0f;
            Instantiate(objectsToSpawn);
        }
    }
}
