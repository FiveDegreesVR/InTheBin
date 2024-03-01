using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffScreenTriggerController : MonoBehaviour
{
    private bool throwablesInZone = false;
    [SerializeField] private GameObject OffScreenUI;

    private void Start()
    {
        throwablesInZone = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Throwable") || other.CompareTag("Bomb"))
        {
            if (!throwablesInZone)
            {
                throwablesInZone = !throwablesInZone;
                OffScreenUI.SetActive(throwablesInZone);
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Throwable") || other.CompareTag("Bomb"))
        {
            if (throwablesInZone)
            {
                throwablesInZone = !throwablesInZone;
                OffScreenUI.SetActive(throwablesInZone);
            }
        }
    }
}
