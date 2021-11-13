using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiempoController : MonoBehaviour
{
    public JuegoController JuegoController;
    public GameObject BarraTiempo;

    private RectTransform RectTransform;
    private float Tiempo;
    private float Extra = 0.8f;
    private bool activo;

    void Start()
    {
        JuegoController = JuegoController.GetComponent<JuegoController>();
        RectTransform = BarraTiempo.GetComponent<RectTransform>();
        activo = false;
    }

    void Update()
    {
        Tick();
        RectTransform.sizeDelta = new Vector2(Tiempo, 0.1974f);
    }

    private void Tick()
    {
        if (Tiempo > 0 && activo == true)
        {
            Tiempo -= (Time.deltaTime / 12);
        }
        else if (activo == true)
        {
            activo = false;
            JuegoController.GameOver();
        }
    }

    public void Sumar()
    {
        if (Tiempo + Extra > 3f)
        {
            Tiempo = 3f;
        }
        else Tiempo = Tiempo + Extra;
    }

    public void Reset()
    {
        Tiempo = 3f;
        activo = true;
    }
}
