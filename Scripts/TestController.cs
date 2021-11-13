using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; /* Req para Text */

public class TestController : MonoBehaviour
{
    public JuegoController JuegoController;

    public GameObject BotonA;
    public GameObject BotonB;
    public GameObject BotonC;
    public GameObject BotonD;

    public Text TextoA;
    public Text TextoB;
    public Text TextoC;
    public Text TextoD;
    public Text TextoDescripcion;

    static LitJson.JsonData Banco;
    static int sizeBanco;
    private int i;
    
    void Start()
    {
        JuegoController = JuegoController.GetComponent<JuegoController>();
    }

    public void BancoPreguntas(LitJson.JsonData respuesta )
    {
        Banco = respuesta;
        sizeBanco = Banco["preguntas"].Count;                                   Debug.Log(">> Tamaño banco preguntas: " + sizeBanco);
    }

    public void CargarTest()
    {
        JuegoController.Pausar();
        this.gameObject.SetActive(true);

        TextoDescripcion = GameObject.Find("textodescripcion").GetComponentInChildren<Text>();
        TextoA = GameObject.Find("botona").GetComponentInChildren<Text>(); //todo: mejorar la manera de acceder.
        TextoB = GameObject.Find("botonb").GetComponentInChildren<Text>();
        TextoC = GameObject.Find("botonc").GetComponentInChildren<Text>();
        TextoD = GameObject.Find("botond").GetComponentInChildren<Text>();

        i = Random.Range(0,sizeBanco);

        TextoDescripcion.text = StringPregunta(i);
        TextoA.text = StringRespuesta(i, 0);
        TextoB.text = StringRespuesta(i, 1);
        TextoC.text = StringRespuesta(i, 2);
        TextoD.text = StringRespuesta(i, 3);
    }

    private string StringPregunta(int i)
    {
        return Banco["preguntas"][i]["descripcion"].ToString(); ;
    }

    private string StringRespuesta(int i, int num)
    {
        return Banco["preguntas"][i]["respuestas"][num]["descripcion"].ToString();
    }

    public void comprobar(int num)
    {
        if (Banco["preguntas"][i]["respuestas"][num]["es_correcta"].ToString() == "1")
        {
            JuegoController.Acierto(true);
        }
        else
        {
            JuegoController.Acierto(false);
        }

        CerrarTest();
        JuegoController.Reanudar();
    }

    public void CerrarTest()
    {
        this.gameObject.SetActive(false);
    }
}
