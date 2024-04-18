using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPointsThrowableController : MonoBehaviour
{
    private GameObject floor;
    private Transform shadow;
    
    void Awake()
    {
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
    
    void FixedUpdate()
    {
        shadow.transform.position = new Vector3(transform.position.x, floor.transform.position.y+0.01f, transform.position.z);
    }
}
