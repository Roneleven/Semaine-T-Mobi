using UnityEngine;

public class TruckMovement : MonoBehaviour {
    private float startingZPos;
    private float distanceTraveled;

    void Start () {
        // Store the starting Z position of the truck
        startingZPos = transform.position.z;
    }
    
    void Update () {
        // Calculate the distance traveled by the truck
        distanceTraveled = transform.position.z - startingZPos;
        
        // Print the distance traveled to the console
        Debug.Log("Distance traveled: " + distanceTraveled);
    }
}
