using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; /* req para Text */

public class PostLogin : MonoBehaviour
{

    public Text TextNombre;
    public Text TextRecord;

    private string nombre;
    private int record;

    void Start()
    {
        TextNombre = TextNombre.GetComponent<Text>();
        TextRecord = TextRecord.GetComponent<Text>();
    }

    public void ActualizarUsuario(string nombrelogin, int recordlogin)
    {
        nombre = nombrelogin; record = recordlogin;
        TextNombre.text = nombre;
        TextRecord.text = record.ToString();
    }
}
