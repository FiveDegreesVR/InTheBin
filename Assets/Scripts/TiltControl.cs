using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltControl : MonoBehaviour
{
    public float speed;
    public GameObject trashcan;
    private Rigidbody _rigidbody;

    private void Start()
    {
        trashcan = GameObject.FindWithTag("TrashCan");
        _rigidbody = trashcan.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(Input.acceleration.x, 0.0f, 0.0f);
        _rigidbody.velocity = movement * speed;
    }
}
