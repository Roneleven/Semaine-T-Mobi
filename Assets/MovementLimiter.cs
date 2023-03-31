using UnityEngine;

public class MovementLimiter : MonoBehaviour
{
    public Rect movementBounds; // Le rectangle qui d�limite les limites de mouvement.

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void LateUpdate()
    {
        // On s'assure que le GameObject reste dans les limites d�finies par le rectangle.
        float xPosition = Mathf.Clamp(transform.position.x, movementBounds.xMin, movementBounds.xMax);
        float yPosition = Mathf.Clamp(transform.position.y, movementBounds.yMin, movementBounds.yMax);
        float zPosition = Mathf.Clamp(transform.position.z, movementBounds.yMin, movementBounds.yMax);

        transform.position = new Vector3(xPosition, yPosition, zPosition);
    }

    // Si vous voulez r�initialiser la position du GameObject � son point de d�part initial, vous pouvez utiliser cette fonction :
    public void ResetPosition()
    {
        transform.position = startPosition;
    }

    // Fonction pour dessiner les Gizmos dans l'�diteur.
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 center = new Vector3(movementBounds.center.x, 0f, movementBounds.center.y);
        Vector3 size = new Vector3(movementBounds.width, 0f, movementBounds.height);
        Gizmos.DrawWireCube(center, size);
    }
}
