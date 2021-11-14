using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; /* Req para Text */

public class RecordController : MonoBehaviour
{

    public Text Nombre1;
    public Text Record1;
    public Text Nombre2;
    public Text Record2;
    public Text Nombre3;
    public Text Record3;
    public Text Nombre4;
    public Text Record4;
    public Text Nombre5;
    public Text Record5;

    public List<Text> nombres;
    public List<Text> records;

    void Start()
    {
        nombres.Add(Nombre1);
        nombres.Add(Nombre2);
        nombres.Add(Nombre3);
        nombres.Add(Nombre4);
        nombres.Add(Nombre5);
        records.Add(Record1);
        records.Add(Record2);
        records.Add(Record3);
        records.Add(Record4);
        records.Add(Record5);
    }

    public void CargarRecords(LitJson.JsonData respuesta) //
    {
        for (int i = 0; i < respuesta.Count; i++)
        {       
                nombres[i].text = respuesta[i]["nombre"].ToString();
                records[i].text = respuesta[i]["record"].ToString();
        }
    }
}
