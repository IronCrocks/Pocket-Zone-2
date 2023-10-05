using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3f;
    public Tilemap Tilemap;

    private Vector3 offset;
    private Vector3 velocity = Vector3.zero;
    private BoundsInt TilemapBounds;

    private void Start()
    {
        offset = transform.position - target.position;
        TilemapBounds = Tilemap.cellBounds;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        // Ограничение движения камеры
        float tilemapWidth = TilemapBounds.size.x;
        float tilemapHeight = TilemapBounds.size.y;
        float cameraHalfHeight = GetComponent<Camera>().orthographicSize;
        float cameraHalfWidth = cameraHalfHeight * ((float)Screen.width / Screen.height);

        float minX = TilemapBounds.min.x + cameraHalfWidth;
        float maxX = TilemapBounds.max.x - cameraHalfWidth;
        float minY = TilemapBounds.min.y + cameraHalfHeight;
        float maxY = TilemapBounds.max.y - cameraHalfHeight;

        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
