using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnMapa : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.transform.parent.gameObject);

        /* 
           como detecta un collider trigger, 
           en los Chunk hay que meter el Prefab puntodesaparición para que lo detecte en un punto concreto
        */
    }
}
