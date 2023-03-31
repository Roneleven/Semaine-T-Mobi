using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public float currentScore;
    public float bestScore;

    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI bestScoreText;

    public TruckMovement truckMovement;

    void Start()
    {
        // Charger le meilleur score depuis PlayerPrefs
        bestScore = PlayerPrefs.GetFloat("BestScore", 0f);
        bestScoreText.text = "Meilleur score : " + bestScore.ToString("F2") + " m";

        // Charger le dernier score depuis PlayerPrefs
        currentScore = PlayerPrefs.GetFloat("CurrentScore", 0f);
        currentScoreText.text = "Dernier score : " + currentScore.ToString("F2") + " m";
    }

    // Mettre à jour le score courant et le meilleur score
    public void UpdateScore()
    {
        currentScore = truckMovement.distanceTraveled;
        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            // Enregistrer le meilleur score dans PlayerPrefs
            PlayerPrefs.SetFloat("BestScore", bestScore);
            PlayerPrefs.Save();
            bestScoreText.text = "Meilleur score : " + bestScore.ToString("F2") + " m";
        }

        // Enregistrer le dernier score dans PlayerPrefs
        PlayerPrefs.SetFloat("CurrentScore", currentScore);
        PlayerPrefs.Save();
        currentScoreText.text = "Dernier score : " + currentScore.ToString("F2") + " m";
    }
}
