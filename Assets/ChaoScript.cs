using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaoScript : MonoBehaviour
{
    private LixoSpawnerController spawner;

    void Start()
    {
        // Acha o Spawner na cena automaticamente
        spawner = FindObjectOfType<LixoSpawnerController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Se o que bateu no chão for o Lixo
        if (collision.gameObject.CompareTag("Lixo"))
        {
            // Tira 1 ponto
            spawner.RemovePoints(1);
            
            // Destrói o lixo para não ficar acumulando no chão
            Destroy(collision.gameObject);
        }
    }
}