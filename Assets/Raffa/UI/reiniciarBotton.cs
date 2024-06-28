using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reiniciarBotton : MonoBehaviour
{
    void OnCollisionEnter(Collision Presion){
        if(Presion.gameObject.tag=="Boton/Presionado"){
            
        SceneManager.LoadScene(1);

        }
    }
    
}
