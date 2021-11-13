using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; /* Req para Slider */

public class PersonajeController : MonoBehaviour
{

    public float velocidad;        
    public float fuerzaSalto;
    public bool volando;
    public LayerMask suelo; /*capa de los chunks*/
    public float offsetRaycastI;
    public float offsetRaycastD;
    public GameObject SpriteModelo;

    public Slider Slider;

    private Rigidbody2D Rigidbody; 
    private Collider2D Collider;


    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();  
        Collider = GetComponent<Collider2D>();
    }

    void Update()
    {
        Rigidbody.velocity = new Vector2(velocidad, Rigidbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.W)) Saltar(); 
    }

    private void Saltar() {

        volando = !Physics2D.IsTouchingLayers(Collider, suelo);
        if (volando == false)
        {
            Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, fuerzaSalto);
        }     
    }

    public void color()
    {
        SpriteRenderer SpriteRenderer = transform.GetComponent<SpriteRenderer>();
        SpriteRenderer SpriteRendererModelo = SpriteModelo.GetComponent<SpriteRenderer>();

        if (Slider.value == 0)
        {
            SpriteRenderer.color = Color.white;
            SpriteRendererModelo.color = Color.white;
        }
        else
        {
            SpriteRenderer.color = Color.HSVToRGB(Slider.value, 1, 1);
            SpriteRendererModelo.color = Color.HSVToRGB(Slider.value, 1, 1);
        }

    }

}
