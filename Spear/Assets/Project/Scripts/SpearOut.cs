using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearOut : MonoBehaviour
{
    private Rigidbody[] bodies;
    private Collider[] colliders;
    [Header("Objects")]    
    public Transform t_spine;
    public Transform t_hips;
    public Transform enemy;

    [Header("Explosion")]
    public float radius;
    public float force;


    void Start()
    {
        bodies = enemy.GetComponentsInChildren<Rigidbody>();
        colliders = enemy.GetComponentsInChildren<Collider>();


    }
    //burada Tile position belirlenecek.
    private void OnTriggerExit(Collider other)
    {
        if(other.name == "Pivot")
        {
            enemy.SetParent(null);
            transform.GetComponent<SphereCollider>().enabled = false;
            transform.GetComponent<SpearStub>().isStuck = false;
            t_spine.GetComponent<Rigidbody>().isKinematic = false;
            t_hips.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            Explosion();
            other.transform.parent.GetComponent<TilePosition>().SpearOutLastChildPosition();
        }
    }
    
    private void Explosion()
    {


        foreach(Rigidbody rb in bodies)
        {

            rb.AddExplosionForce(force, rb.position + -Vector3.up + -Vector3.forward, 5f, 0.05f, ForceMode.Impulse);
        }
    }

}
