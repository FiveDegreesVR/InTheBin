using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragController : MonoBehaviour
{
    private bool isDragging = false;
    private bool hasReleased = false;
    private Vector2 touchStartPos;
    private Vector3 objectStartPos;
    private Vector3 currentForce;
    public float maxSpeed; // Maximum speed limit
    private float smoothTime = 0.1f; // Smoothing time for force application
    private Vector3 currentVelocity = Vector3.zero;
    private bool isSwipingInSameDirection = true;

    public float dragSpeed = 0.1f;
    public float forceMultiplier = 5f; // Adjust this value to control the force applied
    public Rigidbody trashcanRigidbody;

    void Update()
    {
        DragCan();
    }
    public void DragCan()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    isDragging = true;
                    hasReleased = false;
                    touchStartPos = touch.position;
                    objectStartPos = trashcanRigidbody.position;
                    isSwipingInSameDirection = true; // Assume swiping in the same direction until proven otherwise
                    break;
                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    if (isDragging && !hasReleased)
                    {
                        Vector2 direction = touch.position - touchStartPos;
                        float distance = direction.magnitude;
                        Vector2 swipeDirection = direction.normalized;
                        currentForce = new Vector3(swipeDirection.x, 0, 0) * distance * dragSpeed * forceMultiplier;
                        Debug.Log(currentForce);

                        // Smooth out force application
                        currentForce = Vector3.SmoothDamp(trashcanRigidbody.velocity, currentForce, ref currentVelocity, smoothTime);
                        // Apply max speed limit
                        currentForce = Vector3.ClampMagnitude(currentForce, maxSpeed);

                        trashcanRigidbody.velocity = currentForce;

                        // Check if swiping in opposite direction
                        float dotProduct = Vector2.Dot(direction.normalized, currentVelocity.normalized);
                        if (dotProduct < 0f)
                        {
                            isSwipingInSameDirection = false;
                        }
                    }
                    break;
                case TouchPhase.Ended:
                    isDragging = false;
                    hasReleased = true;
                    break;
            }
        }

        // If the direction changes while swiping, reset speed and velocity
        if (!isDragging && !isSwipingInSameDirection && hasReleased)
        {
            trashcanRigidbody.velocity = Vector3.zero;
            currentForce = Vector3.zero;
        }
    }
}

