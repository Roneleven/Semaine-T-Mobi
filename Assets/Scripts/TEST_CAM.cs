using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_CAM : MonoBehaviour
{
    public Camera cam;
    public float minSize;
    public float heightView;
    public float spawnHeight;
    public Bounds cameraBounds;
    public Bounds centerBounds;
    public Bounds leftBounds;
    public Bounds rightBounds;
    private void Start()
    {
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(centerBounds.center, centerBounds.size);
        Gizmos.DrawWireCube(cameraBounds.center, cameraBounds.size);
        Gizmos.DrawWireCube(leftBounds.center, leftBounds.size);
        Gizmos.DrawWireCube(rightBounds.center, rightBounds.size);
    }
    private void Update()
    {
        centerBounds.extents = new Vector3(minSize, heightView/2, minSize);
        centerBounds.center = new Vector3(0, heightView/2, 0);
        cameraBounds.center = new Vector3(0, heightView, 0);

        float distance = minSize * 2 * 0.5f / Mathf.Tan(cam.fieldOfView * 0.5f * Mathf.Deg2Rad);
        cam.transform.position = new Vector3(0, distance + heightView, 0);
        Vector3 camPos = cam.ViewportToWorldPoint(new Vector3(1, 1, distance));
        cameraBounds.extents = new Vector3(camPos.x, 0, camPos.z);

        float width = cameraBounds.extents.x - centerBounds.extents.x;
        width /= 2;
        float center = width + centerBounds.extents.x;
        Vector3 extents = new Vector3(width, 0, centerBounds.extents.z);
        leftBounds.center = new Vector3(-center, spawnHeight, 0);
        rightBounds.center = new Vector3(center, spawnHeight, 0);
        leftBounds.extents = extents;
        rightBounds.extents = extents;
    }
}
