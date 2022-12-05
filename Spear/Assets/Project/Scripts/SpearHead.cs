using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearHead : MonoBehaviour
{

    private RaycastHit hit;
    private int score =0;

    public Score scoreManager;
    private void OnTriggerEnter(Collider other)
    {

        if(other.name == "Head")
        {
            score += 10;

            scoreManager.GemScore = score.ToString();
        }
    }

    public bool Collide(string tag)
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, 0.5f))
        {
            if (hit.collider.CompareTag(tag))
            {
                return true;
            }
            else return false;
        }
        else return false;
    }
    public GameObject CollideObject
    {
        get
        {
            return hit.collider.gameObject;
        }
    }

}
