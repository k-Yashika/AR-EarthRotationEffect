using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthRotationControl : MonoBehaviour
{
    private float rotationSpeed = 30.0f; // Adjust the rotation speed as needed
    private bool isRotating = false;
    private Vector2 lastTouchPosition;

    void Update()
    {
        // Check for touch input
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            // Handle touch events
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    lastTouchPosition = touch.position;
                    isRotating = true;
                    break;

                case TouchPhase.Moved:
                    if (isRotating)
                    {
                        // Convert lastTouchPosition to Vector3 and calculate the rotation
                        Vector3 delta = touch.position - lastTouchPosition;
                        float rotationX = delta.y * rotationSpeed * Time.deltaTime;
                        float rotationY = -delta.x * rotationSpeed * Time.deltaTime;

                        // Apply rotation to the Earth model
                        transform.Rotate(Vector3.up, rotationY, Space.World);
                        transform.Rotate(Vector3.right, rotationX, Space.World);

                        // Store the current touch position for the next frame
                        lastTouchPosition = touch.position;
                    }
                    break;

                case TouchPhase.Ended:
                    isRotating = false;
                    break;
            }
        }
    }
}
