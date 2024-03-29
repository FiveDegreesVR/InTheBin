using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllMovement : MonoBehaviour
{
    public GameObject trashcan;
    private float swipeSpeed = 10;
    private float tiltSpeed = 10;
    private float tapSpeed = 10;    
    private float jumpHeight = 10;

    private bool moving = false;
    private Vector3 initTouch;
    private Vector3 endTouch;
    private Vector3 initState;
    private Vector3 movement;
    private Rigidbody _rigidbody;

    Quaternion stateCheck;

    // Start is called before the first frame update
    void Start()
    {
        trashcan = GameObject.FindWithTag("TrashCan");
        _rigidbody = trashcan.GetComponent<Rigidbody>();
        initState = new Vector3(Input.acceleration.x, 0.0f, (Input.acceleration.y));
    }

    // Update is called once per frame
    void Update()
    {
        //Tilt
        movement = new Vector3(Input.acceleration.x, 0.0f, (Input.acceleration.y));
        //stateCheck = Input.gyro.attitude;
        _rigidbody.velocity = (movement - initState) * tiltSpeed;
        _rigidbody.AddForce(Input.gyro.userAcceleration);
        Debug.Log("Initial State: " + initState + " / Movement: " + movement + Input.gyro.userAcceleration);

        //Swipe - Replace the Swipe functionality with the one created by Gabe

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // get first touch since touch count is greater than zero

            if (touch.phase == TouchPhase.Began)
            {
                initTouch = Camera.main.ScreenToViewportPoint(new Vector3(touch.position.x, touch.position.y, 0.0f));
            }

            if (touch.phase == TouchPhase.Ended)
            {
                endTouch = Camera.main.ScreenToViewportPoint(new Vector3(touch.position.x, touch.position.y, 0.0f));
                _rigidbody.AddForce((endTouch - initTouch) * swipeSpeed, ForceMode.Impulse);
            }
        }
    }

    public void Jump()
    {
        _rigidbody.AddForce(new Vector3(0.0f, jumpHeight, 0.0f), ForceMode.Impulse);
    }

    public void LeftTap()
    {
        _rigidbody.AddForce(new Vector3(-(tapSpeed), 0.0f, 0.0f), ForceMode.Impulse);
    }

    public void RightTap()
    {
        _rigidbody.AddForce(new Vector3(tapSpeed, 0.0f, 0.0f), ForceMode.Impulse);
    }

    public void ForwardTap()
    {
        _rigidbody.AddForce(new Vector3(0.0f, tapSpeed, 0.0f), ForceMode.Impulse);
    }

    public void BackwardTap()
    {
        _rigidbody.AddForce(new Vector3(0.0f, -(tapSpeed), 0.0f), ForceMode.Impulse);
    }
}
