using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerPointsGame : MonoBehaviour
{
    int PuntosMaximos;
    int PuntosAcumulados = 0;
    int ErroresAcumulados = 0;

    public int intentoMaximos = 5;
    int ErroresMaximos = 3;
    public int intentos = 0;

    public List<GameObject> Puntos = new List<GameObject>();

    Material Colorrender;
    public Color RojoVino;
    public Color VerdeEsperanza;
    public float IntensidadHDR;
    public GameObject WinnerChampion;
    public GameObject LoserPerd;
    public Transform PuntoAparicion;

    public float VelWinLose;

    public GameObject Bloque;
    public Animator Tablero;

    AudioSource Sonidos;
    public AudioClip GanadoPunto;
    public AudioClip PerdidoPunto;

    public MenuManeger menuManager;
    [SerializeField] GameObject menuObject;
    public GameObject _victory;
    public GameObject _defeat;

    [Header("FeedBack")]
    public GameObject ParentFeed;

    [Header("Pelotas")]
    public GameObject PelotasCestas;
    private void Awake()
    {
        menuManager = menuObject.GetComponent<MenuManeger>();
    }
    private void Start()
    {
        PuntosMaximos = Puntos.Count;
        intentoMaximos = Puntos.Count;
        Sonidos = GetComponent<AudioSource>();
        
    }
    
    public void PuntoAcierto()
    {
        ParentFeed.SetActive(true);
        StartCoroutine(EmpezarFeedback());
        Sonidos.PlayOneShot(GanadoPunto);

        Colorrender = Puntos[intentos].GetComponent<MeshRenderer>().material;
        Colorrender.SetColor("_Color", VerdeEsperanza);
        Colorrender.EnableKeyword("_EMISSION");
        Vector4 colorHDR = new Vector4(VerdeEsperanza.r * IntensidadHDR, VerdeEsperanza.g * IntensidadHDR, VerdeEsperanza.b * IntensidadHDR, VerdeEsperanza.a);
        Colorrender.SetColor("_EmissionColor", colorHDR);

        PuntosAcumulados++;
        intentos++;
        if (PuntosAcumulados == 1)
        {
            Bloque.SetActive(true);
            Tablero.enabled = false;
            if(intentos % 2 == 0)
            {
                Tablero.gameObject.GetComponent<Transform>().position = new Vector3(Tablero.gameObject.GetComponent<Transform>().position.x + 0.7f, Tablero.gameObject.GetComponent<Transform>().position.y, Tablero.gameObject.GetComponent<Transform>().position.z);
            }
            else
            {
                Tablero.gameObject.GetComponent<Transform>().position = new Vector3(Tablero.gameObject.GetComponent<Transform>().position.x - 0.7f, Tablero.gameObject.GetComponent<Transform>().position.y, Tablero.gameObject.GetComponent<Transform>().position.z);
            }
        }
        if (PuntosAcumulados == 2)
        {
            //Bloque.SetActive(false);
            Tablero.enabled = true;


        }
        if (intentos == intentoMaximos || PuntosAcumulados ==ErroresMaximos )
        {
            MaxIntentos();
        }
    }
    IEnumerator EmpezarFeedback(){

        yield return new WaitForSeconds(3);
ParentFeed.SetActive(false);
    }
    public void PuntoErrado()
    {
        Sonidos.PlayOneShot(PerdidoPunto);
        Colorrender = Puntos[intentos].GetComponent<MeshRenderer>().material;
        Colorrender.SetColor("_Color", RojoVino);
        Colorrender.EnableKeyword("_EMISSION");
        Vector4 colorHDR = new Vector4(RojoVino.r * IntensidadHDR, RojoVino.g * IntensidadHDR, RojoVino.b * IntensidadHDR, RojoVino.a);
        Colorrender.SetColor("_EmissionColor", colorHDR);
        ErroresAcumulados++;
        intentos++;


        if (intentos == intentoMaximos || ErroresAcumulados ==ErroresMaximos)
        {
            MaxIntentos();
        }
    }
    public void MaxIntentos()
    {
        Bloque.SetActive(false);
        PelotasCestas.SetActive(false);
        if(PuntosAcumulados>=ErroresMaximos) // ganaste
        {
            WinnerChampion.SetActive(true);
            WinnerChampion.transform.DOMove(PuntoAparicion.position, 4).SetEase(Ease.OutElastic);
            WinnerChampion.transform.DOScale(1, VelWinLose);
            //menuManager.VictoryScreen();
            StartCoroutine(VictoryScreen());
        }
        if (PuntosAcumulados < ErroresMaximos) // perdiste
        {
            LoserPerd.SetActive(true);
            LoserPerd.transform.DOMove(PuntoAparicion.position, 4).SetEase(Ease.OutElastic);
            LoserPerd.transform.DOScale(1, VelWinLose);
            //menuManager.DefeatScreen();
            StartCoroutine (DefeatScreen());
        }
    }
    public IEnumerator VictoryScreen()
    {
        yield return new WaitForSeconds(3f);
        _victory.SetActive(true);
    }
    public IEnumerator DefeatScreen()
    {
        yield return new WaitForSeconds(3f);
        _defeat.SetActive(true);
    }
}
