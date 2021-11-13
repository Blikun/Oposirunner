using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    public GameObject Personaje;  

    void Update()
    { 
        Vector3 posicion = transform.position;
        
        posicion.x = Personaje.transform.position.x;
        transform.position = posicion;
    }   
}
