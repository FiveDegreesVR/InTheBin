using UnityEngine;

public class SetWorldRotation : MonoBehaviour
{
    void Update()
    {
        // Set the world rotation of the object to (90, 0, 0)
        transform.rotation = Quaternion.Euler(90, 0, 0);
    }
}
