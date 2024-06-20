using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punto : MonoBehaviour
{

    public ManagerPointsGame ControladorGame;
    public GameObject Particula;
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Balon/Triggerer")
        {
            //other.GetComponentInParent<BalonRb>().RegresarPunto();
            Particula.SetActive(true);
            ControladorGame.PuntoAcierto();
            Debug.Log("anotacion1 Desde Punto");
        }
    }
}
