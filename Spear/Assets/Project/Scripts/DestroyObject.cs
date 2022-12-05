using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public Camera camera;
    void Update()
    {
        if (camera.transform.position.z > transform.position.z)
        {
            if(transform.tag == "ExtGate" || transform.tag == "Enemy")
            {
                gameObject.SetActive(false);
            }
            else if(transform.name == "Effect")
            {
                Destroy(gameObject);
            }
        }           
    }
}
