
using UnityEngine;

public class BalonRb : MonoBehaviour
{
    Rigidbody rb;
    public Transform Direct;
    public float FuerzaImpulso;
    public Transform PosInicio;
    GameObject padre;

    public ManagerPointsGame ControladorGame;
    Animator _animcomp;
    public TrailRenderer Trencito;
    public void Start()
    {
         rb = GetComponent<Rigidbody>();
       // PosInicio = transform.position;
        padre = transform.parent.gameObject;
        _animcomp = GetComponent<Animator>();
    }
    /*
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.D) && ControladorGame.intentos<ControladorGame.intentoMaximos)
        {
            rb.useGravity = true;
            transform.parent = null;
            Vector3 delante = Direct.position-transform.position;
            rb.AddForce(delante * FuerzaImpulso);
        }
    }
    */
    public void RegresarPunto()
    {
        rb.Sleep();
        rb.useGravity = false;
        transform.parent = padre.transform;
        this.transform.position = PosInicio.position;
        this.transform.rotation = new Quaternion(0, 0, 0, 0);
        rb.Sleep();
        _animcomp.enabled = true;
        Trencito.enabled = false;
    }
    /*public void ReiniciarEscena()
    {
        _animcomp.enabled = false;
        // Obtén el nombre de la escena actual y cárgala nuevamente
        Scene escenaActual = SceneManager.GetActiveScene();
        SceneManager.LoadScene(escenaActual.name);

    }*/
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Suelo")
        {
            RegresarPunto();
            ControladorGame.PuntoErrado();
            Debug.Log("Cayó");
        }
        if (collision.gameObject.tag == "Anotacion")
        {
            RegresarPunto();
            Debug.Log("Anotacion");
        }
    }
    private void OnMouseDown()
    {
        if (ControladorGame.intentos < ControladorGame.intentoMaximos)
        {
            rb.useGravity = true;
            transform.parent = null;
            Vector3 delante = Direct.position - transform.position;
            rb.AddForce(delante * FuerzaImpulso);
            _animcomp.enabled = false;
            Trencito.enabled = true;
        }
        /*if (ControladorGame.intentos == ControladorGame.intentoMaximos)
            ReiniciarEscena();*/
    }

}
