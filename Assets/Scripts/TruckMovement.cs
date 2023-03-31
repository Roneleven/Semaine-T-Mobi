using UnityEngine;
using TMPro;

public class TruckMovement : MonoBehaviour
{
    private float startingZPos;
    [HideInInspector]public float distanceTraveled;
    public TextMeshProUGUI distanceText;
    public Score score; // Référence au script ScoreManager

    void Start()
    {
        // Store the starting Z position of the truck
        startingZPos = transform.position.z;
    }

    void Update()
    {
        // Calculate the distance traveled by the truck
        distanceTraveled = transform.position.z - startingZPos;

        // Update the distanceText TextMeshProUGUI component with the distance traveled
        distanceText.text = distanceTraveled.ToString("F2") + " m";

        // Appeler la fonction UpdateScore() du script ScoreManager
        score.UpdateScore();
    }
}
