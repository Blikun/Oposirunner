using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public GameObject camara;
    public float magnitud;

    private float size;
    private float inicio;

    void Start()
    {
        inicio = transform.position.x;
        size = GetComponent<SpriteRenderer>().bounds.size.x;
    }

   
    void Update()
    {

        float avance = (camara.transform.position.x * (1 - magnitud));
        float distancia = (camara.transform.position.x * magnitud);

        transform.position = new Vector3(inicio + distancia, transform.position.y, transform.position.z);

        if (avance > inicio + size)
        {
            inicio += size;

        }
        else if (avance < inicio - size)
        {
            inicio -= size;
        }
    }
}
