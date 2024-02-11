using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    // [SerializeField] private Rigidbody trashCanRB;
    public float speed = 100f;

    private void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontial = Input.GetAxis("Horizontal");
        // float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontial, 0.0f, 0.0f);
        
        playerRB.AddForce(movement * (speed * Time.deltaTime), ForceMode.Impulse); 
        // trashCanRB.AddForce(movement * (speed*2 * Time.deltaTime)); 
    }
}
