using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearFull : MonoBehaviour
{
    //-4.95 tam
    private RaycastHit hit;
    public float distance = 0.5f;
    public LayerMask layer;
    public bool isFull;

    private BoxCollider boxCollider;
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }
    void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, -transform.forward, out hit, distance, layer))
        {
            boxCollider.enabled = false;

            Debug.DrawRay(transform.position, -transform.forward * distance, Color.blue);
        }
        else boxCollider.enabled = true;
    }

}
