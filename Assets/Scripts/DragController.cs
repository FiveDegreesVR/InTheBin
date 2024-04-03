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
    public float acceleration; // Acceleration factor
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
                    objectStartPos = transform.position;
                    break;
                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    if (isDragging && !hasReleased)
                    {
                        Vector2 direction = touch.position - touchStartPos;
                        float distance = direction.magnitude;
                        float swipeSpeed = distance / touch.deltaTime;
                        Vector2 swipeDirection = direction.normalized;

                        // Calculate force based on acceleration
                        float currentSpeed = currentForce.magnitude;
                        float targetSpeed = Mathf.Min(currentSpeed + swipeSpeed * acceleration * Time.deltaTime, maxSpeed);
                        currentForce = swipeDirection * targetSpeed;

                        // Apply force as impulse
                        trashcanRigidbody.AddForce(currentForce - trashcanRigidbody.velocity, ForceMode.Acceleration);
                    }
                    break;
                case TouchPhase.Ended:
                    isDragging = false;
                    hasReleased = true;
                    break;
            }
        }
    }
}

