
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPoints : MonoBehaviour
{
    public AudioSource source;
    public LixoSpawnerController lixoSpawnerController;
    private void OnTriggerEnter(Collider other) {
        
        // Optional: Check if the entering object is the Player
        if (other.gameObject.CompareTag("Lixo")) {
            Destroy(other.gameObject);
            source.Play();
            lixoSpawnerController.AddToPoints(1);
            
        }
    }
}
