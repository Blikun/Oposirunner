using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; /* Req para GetComponent<Text> */

public class PuntosController : MonoBehaviour
{
    public GameObject Personaje;
    public GameObject Puntos;
    public float bonus;

    private Text Puntuacion;
    public float movescore;
    public int pregscore;
    public int score;

    void Start()
    {
        Puntuacion = Puntos.GetComponent<Text>();
        Puntuacion.text = "0";

        score = 0;
        movescore = 0;
        pregscore = 0;
        
    }

    void FixedUpdate()
    {
        movescore = Personaje.GetComponent<Transform>().localPosition.x;
        score = ((int)movescore + pregscore);
        Puntuacion.text = "" + (score);
    }

    public void Sumar()
    {
        pregscore = pregscore + 100;
    }

    public int PuntosActuales()
    {
        return score;
    }

    public void Reset()
    {
        score = 0;
        movescore = 0;
        pregscore = 0;
    }
}
