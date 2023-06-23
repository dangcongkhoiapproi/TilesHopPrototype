using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowObject : MonoBehaviour
{
    public Transform target; 
    public float smoothSpeed = 0.125f; 

    private Vector3 offset;

    void Start()
    {
       
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
       
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        
        transform.position = smoothedPosition;
    }
}
