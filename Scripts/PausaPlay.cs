using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; /* Req para GetComponent<Image> */

public class PausaPlay : MonoBehaviour
{
    public JuegoController JuegoController;
    public Sprite pausaSprite;
    public Sprite playSprite;

    private bool pausa = true;

    void Start()
    {
        JuegoController = JuegoController.GetComponent<JuegoController>();
    }

    public void cambiar()
    {
        if (pausa == true)
        {
            transform.GetComponent<Image>().sprite = playSprite;
            JuegoController.Pausar();
            pausa = false;
        }
        else
        {
            transform.GetComponent<Image>().sprite = pausaSprite;
            JuegoController.Reanudar();
            pausa = true;
        } 
    }

    public void Reset()
    {
        transform.GetComponent<Image>().sprite = pausaSprite;
        pausa = true;
    }
}
