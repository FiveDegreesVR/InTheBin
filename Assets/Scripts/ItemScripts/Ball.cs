using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : Item {
    int point = 3;
    // Start is called before the first frame update
    public void Start()
    {
        base.setNewPoint(point);
    }
}
