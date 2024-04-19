using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableController : MonoBehaviour
{

    private PowerUpController _powerUpController;
    private GameObject trashCan;
    private Rigidbody rb;
    
    private GameObject floor;
    private Transform shadow;
    
    // Start is called before the first frame update
    void Awake()
    {
        trashCan = GameObject.FindWithTag("TrashCan");
        _powerUpController = GameObject.FindWithTag("GameController").GetComponent<PowerUpController>();
        rb = GetComponent<Rigidbody>();
        
        floor = GameObject.FindWithTag("Floor");
        shadow = GetComponentInChildren<SpriteRenderer>().transform;
        
        shadow.transform.SetParent(transform.parent);
        shadow.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }

    private void OnEnable()
    {
        shadow.gameObject.SetActive(true);
    }
    private void OnDisable()
    {
        shadow.gameObject.SetActive(false);
    }
    
    public float Scale(float OldMin, float OldMax, float NewMin, float NewMax, float OldValue){
     
        float OldRange = (OldMax - OldMin);
        float NewRange = (NewMax - NewMin);
        float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;
     
        return(NewValue);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_powerUpController.activePowerup == PowerUpController.Powerup.Magnet)
        {
            rb.AddForce((Vector3.right*(trashCan.transform.position.x-transform.position.x))/4, ForceMode.VelocityChange);
        }
        
        shadow.transform.position = new Vector3(transform.position.x, floor.transform.position.y+0.01f, transform.position.z);
        
        float shadowScale = Scale(0, 7.5f, 0f, 0.1f, transform.position.y);
        shadowScale = -(shadowScale - 0.1f);
        shadow.transform.localScale = new Vector3(shadowScale, shadowScale, shadowScale);
    }
}
