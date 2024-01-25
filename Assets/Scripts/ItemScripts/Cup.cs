using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : Item
{
    int point = 5;
    // Start is called before the first frame update
    public void Start()
    {
        base.setNewPoint(point);
    }
}
