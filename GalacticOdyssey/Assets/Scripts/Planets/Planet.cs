using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//To-Do
//Left move
//Speed variable
//Rotate en y
public class Planet : MonoBehaviour
{
    ///Reff
    public float movementSpeed = 1f, rotationSpeed = 1f;
    public int time;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitForDestroy());
    }

    // Para desplazarlo a izquierda
    void Update()
    {
        transform.position -= new Vector3(movementSpeed * Time.deltaTime, 0, 0);
        //transform.RotateAround(transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
        transform.RotateAround(transform.position, Vector3.forward, rotationSpeed * Time.deltaTime);
    }
    private IEnumerator waitForDestroy(){
        yield return new WaitForSecondsRealtime(time);
        Destroy(gameObject);
    }
}
