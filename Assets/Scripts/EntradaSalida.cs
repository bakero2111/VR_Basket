using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntradaSalida : MonoBehaviour
{
    public float VelocidadAccion;
    public void Entrada()
    {
        this.transform.DOScale(1.30283f, VelocidadAccion);
    }
    public void Salida()
    {
        this.transform.DOScale(0.1f, VelocidadAccion);
    }
}
