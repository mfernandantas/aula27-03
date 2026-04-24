using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class LixoSpawnerController : MonoBehaviour
{
    // Variáveis de configuração que aparecem no Unity
    public float maximumX = 5f;
    public float fixedY = 10f;
    public float fixedZ = 0f;
    public float timer = 2f; 
    public GameObject Lixo; // Onde você arrasta o Prefab (cubinho azul da pasta Assets)

    // Variáveis de Pontuação e UI
    public int MaxPoints = 10;
    public int points = 0;
    public TMP_Text pointsText;
    public TMP_Text victoryText;

    private bool jogoAcabou = false;

    void Start()
    {
        // Esconde o texto de vitória ao começar
        if (victoryText != null) victoryText.gameObject.SetActive(false);
        
        // Inicia a rotina de criação de lixo
        StartCoroutine(SpawnRoutine());
    }

    // Função que a Lixeira chama para dar pontos
    public void AddToPoints(int amount) {
        if (jogoAcabou) return;

        points += amount;
        
        if (pointsText != null) {
            pointsText.text = "Pontos: " + points;
        }

        if (points >= MaxPoints) {
            Vencer();
        }
    }

    void Vencer() {
        jogoAcabou = true;
        if (victoryText != null) victoryText.gameObject.SetActive(true);
        StopAllCoroutines(); // Para de criar lixo quando vence
    }

    // A "mágica" do tempo de espera
    IEnumerator SpawnRoutine() {
        while (!jogoAcabou) {
            // Cria o lixo em uma posição X aleatória
            float randomX = Random.Range(-maximumX, maximumX);
            Vector3 spawnPos = new Vector3(randomX, fixedY, fixedZ);
            
            Instantiate(Lixo, spawnPos, Quaternion.identity);
            
            // Espera os segundos definidos no Timer
            yield return new WaitForSeconds(timer);
        }
    }
}