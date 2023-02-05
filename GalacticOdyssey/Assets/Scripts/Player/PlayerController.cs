using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerController : MonoBehaviour
{
    public float horizontalMove = 0f, verticalMove = 0f;
    public CharacterController player = null;
    private Vector2 playerInput, movePlayer;
    public float movementSpeed = 1f, rotationSpeed = 1f;
    public Camera mainCamera = null;
    private Vector3 camUp;
    private Vector3 camRight;
    //public Animator anim;
    public GameObject AudioSubida, AudioBajada;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();   
    }

    // Update is called once per frame
    void Update()
    {
        InputButtons();
        transform.RotateAround(transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
    }
    ///<summary>
    ///Recive imputs from player to move and shot y llamara a sus respectivas funciones
    ///</summary>
    public void InputButtons(){
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        if(verticalMove >= 0.1f)
        {
            AudioSubida.SetActive(true);
            AudioBajada.SetActive(false);
        }
        if(verticalMove <= 0f)
        {
            AudioSubida.SetActive(false);
            AudioBajada.SetActive(true);
        }
        moveShip();
    }
    public void moveShip(){
        playerInput = new Vector2(horizontalMove, verticalMove);
        camDirection();
        playerInput = Vector2.ClampMagnitude(playerInput, 1);
        movePlayer = playerInput.x * camRight + playerInput.y * camUp;
        movePlayer =movePlayer * movementSpeed;
        player.Move(movePlayer * Time.deltaTime);
    }
    public void camDirection(){
        camUp = mainCamera.transform.up;
        camRight = mainCamera.transform.right;
        camUp.z = 0;
        camRight.z = 0;
        camUp = camUp.normalized;
        camRight = camRight.normalized;
    }
    private void OnTriggerEnter(Collider other) {
        //Planetas y Asteroides
        Debug.Log(other.gameObject.tag);
        switch(other.gameObject.tag){
            case "Respawn": 
                
                   //El progreso se puede guardar despues de todos los if
                break;
            case "Asteroid"://Dead
                AudioSubida.SetActive(false);
                AudioBajada.SetActive(false);
                break;
            case "Plannet"://Animacion captura
                AudioSubida.SetActive(false);
                AudioBajada.SetActive(false);
                break;
            default :
            Debug.Log("Estoy en un trigger no esperado ");
            break;
        }
    }
}
