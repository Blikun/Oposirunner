using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuegoController : MonoBehaviour
{
    public UIController UIController;
    public LoginController LoginController;
    public PuntosController PuntosController;
    public GeneradorMapa GeneradorMapa;
    public TiempoController TiempoController;
    public TestController TestController;
    public PausaPlay PausaPlay;
    public GameObject Personaje;

    public string nombre = "Invitado";
    public int id = 0;
    public int record = 0;
    private int puntos;


    void Start()
    {
        UIController = UIController.GetComponent<UIController>();
        PuntosController = PuntosController.GetComponent<PuntosController>();
        GeneradorMapa = GeneradorMapa.GetComponent<GeneradorMapa>();
        TiempoController = TiempoController.GetComponent<TiempoController>();
        LoginController = LoginController.GetComponent<LoginController>();
        TestController = TestController.GetComponent<TestController>();
        PausaPlay = PausaPlay.GetComponent<PausaPlay>();

        UIController.MostrarMenu(true);
        UIController.MostrarLogin(true);
        UIController.MostrarPostLogin(false);
        TestController.CerrarTest();
        LoginController.ActualizarRecords();
        LoginController.DescargarBanco();

        Pausar();
    }

    public void Login(string nombrelogin, int idlogin, int recordlogin)
    {
        nombre = nombrelogin; id = idlogin; record = recordlogin;
                                                                                Debug.Log("Usuario: "+nombre+" ID: "+id+" Record: "+record);
        UIController.ActualizarUsuario(nombre, record);
        UIController.MostrarLogin(false);
        UIController.MostrarPostLogin(true);
    }

    public void Pausar()
    {
        Time.timeScale = 0;
    }

    public void BloquearPausa(bool yesno)
    {
        UIController.BloquearPausa(yesno);
    }

    public void Reanudar()
    {
        Time.timeScale = 1;
    }

    public void Salir()
    {
        Pausar();
        TestController.CerrarTest();
        UIController.MostrarMenu(true);
    }

    public void GameOver()
    {
        Pausar();
        puntos = PuntosController.PuntosActuales();

        if (nombre != "Invitado" && puntos > record)
        {
            record = puntos;
            LoginController.SubirRecord(puntos);
            UIController.ActualizarUsuario(nombre, record);
        }

        TestController.CerrarTest();
        UIController.MostrarReintentar(true);
    }

    public void Reiniciar()
    {  
        Personaje.GetComponent<Transform>().localPosition = new Vector3(0, 0.5f, 0);
        PausaPlay.Reset();
        GeneradorMapa.Reset();
        PuntosController.Reset();
        TiempoController.Reset();
        UIController.MostrarMenu(false);

        Reanudar();
    }

    public void Pregunta()
    {
        BloquearPausa(true);
        TestController.CargarTest();
    }

    public void Acierto(bool respuestaCorrecta)
    {  
        if (respuestaCorrecta == true)
        {
            PuntosController.Sumar();
            TiempoController.Sumar();
        }
        else { }

        BloquearPausa(false);
    }

}
