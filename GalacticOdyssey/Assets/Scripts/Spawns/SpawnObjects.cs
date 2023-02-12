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
    public int selectedObjectToSpawn = 6;
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
            
            
            timeSinceLastSpawn = 0f;
            while(selectedObjectToSpawn == LastInvoque)
            {
                selectedObjectToSpawn = Random.Range(0, MaxSpawn);
                Debug.Log(selectedObjectToSpawn);
            }
            
            
           
            LastInvoque = selectedObjectToSpawn;
            GameObject spawned  =Instantiate(objectsToSpawn[selectedObjectToSpawn]);
            //Cada objeto deberemos asignar bien su transform de X e Z para que spawneen fuera del mapa
            spawned.transform.position = new Vector3(spawned.transform.position.x, randomPosY, spawned.transform.position.z);

        }
    }
    //Duda aqui no se que hare porque necesito alguien que me detecte colisiones
    
}
