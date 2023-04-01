using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class HighScore : MonoBehaviour
{
    public TruckMovement distanceTrav;
    public CollisionManager isDead;
    public TMP_Text scoreFinalText;
    public TMP_Text bestScoreText;
    float highScore;

    public UnityEvent onReloadScene;

    private void Start()
    {
        highScore = PlayerPrefs.GetFloat("HighScore", 0);
        UpdateScores();
    }

    private void Update()
    {
        if (isDead.isDead)
        {
            UpdateScores();
            if (distanceTrav.distanceTraveled > highScore)
            {
                PlayerPrefs.SetFloat("HighScore", distanceTrav.distanceTraveled);
                bestScoreText.text = "Best Score : " + distanceTrav.distanceTraveled;
                PlayerPrefs.Save();
            }
        }
    }

    private void UpdateScores()
    {
        scoreFinalText.text = "Score : " + distanceTrav.distanceTraveled;
        bestScoreText.text = "Best Score : " + highScore;
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        onReloadScene.Invoke();
    }

    private void OnEnable()
    {
        // Ajoute la fonction de rechargement de scène à l'événement
        onReloadScene.AddListener(ReloadScene);
    }

    private void OnDisable()
    {
        // Retire la fonction de rechargement de scène de l'événement
        onReloadScene.RemoveListener(ReloadScene);
    }

    private void ReloadScene()
    {
        // Charge la scène actuelle à nouveau
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Replace "YourSceneName" with the name of your scene
    }
}
