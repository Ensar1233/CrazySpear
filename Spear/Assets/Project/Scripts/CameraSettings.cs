using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSettings : MonoBehaviour
{
    public Transform target;
    public float sensitiveX;

    private float distanceZ;
    void Start()
    {
        distanceZ = transform.position.z - target.position.z;

    }
    void Update()
    {

        transform.position = new Vector3(
                Mathf.Lerp(transform.position.x,target.position.x,sensitiveX/100),
                transform.position.y,
                target.position.z+distanceZ
        );        
    }


}
