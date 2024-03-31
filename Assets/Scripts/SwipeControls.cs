using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

public class SwipeControls : MonoBehaviour
{
    public float speed;
    public GameObject trashcan;
    public float minSwipeDistance;
    public float maxSwipeDistance;
    public float dragSpeed;

    private Rigidbody _rigidbody;
    private bool isSwiping = false;
    private bool isChangingDirection = false;
    private Vector2 swipeStartPosition;
    private Vector2 lastTouchPosition;
    private float swipeDirection;
    private float swipeDistance;
    private Vector3 swipeVelocity;

    // Start is called before the first frame update
    void Start()
    {
        trashcan = GameObject.FindWithTag("TrashCan");
        _rigidbody = trashcan.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        DetectSwipe();
    }
    void DetectSwipe()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    isSwiping = true;
                    swipeStartPosition = touch.position;
                    lastTouchPosition = swipeStartPosition;
                    swipeDistance = 0f;
                    swipeDirection = 0f;
                    isChangingDirection = false;
                    break;
                case TouchPhase.Moved:
                    if (isSwiping)
                    {
                        Vector2 touchDelta = touch.position - lastTouchPosition;
                        Vector3 move = new Vector3(touchDelta.x, 0, 0) * dragSpeed * Time.deltaTime;
                        trashcan.transform.Translate(move, Space.World);
                        lastTouchPosition = touch.position;
                        swipeDistance += Mathf.Abs(touchDelta.x);
                        if (swipeDirection == 0f)
                        {
                            swipeDirection = Mathf.Sign(touchDelta.x);
                            swipeVelocity = move / Time.deltaTime;
                        }
                        else if (Mathf.Sign(touchDelta.x) != swipeDirection && !isChangingDirection)
                        {
                            // If direction changes while actively swiping, reset the swipe velocity
                            swipeVelocity = Vector3.zero;
                            isChangingDirection = true;
                        }
                    }
                    break;
                case TouchPhase.Stationary:
                    if (isSwiping)
                    {
                        Vector3 move = swipeVelocity * Time.deltaTime;
                        trashcan.transform.Translate(move, Space.World);
                    }
                    break;
                case TouchPhase.Ended:
                    isSwiping = false;
                    float swipeSpeed = Mathf.Clamp(swipeDistance / maxSwipeDistance, 0f, 1f);
                    Vector3 finalMove = new Vector3(swipeDirection, 0, 0) * swipeSpeed * dragSpeed;
                    _rigidbody.velocity = finalMove;
                    break;
            }
        }
        else
        {
            // If touch is not active, stop the trashcan movement
            _rigidbody.velocity = Vector3.zero;
            isSwiping = false;
            isChangingDirection = false;
        }
    }
}
