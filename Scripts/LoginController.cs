using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DevelopersHub;  /* Req para conectar con la API */
using UnityEngine.UI; /* Req para Inputfield, Text */

public class LoginController : MonoBehaviour
{
    public JuegoController JuegoController;
    public RecordController RecordController;
    public TestController TestController;

    public InputField InputNombre = null;
    public InputField InputPass = null;
    public Text Sugerencia;

    private string nombre;
    private int ID;
    private int record;


    void Start()
    {
        DevelopersHub.Network.Instance.OnRequestResponded += Instance_OnRequestResponded;

        RecordController = RecordController.GetComponent<RecordController>();
        JuegoController = JuegoController.GetComponent<JuegoController>();
        TestController = TestController.GetComponent<TestController>();
        Sugerencia = Sugerencia.GetComponent<Text>();
    }


    public void RegistroLogin(int tipo) //
    {
        string nombre = InputNombre.text;
        string pass = InputPass.text;

        if (!string.IsNullOrEmpty(nombre))
        {
            Dictionary<string, object> datos = new Dictionary<string, object>();
            datos.Add("nombre", nombre);
            datos.Add("pass", pass);

            DevelopersHub.Network.Instance.SendRequest(tipo, datos);
        }
    }

    public void Invitado()
    {
        JuegoController.Login("Invitado", 0, 0);
    }

    public void DescargarBanco()
    {
        DevelopersHub.Network.Instance.SendRequest(4, null);
    }

    public void ActualizarRecords() //
    {
        DevelopersHub.Network.Instance.SendRequest(2, null);
    }

    public void SubirRecord(int puntos) //
    {
        Dictionary<string, object> datos = new Dictionary<string, object>();
        datos.Add("id", ID);
        datos.Add("record", puntos);

        DevelopersHub.Network.Instance.SendRequest(3, datos);
    }

    private void Instance_OnRequestResponded(int requestID, string message, LitJson.JsonData respuesta)
    {
        if (string.IsNullOrEmpty(message))
        {
            Debug.Log("Fallo de conexion");
        }
        else
        {
            switch (requestID)
            {
                case 0:                                                         Debug.Log("API: Registro");

                    if (!respuesta.IsObject && respuesta.ToString() == "REGISTRADO")
                    {
                        Sugerencia.color = new Color(0, 1, 0, 0.5f);
                        Sugerencia.text = ("Registro completado");

                    }
                    else if (!respuesta.IsObject && respuesta.ToString() == "YA_EXISTE")
                    {
                        Sugerencia.color = new Color(1, 0, 0, 0.5f);
                        Sugerencia.text = ("Ya existe ese usuario");
                    }
                    break;

                case 1:                                                         Debug.Log("API: Login");

                    if (!respuesta.IsObject && respuesta.ToString() == "NO_EXISTE")
                    {
                        Sugerencia.color = new Color(1, 0, 0, 0.5f);
                        Sugerencia.text = ("El nombre o la contraseña no coincide");
                    }
                    else
                    {                                                           
                        Sugerencia.color = new Color(0, 1, 0, 0.5f);
                        Sugerencia.text = ("login correcto");

                        nombre = respuesta["nombre"].ToString();
                        ID = int.Parse(respuesta["id"].ToString());
                        record = int.Parse(respuesta["record"].ToString());

                        JuegoController.Login(nombre,ID,record);
                    }
                    break;

                case 2:                                                         Debug.Log("API: Cargar Records");

                    {
                         RecordController.CargarRecords(respuesta);
                    }
                    break;

                case 3:                                                         Debug.Log("API: Subir Record");
                    {
                        ActualizarRecords();
                    }
                    break;

                case 4:                                                         Debug.Log("API: Cargar Banco Preguntas");
                    {
                        TestController.BancoPreguntas(respuesta);
                    }
                    break; 
            }

        }
    }

}
