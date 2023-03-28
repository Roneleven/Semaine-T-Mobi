using UnityEngine;

public class TeleportOnContact : MonoBehaviour
{
    public Transform teleportTarget; // The empty transform to teleport to

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has the "Road" tag
        Debug.Log("Trigger entered");
        if (other.CompareTag("Road"))
        {
            // Teleport the colliding object to the target position
            other.transform.position = teleportTarget.position;
            Debug.Log("Teleported " + other.name);
        }
    }
}
