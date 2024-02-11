using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject objToFollow;


    // Update is called once per frame
    void Update()
    {
        var o = gameObject;
        var position = o.transform.position;
        position = new Vector3(objToFollow.transform.position.x, position.y, position.z);
        o.transform.position = position;
    }
}
