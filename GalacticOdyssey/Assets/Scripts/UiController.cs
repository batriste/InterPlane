using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{
    public bool isActive = false;
    public GameObject menuPause, imageText, imageTextDead;
    public GameObject[] imageBackGround;
    public float movementSpeed = 1f;
    public bool StartCoroutines = true;
    public bool image1 = true, image2 = false;
    public GameObject captura, spe;
    public GameObject killed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveBackGround();
        
        if (Input.GetKeyDown("escape")){
            isActive = !isActive;
            menuPause.SetActive(isActive);
            if(isActive){
            Time.timeScale = 0;}else{
                Time.timeScale = 1;
            } 
        }
    }
    
    
    public void moveBackGround(){
        StartCoroutine(waitForMove(1, 0));
        StartCoroutine(waitForMove(1, 1));
    }
   
    public void changeS(int pos){
     
        imageBackGround[pos].transform.position = imageBackGround[2].transform.position;
        
    }
    private IEnumerator waitForMove(int time, int pos){
        yield return new WaitForSecondsRealtime(time);
        imageBackGround[pos].transform.position -= new Vector3(movementSpeed * Time.deltaTime, 0, 0);
    }
    private void OnTriggerEnter(Collider other) {
        //Planetas y Asteroides
        Debug.Log(other.gameObject.tag);
        if(other.gameObject.tag == "Respawn"){
            
        }switch(other.gameObject.tag){
            case "Respawn": //Lo usamos para los background que se vuelvan un bucle
            if (image1 == false && image2 == false){
                image1 = !image1;
            }else{
                
                if(image1){
                    // UiControll.changeSite(0);
                   
                    StartCoroutine(waitToTransport(3, 0));
                    image1 = !image1;
                    }
                else{
                    if(image2){
                        // UiControll.changeSite(1);
                        
                        StartCoroutine(waitToTransport(3, 1));
                        image2 = !image2;
                    }else{
                        //Este checkpoint seria de progreso
                        image2 = !image2;
                    }
                }
            }
                break;
            case "Asteroid"://Dead
                imageText.SetActive(false);
                imageTextDead.SetActive(true);
                menuPause.SetActive(true);
                killed.SetActive(true);
                Destroy(gameObject);
                Time.timeScale = 1;
                //Animacion de muerte(Imagen)

                break;
            case "Plannet"://Animacion captura si salgo que se desactive
                spe.SetActive(true);
                StartCoroutine(waitToChangeAudio(3));
                //Activamos spe

                //Esperamos 3 segundos
                //Quitamos spe y ponemos onda
            break;
            default :
            Debug.Log("Estoy en un trigger no esperado ");
            break;
        }
    }
    private void OnTriggerExit(Collider other)
    {
            if (other.gameObject.tag == "Plannet")
        {
            
            spe.SetActive(false);
            StartCoroutine(waitToOffAudio(5));
        }
            
    }
    private IEnumerator waitToChangeAudio(int time)
    {
        yield return new WaitForSecondsRealtime(time);
        spe.SetActive(false);
        captura.SetActive(true);
        StartCoroutine(waitToOffAudio(3));
    }
    private IEnumerator waitToOffAudio(int time)
    {
        yield return new WaitForSecondsRealtime(time);
        
        captura.SetActive(false);
    }
    private IEnumerator waitToTransport(int time, int pos){
         yield return new WaitForSecondsRealtime(time);
         changeS(pos);
    }
    public void Continue(){
        //Continuaria
        isActive = !isActive;
            menuPause.SetActive(isActive);
            if(isActive){
            Time.timeScale = 0;}else{
                Time.timeScale = 1;
            } 
    }
    public void Exit(){
        Application.Quit();
    }
}

