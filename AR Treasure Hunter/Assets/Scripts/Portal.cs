using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Portal : MonoBehaviour
{
    public Material[] materials;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.name != "Main Camera")
        {
            return;
        }

        // Outside the portal
        if (transform.position.z > collider.transform.position.z)
        {
            foreach (var mat in materials)
            {
                mat.SetInt("stest", (int)CompareFunction.Equal);
            }
        }
        // Inside the portal
        else
        {
            foreach (var mat in materials)
            {
                mat.SetInt("stest", (int)CompareFunction.NotEqual);
            }
        }
    }
}
