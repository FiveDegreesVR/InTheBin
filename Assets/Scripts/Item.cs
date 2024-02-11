using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // Start is called before the first frame update
    int points = 0;
    public static float gravity = 8.5f;
    public static float gravity_strength = 10;
    protected void setNewPoint(int point)
    {
        points = point;
    }
    void Start()
    {
        
    }
    void OnEnable()
    {
        this.GetComponent<Rigidbody>().AddForce(new Vector3(0, -gravity, 0) * gravity_strength);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Caught")
        {
            Points.gotPoints(points);
            this.gameObject.SetActive(false);
            //Debug.Log("Scored");
        }
        else if(other.gameObject.tag == "Floor")
        {
            this.gameObject.SetActive(false);
        }
    }
}
