using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorMapa : MonoBehaviour
{
    public List<GameObject> Plataformas = new List<GameObject>();
    public GameObject Chunk0;
    public GameObject Chunk1;
    public GameObject Chunk2;
    public GameObject Chunk3;
    public GameObject Chunk4;
    public GameObject Chunk5;
    public GameObject Chunk6;
    public GameObject Chunk7;
    public GameObject Chunk8;
    public GameObject Chunk9;

    public Transform Spawn;
    public Transform Despawn;
    public float Distancia;

    private float offset;
    private bool activo;
    Vector3 posicion;


    void Start()
    {
        activo = true;

        Plataformas.Add(Chunk0);
        Plataformas.Add(Chunk1);
        Plataformas.Add(Chunk2);
        Plataformas.Add(Chunk3);
        Plataformas.Add(Chunk4);
        Plataformas.Add(Chunk5);
        Plataformas.Add(Chunk6);
        Plataformas.Add(Chunk7);
        Plataformas.Add(Chunk8);
        Plataformas.Add(Chunk9);

    }

 
    void Update()
    {
        if (transform.position.x < Spawn.position.x && activo == true)
            // el Spawn se mueve fijo delante del personaje, child de camera.
        {   //si el SpawnPoint llega al generador

            transform.position = new Vector3(transform.position.x + offset + Distancia, transform.position.y, 0);
            //se mueve el Generador hacia adelante

            posicion = new Vector3(transform.position.x, transform.position.y, 1);
            int i = Random.Range(0, 10);
            Instantiate(Plataformas[i], posicion, transform.rotation);
            // Spawnea un chunk random en la posición del Generador.

            offset = Plataformas[i].GetComponent<BoxCollider2D>().size.x;
            // offset mide igual que el ultimo chunk.
        }
    }


    public void Reset()
    {
        activo = false;
        offset = 0;  // limpiar el offset.

        transform.localPosition = new Vector3(1, 0, 0);
        // mueve el generador al inicio.

        var chunks = GameObject.FindGameObjectsWithTag("Chunk"); // Los prebaf que se generan tienen el tag "Chunk".
        foreach (var chunk in chunks) { Destroy(chunk); }
        // borrar chunks.

        activo = true;
    }
}
