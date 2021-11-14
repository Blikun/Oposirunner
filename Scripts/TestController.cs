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

    public Sprite spriteVerde;
    public Sprite spriteRojo;
    public Sprite spriteNormal;

    static LitJson.JsonData Banco;
    static int sizeBanco;
    private bool activo = true;
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
        desmarcar();
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
        if (Banco["preguntas"][i]["respuestas"][num]["es_correcta"].ToString() == "1" && activo == true)
        {
            marcar(true, num);
            JuegoController.Acierto(true);
        }
        else if (activo == true)
        {
            marcar(false, num);
            JuegoController.Acierto(false);
        }

        StartCoroutine(delay(2f));
        
    }

    IEnumerator delay(float segundos)
    {
        activo = false;
        yield return new WaitForSecondsRealtime(segundos);
        activo = true;
        CerrarTest();
    }

    public void marcar(bool TF, int num)
    {
        Sprite spritecolor;

        if (TF) { spritecolor = spriteVerde; }
        else { spritecolor = spriteRojo; } 

        switch (num)
        {
            case 0: { BotonA.GetComponent<Image>().sprite = spritecolor; } break; //todo: mejorar .
            case 1: { BotonB.GetComponent<Image>().sprite = spritecolor; } break;
            case 2: { BotonC.GetComponent<Image>().sprite = spritecolor; } break;
            case 3: { BotonD.GetComponent<Image>().sprite = spritecolor; } break;
        }
    }

    public void desmarcar()
    {
        BotonA.GetComponent<Image>().sprite = spriteNormal;   //todo: mejorar 
        BotonB.GetComponent<Image>().sprite = spriteNormal; 
        BotonC.GetComponent<Image>().sprite = spriteNormal; 
        BotonD.GetComponent<Image>().sprite = spriteNormal; 
    }

    public void CerrarTest()
    {
        this.gameObject.SetActive(false);
        JuegoController.Reanudar();
    }


}
