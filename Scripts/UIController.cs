using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; /* Req para GetComponent<Button> */

public class UIController : MonoBehaviour
{
    public JuegoController JuegoController;
    public PostLogin PostLoginController;
    public GameObject ReintentarBTN;
    public GameObject PausarBTN;
    public GameObject FinBTN;
    public GameObject Login;
    public GameObject PostLogin;
    public GameObject Menu;

    private string nombre;
    private int record;


    void Start()
    {
        JuegoController = JuegoController.GetComponent<JuegoController>();
        Button ReintentarButton = ReintentarBTN.GetComponent<Button>();
        ReintentarButton.onClick.AddListener(ReintentarClick);
        
    }

    public void MostrarLogin(bool yesno)
    {

        Login.gameObject.SetActive(yesno);
    }

    public void MostrarPostLogin(bool yesno)
    {
        PostLoginController.ActualizarUsuario(nombre, record);
        PostLogin.gameObject.SetActive(yesno);
    }

    public void MostrarMenu(bool yesno)
    {
        
        FinBTN.gameObject.SetActive(!yesno);
        PausarBTN.gameObject.SetActive(!yesno);
        BloquearPausa(false);
        Menu.gameObject.SetActive(yesno);
        ReintentarBTN.gameObject.SetActive(false);
    }

    public void MostrarReintentar(bool yesno)
    {
        ReintentarBTN.gameObject.SetActive(yesno);
    }

    public void ActualizarUsuario(string nombrelogin, int recordlogin)
    {
        nombre = nombrelogin; record = recordlogin;
        PostLoginController.ActualizarUsuario(nombre, record);
    }

    public void ReintentarClick()
    {
        MostrarReintentar(false);
        JuegoController.Reiniciar();
    }

    public void BloquearPausa(bool yesno)
    {
        Button PausarButton = PausarBTN.GetComponent<Button>();
        PausarButton.interactable = !yesno;
        Button PausarButton2 = PausarBTN.GetComponentInChildren<Button>();
        PausarButton2.interactable = !yesno;

    }
    
}
