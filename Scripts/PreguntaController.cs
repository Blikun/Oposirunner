using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreguntaController : MonoBehaviour
{

    public GameObject Personaje;
    public JuegoController JuegoController;


    void Start()
    {
        /* como pregunta se crea instanciado necesita buscar el Gameobject para sacar un componente. todo: Gameobject.Find */
        
        Personaje = GameObject.Find("Personaje");
        GameObject Juego = GameObject.Find("Juego");
        JuegoController = Juego.GetComponent<JuegoController>();
    }


    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.GetComponent<PersonajeController>())
        {       
            JuegoController.Pregunta();
            Destroy(transform.gameObject);
        }
    }
}
