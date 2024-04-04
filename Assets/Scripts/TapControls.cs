using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapControls : MonoBehaviour
{
    public Button leftbutton;
    public Button rightbutton;
    public GameObject trashcan;
    public float speed;
    private LRButtonPressed _lrButtonPressed;
    private LRButtonPressed _lrButtonPressed1;
    private Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        trashcan = GameObject.FindWithTag("TrashCan");
        _rigidbody = trashcan.GetComponent<Rigidbody>();
        _lrButtonPressed1 = leftbutton.GetComponent<LRButtonPressed>();
        _lrButtonPressed = rightbutton.GetComponent<LRButtonPressed>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_lrButtonPressed1.buttonPressed)
        {
            MoveCan(-1.0f);
        }
        if (_lrButtonPressed.buttonPressed)
        {
            MoveCan(1.0f);
        }
    }

    private void MoveCan(float horizontalInput)
    {
        _rigidbody.AddRelativeForce(new Vector3(horizontalInput * speed * Time.deltaTime, 0), ForceMode.Acceleration);
    }
}
