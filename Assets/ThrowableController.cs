using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableController : MonoBehaviour
{

    private PowerUpController _powerUpController;
    private GameObject trashCan;
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Awake()
    {
        trashCan = GameObject.FindWithTag("TrashCan");
        _powerUpController = GameObject.FindWithTag("GameController").GetComponent<PowerUpController>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_powerUpController.activePowerup == PowerUpController.Powerup.Magnet)
        {
            rb.AddForce((Vector3.right*(trashCan.transform.position.x-transform.position.x))/4, ForceMode.VelocityChange);
        }
    }
}
