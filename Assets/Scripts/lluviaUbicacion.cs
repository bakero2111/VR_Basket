using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lluviaUbicacion : MonoBehaviour
{
    public Transform seguir;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(seguir.position.x, this.transform.position.y, seguir.position.z);
    }
}
