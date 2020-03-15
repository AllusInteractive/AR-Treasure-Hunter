using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PortalPlacer : MonoBehaviour
{
    ARRaycastManager m_ARRaycastManager;
    List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();

    // GameObject to be instantiated
    public GameObject portal;
    // GameObject to be spawned
    private GameObject spawnedPortal;

    private void Awake()
    {
        m_ARRaycastManager = GetComponent<ARRaycastManager>();
    }
    
    void Update()
    {
        if (Input.touchCount > 0)
        {
            // Get the touch input
            Touch touch = Input.GetTouch(0);

            if (m_ARRaycastManager.Raycast(touch.position, raycastHits, TrackableType.PlaneWithinPolygon))
            {
                // Get the pose of the hit
                Pose pose = raycastHits[0].pose;

                if (spawnedPortal == null)
                {
                    spawnedPortal = Instantiate(portal, pose.position, Quaternion.Euler(0, 0, 0));

                    // TODO: move following lines to private function SetPortalRotation()

                    var rotationOfPortal = spawnedPortal.transform.rotation.eulerAngles;

                    spawnedPortal.transform.eulerAngles = new Vector3(rotationOfPortal.x, Camera.main.transform.eulerAngles.y, rotationOfPortal.z);
                }
                else
                {
                    spawnedPortal.transform.position = pose.position;

                    var rotationOfPortal = spawnedPortal.transform.rotation.eulerAngles;

                    spawnedPortal.transform.eulerAngles = new Vector3(rotationOfPortal.x, Camera.main.transform.eulerAngles.y, rotationOfPortal.z);
                }
            }
        }
    }
    /*
    private void SetPortalRotation(gameObject portal)
    {

    }*/
}
