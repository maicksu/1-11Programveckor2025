using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // Reference to the player's Transform
    public float smoothSpeed = 0.125f;  // Smooth speed for the camera movement
    public Vector3 offset;  // Offset from the player, so the camera isn't exactly at the player's position
    public float yOffset = 1f;  // Optional vertical offset to keep the camera at a fixed height

    void LateUpdate()
    {
        // Ensure the player reference is assigned
        if (player != null)
        {
            // Calculate the desired position of the camera (player position + offset)
            Vector3 desiredPosition = new Vector3(player.position.x + offset.x, player.position.y + yOffset, offset.z);

            // Smoothly move the camera toward the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Set the camera's position to the smoothed position
            transform.position = smoothedPosition;
        }
    }
}
