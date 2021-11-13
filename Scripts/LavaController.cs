using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaController : MonoBehaviour

{
    public JuegoController JuegoController;
    
    
    void OnStart()
    {
        JuegoController = JuegoController.GetComponent<JuegoController>();
    }

    void OnTriggerEnter2D(Collider2D other)   // El Lavacontroller tiene un Collider bajo cámera.
    {
        if (other.GetComponent<PersonajeController>())
           // Para detectar si cae el personaje.
        {
            JuegoController.GameOver();
        }
    }
}
