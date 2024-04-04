using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class ARGameManager : MonoBehaviour
{
    private bool placingARObj = false;
    public ARRaycastManager arRaycastManager;
    public ARPlaneManager arPlaneManager;

    public GameObject ARObjPrefab;
    
    // public float offset;
    
    private void Awake()
    {
        //enable touch input
        TouchSimulation.Enable();
        EnhancedTouchSupport.Enable();

        placingARObj = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Handle touch input
        if (Touch.activeTouches.Count > 0 && placingARObj)
        {
            // spawn trashcan in AR Mode 
            if (Touch.activeTouches[0].phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Touch.activeTouches[0].delta);
                List<ARRaycastHit> hits = new List<ARRaycastHit>();
                if (arRaycastManager.Raycast(ray, hits))
                {
                    Pose hitPose = hits[0].pose;
                    GameObject arObjInstance = Instantiate(ARObjPrefab);
                    arObjInstance.transform.position = new Vector3(hitPose.position.x, hitPose.position.y, hitPose.position.z);
                    arObjInstance.transform.rotation = Quaternion.Euler(Vector3.zero);

                    var arPlanes = arPlaneManager.trackables;
                    arPlaneManager.enabled = false;
                    foreach(var plane in arPlanes)
                    {
                        plane.gameObject.SetActive(false);
                    }
                    
                    placingARObj = false;
                }
            }
        }
    }
}
