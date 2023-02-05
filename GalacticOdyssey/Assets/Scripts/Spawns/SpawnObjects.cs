using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public float minY;
    public float maxY;
    public float spawnInterval = 5f, randomPosY;
    private float timeSinceLastSpawn;
    public GameObject[] objectsToSpawn;
    public int selectedObjectToSpawn = 1;
    public int MaxSpawn;
    // Start is called before the first frame update
    public int LastInvoque;
    void Start()
    {
        MaxSpawn = objectsToSpawn.Length;
    }
    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= spawnInterval)
        {
            randomPosY = Random.Range(minY, maxY);
            transform.position = new Vector3(transform.position.x, randomPosY, transform.position.z);
            
            timeSinceLastSpawn = 0f;
            if (selectedObjectToSpawn > MaxSpawn)
            {
                selectedObjectToSpawn = Random.Range(0, MaxSpawn-1);
                if (LastInvoque == selectedObjectToSpawn)
                {
                    selectedObjectToSpawn = Random.Range(0, MaxSpawn-1);
                    do
                    {
                        selectedObjectToSpawn = Random.Range(0, MaxSpawn);
                    } while (LastInvoque != selectedObjectToSpawn);
                }
            }
            
            LastInvoque = selectedObjectToSpawn;
            Instantiate(objectsToSpawn[selectedObjectToSpawn]);
            
        }
    }
    //Duda aqui no se que hare porque necesito alguien que me detecte colisiones
    
}
