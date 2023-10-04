using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Rotates this object towards another object smoothly, useful for cameras
public class SmoothFollow : MonoBehaviour
{
    public GameObject targetObject;
    public int followSpeed;
 
    void Start() 
    {
        AppManager.DebugLog(this.name + " object rotates continously towards object " + targetObject.name);
    }

    void Update()
    {
        if (targetObject != null)
        {
            var targetRotation = Quaternion.LookRotation(targetObject.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, followSpeed * Time.deltaTime);
        }
    }
}
 