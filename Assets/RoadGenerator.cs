using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    public GameObject roadPrefab;
    public GameObject player;
    public int roadLength = 5;
    public int segmentLength = 10;
    public float distanceBeforeRegenerate = 50.0f;

    private List<GameObject> segments;
    private float distanceSinceLastSegment;

    private void Start()
    {
        segments = new List<GameObject>();

        // Generate initial road segments
        for (int i = 0; i < roadLength; i++)
        {
            GenerateSegment();
        }
    }
   void Update()
{
    // Get the player's current position
    Vector3 playerPos = player.transform.position;

    // Check if a new segment needs to be generated
    if (playerPos.z > distanceSinceLastSegment - distanceBeforeRegenerate)
    {
        // Generate a new segment
        GenerateSegment();

        // Check if the player has moved too far from the oldest segment
        if (playerPos.z > distanceSinceLastSegment)
        {
            // If the player has moved too far, remove the oldest segment from the list and destroy it
            Destroy(segments[0]);
            segments.RemoveAt(0);
            
            // Move the new segment to be just ahead of the player
            Vector3 offset = new Vector3(0, 0, segmentLength * (Mathf.FloorToInt(playerPos.z / segmentLength) + 1));
            segments[segments.Count - 1].transform.position = offset;
            
            // Update the distanceSinceLastSegment variable
            distanceSinceLastSegment = offset.z;
        }
    }
}
    private void GenerateSegment()
    {
        // Get the player's current position
        Vector3 playerPos = player.transform.position;

        // Calculate the position for the new segment
        Vector3 segmentPos = new Vector3(0, 0, distanceSinceLastSegment);

        // Add the new segment to the list
        segments.Add(Instantiate(roadPrefab, segmentPos, Quaternion.identity));

        // Update the distanceSinceLastSegment variable
        distanceSinceLastSegment += segmentLength;

        // Check if the player has moved too far from the new segment
        if (playerPos.z > distanceSinceLastSegment)
        {
            // If the player has moved too far, move the segment to be just ahead of the player
            Vector3 offset = new Vector3(0, 0, segmentLength * (Mathf.FloorToInt(playerPos.z / segmentLength) + 1));
            segments[0].transform.position = offset;
            segments.RemoveAt(0);
            distanceSinceLastSegment = offset.z;
        }
    }
}
