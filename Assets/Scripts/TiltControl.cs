using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltControl : MonoBehaviour
{
    public float speed;
    public GameObject trashcan;

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(Input.acceleration.x, 0.0f, 0.0f);
        trashcan.GetComponent<Rigidbody>().velocity = movement * speed;
    }
}
