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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (leftbutton.GetComponent<LRButtonPressed>().buttonPressed)
            {
                MoveCan(-1.0f);
            }
            if (rightbutton.GetComponent<LRButtonPressed>().buttonPressed)
            {
                MoveCan(1.0f);
            }
        }
    }

    private void MoveCan(float horizontalInput)
    {
        trashcan.GetComponent<Rigidbody>().AddForce(new Vector3(horizontalInput * speed * Time.deltaTime, 0));
    }
}
