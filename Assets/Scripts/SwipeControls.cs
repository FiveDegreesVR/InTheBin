using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeControls : MonoBehaviour
{
    public float speed;
    public GameObject trashcan;
    private bool moving = false;
    private Vector3 initTouch;
    private Vector3 endTouch;
    private Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        trashcan = GameObject.FindWithTag("TrashCan");
        _rigidbody = trashcan.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // get first touch since touch count is greater than zero
            
            /*
            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                // get the touch position from the screen touch to world point
                Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, 0.0f, 0.0f));
                // lerp and set the position of the current object to that of the touch, but smoothly over time.
                trashcan.transform.position = Vector3.Lerp(trashcan.transform.position, touchedPos * speed, Time.deltaTime);
            }
            */

            if (touch.phase == TouchPhase.Began)
            {
                initTouch = Camera.main.ScreenToViewportPoint(new Vector3(touch.position.x, touch.position.y, 0.0f));
                print(initTouch);
            }
            
            if (touch.phase == TouchPhase.Ended)
            {
                endTouch = Camera.main.ScreenToViewportPoint(new Vector3(touch.position.x, touch.position.y, 0.0f));
                print(endTouch);
                
                _rigidbody.AddForce((endTouch-initTouch) * speed, ForceMode.Impulse);
            }
        }
    }
}
