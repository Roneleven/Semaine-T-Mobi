using UnityEngine;

public class MovementLimiter : MonoBehaviour
{
    public Rect movementBounds; // Le rectangle qui délimite les limites de mouvement.

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void LateUpdate()
    {
        // On s'assure que le GameObject reste dans les limites définies par le rectangle.
        float xPosition = Mathf.Clamp(transform.position.x, movementBounds.xMin, movementBounds.xMax);
        float yPosition = Mathf.Clamp(transform.position.y, movementBounds.yMin, movementBounds.yMax);
        float zPosition = Mathf.Clamp(transform.position.z, movementBounds.yMin, movementBounds.yMax);

        transform.position = new Vector3(xPosition, yPosition, zPosition);
    }

    // Si vous voulez réinitialiser la position du GameObject à son point de départ initial, vous pouvez utiliser cette fonction :
    public void ResetPosition()
    {
        transform.position = startPosition;
    }

    // Fonction pour dessiner les Gizmos dans l'éditeur.
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 center = new Vector3(movementBounds.center.x, 0f, movementBounds.center.y);
        Vector3 size = new Vector3(movementBounds.width, 0f, movementBounds.height);
        Gizmos.DrawWireCube(center, size);
    }
}
