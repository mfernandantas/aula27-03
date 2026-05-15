using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class LixoSpawnerController : MonoBehaviour
{
    public float maximumX = 5f;
    public float fixedY = 10f;
    public float fixedZ = 0f;
    public float timer = 2f; 
    public GameObject Lixo; 

    public int MaxPoints = 10;
    public int points = 0;
    public TMP_Text pointsText;
    public TMP_Text victoryText;

    // Arraste o AudioSource de erro para cá no Unity
    public AudioSource somErro; 

    private bool jogoAcabou = false;

    void Start()
    {
        if (victoryText != null) victoryText.gameObject.SetActive(false);
        StartCoroutine(SpawnRoutine());
    }

    public void AddToPoints(int amount) {
        if (jogoAcabou) return;
        points += amount;
        if (pointsText != null) pointsText.text = "Pontos: " + points;
        if (points >= MaxPoints) Vencer();
    }

    public void RemovePoints(int amount)
    {
        if (jogoAcabou == false)
        {
            points -= amount;
            if (pointsText != null) pointsText.text = "Pontos: " + points;
            
            // Toca o som quando perde ponto
            if (somErro != null) somErro.Play();
        }
    }

    void Vencer() {
        jogoAcabou = true;
        if (victoryText != null) victoryText.gameObject.SetActive(true);
        StopAllCoroutines(); 
    }

    IEnumerator SpawnRoutine() {
        while (!jogoAcabou) {
            float randomX = Random.Range(-maximumX, maximumX);
            Vector3 spawnPos = new Vector3(randomX, fixedY, fixedZ);
            Instantiate(Lixo, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(timer);
        }
    }
}