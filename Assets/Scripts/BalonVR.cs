using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalonVR : MonoBehaviour
{
    Rigidbody rb;
    public Transform Direct;
    public float FuerzaImpulso;

    public ManagerPointsGame ControladorGame;
    //Animator _animcomp;
    public TrailRenderer Trencito;
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
       // _animcomp = GetComponent<Animator>();
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            Destroy(this.gameObject);
            ControladorGame.PuntoErrado();
            Debug.Log("Cayó");
        }
        if (collision.gameObject.tag == "Anotacion")
        {
            Destroy(this.gameObject);
            Debug.Log("Anotacion");
        }
    }
    /*
    private void OnMouseDown()
    {
        if (ControladorGame.intentos < ControladorGame.intentoMaximos)
        {
            rb.useGravity = true;
            transform.parent = null;
            Vector3 delante = Direct.position - transform.position;
            rb.AddForce(delante * FuerzaImpulso);
           
            Trencito.enabled = true;
        }
    }
    */
    public void ControladorCollider()
    {
        //this.gameObject.GetComponent<SphereCollider>().excludeLayers = 5;
        
        this.gameObject.GetComponent<SphereCollider>().excludeLayers = 7 << 7;
        this.gameObject.GetComponent<SphereCollider>().excludeLayers = 7 << 6;
        //rb.isKinematic = true;
        //this.gameObject.GetComponent<SphereCollider>().excludeLayers = 7;
        // this.gameObject.GetComponent<SphereCollider>().excludeLayers = 8;
    }
    public void QuitarControladorCollider()
    {
        this.gameObject.GetComponent<SphereCollider>().excludeLayers = 0;
        //rb.isKinematic = false;
    }
}
